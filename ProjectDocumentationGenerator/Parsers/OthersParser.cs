using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Helpers;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Parsers
{
    public static class OthersParser
    {
        private static readonly Dictionary<string, ObjectType> _filesToProcess = new()
        {
            { "Aria2ClientOptions.cs", ObjectType.Record },
            { "Aria2Exception.cs", ObjectType.Exception },
            { "ConnectionType.cs", ObjectType.Enum },
            { "JsonRpcError.cs", ObjectType.Record },
            { "JsonRpcNotification.cs", ObjectType.Record },
            { "JsonRpcParameters.cs", ObjectType.Class },
            { "JsonRpcRequest.cs", ObjectType.Record },
            };

        /// <summary>
        /// Parses all public model types (records and enums) from the project.
        /// Only models in the "Aria2.JsonRpcClient.Models" namespace are processed.
        /// For each record, its XML documentation is parsed from the leading trivia via XmlDocumentationHelper and
        /// a new RecordDetails object is created inline. For each property declared in the record, a corresponding
        /// PropertyDocumentation is created. Public enum declarations are processed similarly.
        /// </summary>
        public static async Task<OthersDocumentation> ParseOthersAsync(Project project, Compilation compilation)
        {
            var projectDir = !string.IsNullOrEmpty(project.FilePath)
                ? Path.GetDirectoryName(project.FilePath)
                : null;
            if (projectDir == null)
            {
                throw new InvalidOperationException("Project.FilePath is not available.");
            }

            var othersDoc = new OthersDocumentation();

            var modelDocuments = GetDocuments(project.Documents);
            foreach (var (document, objectType) in modelDocuments)
            {
                var syntaxTree = await document.GetSyntaxTreeAsync().ConfigureAwait(false);
                if (syntaxTree == null)
                {
                    continue;
                }

                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetCompilationUnitRoot();

                switch (objectType)
                {
                    case ObjectType.Record:
                        var recordDeclarations = root.DescendantNodes().OfType<RecordDeclarationSyntax>();
                        foreach (var recordDeclaration in recordDeclarations)
                        {
                            var recordDocumentation = DocmentationHelper.GetRecordDocumentation(recordDeclaration, semanticModel);
                            if (recordDocumentation is not null)
                            {
                                othersDoc.Records.Add(recordDocumentation);
                            }
                        }

                        break;
                    case ObjectType.Class:
                        var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                        foreach (var classDeclaration in classDeclarations)
                        {
                            var classDocumentation = DocmentationHelper.GetClassDocumentation(classDeclaration, semanticModel);
                            if (classDocumentation is not null)
                            {
                                othersDoc.Classes.Add(classDocumentation);
                            }
                        }

                        break;
                    case ObjectType.Enum:
                        var enumDeclarations = root.DescendantNodes().OfType<EnumDeclarationSyntax>();
                        foreach (var enumDeclaration in enumDeclarations)
                        {
                            var enumDocumentation = DocmentationHelper.GetEnumDocumentation(enumDeclaration, semanticModel);
                            if (enumDocumentation is not null)
                            {
                                othersDoc.Enums.Add(enumDocumentation);
                            }
                        }
                        
                        break;
                    case ObjectType.Exception:
                        break;
                    default:
                        break;
                }
            }

            return othersDoc;
        }

        private static IEnumerable<(Document, ObjectType)> GetDocuments(IEnumerable<Document> documents)
        {
            foreach (var document in documents)
            {
                if (_filesToProcess.TryGetValue(document.Name, out var type))
                {
                    yield return (document, type);
                }
            }
        }

        private enum ObjectType
        {
            Record,
            Class,
            Enum,
            Exception,
        }
    }
}
