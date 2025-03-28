using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Helpers;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Parsers
{
    public class RequestParser
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
        public async Task<IEnumerable<RequestDetails>> ParseRequestsAsync(
            Project project,
            Compilation compilation,
            ClientDocumentation clientDoc)
        {
            var requestDetailsList = new List<RequestDetails>();

            var projectDir = !string.IsNullOrEmpty(project.FilePath)
                ? Path.GetDirectoryName(project.FilePath)
                : null;
            if (projectDir == null)
                throw new InvalidOperationException("Project.FilePath is not available.");

            var requestDocuments = project.Documents.Where(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                DocumentFolderFilter.IsInRootFolder(doc.FilePath, projectDir, "Requests"));

            foreach (var document in requestDocuments)
            {
                var syntaxTree = await document.GetSyntaxTreeAsync().ConfigureAwait(false);
                if (syntaxTree == null)
                    continue;
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetCompilationUnitRoot();

                var records = root.DescendantNodes().OfType<RecordDeclarationSyntax>();
                foreach (var record in records)
                {
                    // Only process records in the expected namespace.
                    var ns = record.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Requests")
                        continue;

                    // Only process public records.
                    var recordSymbol = semanticModel.GetDeclaredSymbol(record) as INamedTypeSymbol;
                    if (recordSymbol == null || recordSymbol.DeclaredAccessibility != Accessibility.Public)
                        continue;

                    // Only process records that inherit from JsonRpcRequest.
                    if (record.BaseList == null || !record.BaseList.Types.Any(t => t.Type.ToString().StartsWith("JsonRpcRequest")))
                        continue;

                    // Parse the record's documentation from its leading trivia.
                    var recordDocComment = XmlDocumentationHelper.GetDocumentationComment(record.GetLeadingTrivia(), semanticModel);
                    // Create a new RecordDetails object inline.
                    var recordDetails = new RecordDetails
                    {
                        Name = record.Identifier.Text,
                        SummaryFragments = recordDocComment.SummaryFragments,
                        SeeAlso = recordDocComment.SeeAlso
                    };

                    var constructorDetailsList = new List<ConstructorDetails>();
                    var ctors = record.Members.OfType<ConstructorDeclarationSyntax>();
                    foreach (var ctor in ctors)
                    {
                        var ctorSymbol = semanticModel.GetDeclaredSymbol(ctor) as IMethodSymbol;
                        if (ctorSymbol == null || ctorSymbol.DeclaredAccessibility != Accessibility.Public)
                            continue;

                        string signature = $"{record.Identifier.Text}{ctor.ParameterList}";

                        // Parse constructor documentation.
                        var ctorDocComment = XmlDocumentationHelper.GetDocumentationComment(ctor.GetLeadingTrivia(), semanticModel);
                        var ctorDetails = new MemberDetails
                        {
                            SummaryFragments = ctorDocComment.SummaryFragments,
                            ReturnsFragments = ctorDocComment.ReturnsFragments,
                            SeeAlso = ctorDocComment.SeeAlso,
                            Parameters = ctorDocComment.ParameterDocumentation.Select(pd => new ParameterDetails
                            {
                                Name = pd.Name,
                                DocumentationFragments = pd.DocumentationFragments
                            }).ToList()
                        };

                        // If the constructor's summary is empty (likely due to inheritdoc),
                        // fall back to using the client interface method documentation.
                        if (!ctorDetails.SummaryFragments.Any() ||
                            ctorDetails.SummaryFragments.All(f => f is TextFragment tf && string.IsNullOrWhiteSpace(tf.Text)))
                        {
                            // Here we assume that the record's name matches the method name in the client interface.
                            var matchingMethod = clientDoc.Methods.FirstOrDefault(m =>
                                m.Name.Equals(record.Identifier.Text, StringComparison.OrdinalIgnoreCase));
                            if (matchingMethod != null)
                            {
                                ctorDetails = matchingMethod.Documentation;
                            }
                        }

                        constructorDetailsList.Add(new ConstructorDetails
                        {
                            Signature = signature,
                            Documentation = ctorDetails
                        });
                    }

                    requestDetailsList.Add(new RequestDetails
                    {
                        Name = record.Identifier.Text,
                        Documentation = recordDetails, // RecordDetails object for the record.
                        DocumentName = Path.GetFileName(document.FilePath)!,
                        Constructors = constructorDetailsList
                    });
                }
            }

            return requestDetailsList;
        }
    }
}
