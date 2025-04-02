using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Helpers;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Parsers
{
    public static class RequestParser
    {
        /// <summary>
        /// Parses all public request records from the project.
        /// Only records in the "Aria2.JsonRpcClient.Requests" namespace that inherit from JsonRpcRequest are processed.
        /// For each record, its XML documentation (from the leading trivia) is parsed using XmlDocumentationHelper,
        /// and a new RecordDetails object is created inline.
        /// For each public constructor, documentation is parsed into a MemberDetails object; if its summary is empty,
        /// it falls back to using the corresponding client method's documentation.
        /// </summary>
        /// <param name="project">The Roslyn project instance.</param>
        /// <param name="compilation">The full Compilation for semantic analysis.</param>
        /// <param name="clientDoc">The already–parsed client interface documentation.</param>
        /// <returns>A collection of RequestDetails objects.</returns>
        public static async Task<RequestDocumentation> ParseRequestsAsync(
            Project project,
            Compilation compilation,
            ClientDocumentation clientDoc)
        {
            var recordDetailsList = new List<RecordDetails>();

            var projectDir = !string.IsNullOrEmpty(project.FilePath)
                ? Path.GetDirectoryName(project.FilePath)
                : null;
            if (projectDir == null)
            {
                throw new InvalidOperationException("Project.FilePath is not available.");
            }

            var requestDocuments = project.Documents.Where(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                DocumentFolderFilter.IsInRootFolder(doc.FilePath!, projectDir, "Requests"));

            foreach (var document in requestDocuments)
            {
                var syntaxTree = await document.GetSyntaxTreeAsync().ConfigureAwait(false);
                if (syntaxTree == null)
                {
                    continue;
                }

                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetCompilationUnitRoot();

                var records = root.DescendantNodes().OfType<RecordDeclarationSyntax>();
                foreach (var record in records)
                {
                    // Only process records in the expected namespace.
                    var ns = record.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Requests")
                    {
                        continue;
                    }

                    // Only process public records.
                    var recordSymbol = semanticModel.GetDeclaredSymbol(record) as INamedTypeSymbol;
                    if (recordSymbol == null || recordSymbol.DeclaredAccessibility != Accessibility.Public)
                    {
                        continue;
                    }

                    // Only process records that inherit from JsonRpcRequest.
                    if (record.BaseList == null || !record.BaseList.Types.Any(t => t.Type.ToString().StartsWith("JsonRpcRequest")))
                    {
                        continue;
                    }

                    // Parse the record's documentation from its leading trivia.
                    var recordDocComment = XmlDocumentationHelper.GetDocumentationComment(record.GetLeadingTrivia(), semanticModel);
                    // Create a new RecordDetails object inline.
                    var recordDetails = new RecordDetails
                    {
                        Name = record.Identifier.Text,
                        SummaryFragments = recordDocComment.SummaryFragments,
                        SeeAlso = recordDocComment.SeeAlso,
                        IsAbstract = recordSymbol.IsAbstract,
                    };

                    var ctors = record.Members.OfType<ConstructorDeclarationSyntax>();
                    var constructorDetailsList = DocmentationHelper.GetConstructors(record.Identifier.Text, ctors, semanticModel);

                    // overwrite the methods if mathing details are found
                    for (var i = 0; i < constructorDetailsList.Count; i++)
                    {
                        var constructor = constructorDetailsList[i];
                        var matchingMethod = clientDoc.Methods.FirstOrDefault(m => m.Name.Equals(record.Identifier.Text, StringComparison.OrdinalIgnoreCase) && m.SimpleSignature == constructor.Signature);
                        if (matchingMethod != null)
                        {
                            constructorDetailsList[i].Documentation = matchingMethod.Documentation;
                        }
                        else
                        {
                            throw new InvalidOperationException($"Missing method for request: {recordDetails.Name} with signature {constructor.Signature}.");
                        }
                    }

                    recordDetails.Constructors = constructorDetailsList;

                    recordDetailsList.Add(recordDetails);
                }
            }

            return new RequestDocumentation
            {
                Records = recordDetailsList,
            };
        }
    }
}
