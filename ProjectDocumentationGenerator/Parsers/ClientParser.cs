using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Helpers;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Parsers
{
    public static class ClientParser
    {
        /// <summary>
        /// Parses the public IAria2Client interface from the project.
        /// It obtains XML documentation from the interface declaration's leading trivia,
        /// converts it to a MemberDetails object, and processes each public method similarly.
        /// </summary>
        public static async Task<ClientDocumentation> ParseClientInterfaceAsync(Project project, Compilation compilation)
        {
            // Locate the document "IAria2Client.cs"
            var clientDocFile = project.Documents.FirstOrDefault(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                Path.GetFileName(doc.FilePath)
                    .Equals("IAria2Client.cs", StringComparison.OrdinalIgnoreCase));
            if (clientDocFile == null)
            {
                throw new InvalidOperationException("IAria2Client.cs file not found in the project.");
            }

            var syntaxTree = await clientDocFile.GetSyntaxTreeAsync().ConfigureAwait(false);
            if (syntaxTree == null)
            {
                throw new InvalidOperationException("Unable to retrieve syntax tree from IAria2Client.cs.");
            }

            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            var root = syntaxTree.GetCompilationUnitRoot();

            // Find the IAria2Client interface declaration.
            var interfaceDeclaration = root.DescendantNodes()
                                    .OfType<InterfaceDeclarationSyntax>()
                                    .FirstOrDefault(i => i.Identifier.Text == "IAria2Client");
            if (interfaceDeclaration == null)
            {
                throw new InvalidOperationException("IAria2Client interface declaration not found in IAria2Client.cs.");
            }

            var ns = interfaceDeclaration.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
            if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient")
            {
                throw new InvalidOperationException("IAria2Client interface is not declared in the expected namespace 'Aria2.JsonRpcClient'.");
            }

            var interfaceSymbol = semanticModel.GetDeclaredSymbol(interfaceDeclaration);
            if (interfaceSymbol == null || interfaceSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                throw new InvalidOperationException("IAria2Client interface is not public.");
            }

            // Parse documentation from the interface's leading trivia.
            var docComment = XmlDocumentationHelper.GetDocumentationComment(interfaceDeclaration.GetLeadingTrivia(), semanticModel);

            var clientDocumentation = new ClientDocumentation
            {
                InterfaceName = interfaceDeclaration.Identifier.Text,
                SummaryFragments = docComment.SummaryFragments,
                SeeAlso = docComment.SeeAlso,
            };

            var methodDeclarations = interfaceDeclaration.Members.OfType<MethodDeclarationSyntax>();
            var methods = DocmentationHelper.GetMethods(methodDeclarations, semanticModel);

            clientDocumentation.Methods = methods;

            var eventDeclarations = interfaceDeclaration.Members.OfType<EventFieldDeclarationSyntax>();
            foreach (var eventDeclaration in eventDeclarations)
            {
                foreach (var variable in eventDeclaration.Declaration.Variables)
                {
                    if (semanticModel.GetDeclaredSymbol(variable) is not IEventSymbol eventSymbol || eventSymbol.DeclaredAccessibility != Accessibility.Public)
                    {
                        continue;
                    }

                    var eventDocComment = XmlDocumentationHelper.GetDocumentationComment(eventDeclaration.GetLeadingTrivia(), semanticModel);
                    var eventDocumentation = new EventDocumentation
                    {
                        Name = eventSymbol.Name,
                        SummaryFragments = eventDocComment.SummaryFragments,
                        SeeAlso = eventDocComment.SeeAlso,
                        Type = eventSymbol.Type.ToDisplayString(),
                    };

                    clientDocumentation.Events.Add(eventDocumentation);
                }
            }

            return clientDocumentation;
        }
    }
}
