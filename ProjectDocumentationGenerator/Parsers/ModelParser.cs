using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Helpers;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Parsers
{
    public static class ModelParser
    {
        /// <summary>
        /// Parses all public model types (records and enums) from the project.
        /// Only models in the "Aria2.JsonRpcClient.Models" namespace are processed.
        /// For each record, its XML documentation is parsed from the leading trivia via XmlDocumentationHelper and 
        /// a new RecordDetails object is created inline. For each property declared in the record, a corresponding
        /// PropertyDocumentation is created. Public enum declarations are processed similarly.
        /// </summary>
        public static async Task<ModelsDocumentation> ParseModelsAsync(Project project, Compilation compilation)
        {
            var modelsDoc = new ModelsDocumentation();
            var projectDir = !string.IsNullOrEmpty(project.FilePath)
                ? Path.GetDirectoryName(project.FilePath)
                : null;
            if (projectDir == null)
            {
                throw new InvalidOperationException("Project.FilePath is not available.");
            }

            // Only process documents in the root-level "Models" folder.
            var modelDocuments = project.Documents.Where(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                DocumentFolderFilter.IsInRootFolder(doc.FilePath!, projectDir, "Models"));

            foreach (var document in modelDocuments)
            {
                var syntaxTree = await document.GetSyntaxTreeAsync().ConfigureAwait(false);
                if (syntaxTree == null)
                {
                    continue;
                }

                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetCompilationUnitRoot();

                // Process public record declarations.
                var recordDeclarations = root.DescendantNodes().OfType<RecordDeclarationSyntax>();
                foreach (var recordDeclaration in recordDeclarations)
                {
                    var ns = recordDeclaration.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Models")
                    {
                        continue;
                    }

                    var recordDetails = DocmentationHelper.GetRecordDocumentation(recordDeclaration, semanticModel);
                    if (recordDetails is null)
                    {
                        continue;
                    }
                    modelsDoc.Records.Add(recordDetails);
                }

                // Process public enum declarations.
                var enumDeclarations = root.DescendantNodes().OfType<EnumDeclarationSyntax>();
                foreach (var enumDeclaration in enumDeclarations)
                {
                    var ns = enumDeclaration.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Models")
                    {
                        continue;
                    }

                    var enumDoc = DocmentationHelper.GetEnumDocumentation(enumDeclaration, semanticModel);
                    if (enumDoc is null)
                    {
                        continue;
                    }
                    modelsDoc.Enums.Add(enumDoc);
                }
            }

            return modelsDoc;
        }
    }
}
