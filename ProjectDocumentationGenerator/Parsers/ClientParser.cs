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
    public class ClientParser
    {
        /// <summary>
        /// Parses the public IAria2Client interface from the project.
        /// It obtains XML documentation from the interface declaration's leading trivia,
        /// converts it to a MemberDetails object, and processes each public method similarly.
        /// </summary>
        public async Task<ClientDocumentation> ParseClientInterfaceAsync(Project project, Compilation compilation)
        {
            // Locate the document "IAria2Client.cs"
            var clientDocFile = project.Documents.FirstOrDefault(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                Path.GetFileName(doc.FilePath)
                    .Equals("IAria2Client.cs", StringComparison.OrdinalIgnoreCase));
            if (clientDocFile == null)
                throw new InvalidOperationException("IAria2Client.cs file not found in the project.");

            var syntaxTree = await clientDocFile.GetSyntaxTreeAsync().ConfigureAwait(false);
            if (syntaxTree == null)
                throw new InvalidOperationException("Unable to retrieve syntax tree from IAria2Client.cs.");

            var semanticModel = compilation.GetSemanticModel(syntaxTree);
            var root = syntaxTree.GetCompilationUnitRoot();

            // Find the IAria2Client interface declaration.
            var interfaceDecl = root.DescendantNodes()
                                    .OfType<InterfaceDeclarationSyntax>()
                                    .FirstOrDefault(i => i.Identifier.Text == "IAria2Client");
            if (interfaceDecl == null)
                throw new InvalidOperationException("IAria2Client interface declaration not found in IAria2Client.cs.");

            var ns = interfaceDecl.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
            if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient")
                throw new InvalidOperationException("IAria2Client interface is not declared in the expected namespace 'Aria2.JsonRpcClient'.");

            var interfaceSymbol = semanticModel.GetDeclaredSymbol(interfaceDecl);
            if (interfaceSymbol == null || interfaceSymbol.DeclaredAccessibility != Accessibility.Public)
                throw new InvalidOperationException("IAria2Client interface is not public.");

            // Parse documentation from the interface's leading trivia.
            var docComment = XmlDocumentationHelper.GetDocumentationComment(interfaceDecl.GetLeadingTrivia(), semanticModel);

            var clientDocumentation = new ClientDocumentation
            {
                InterfaceName = interfaceDecl.Identifier.Text,
                Documentation = new MemberDetails
                {
                    SummaryFragments = docComment.SummaryFragments,
                    SeeAlso = docComment.SeeAlso,
                },
                Methods = new List<ClientMethodDocumentation>()
            };

            // Process each public method.
            foreach (var methodDecl in interfaceDecl.Members.OfType<MethodDeclarationSyntax>())
            {
                var methodSymbol = semanticModel.GetDeclaredSymbol(methodDecl) as IMethodSymbol;
                if (methodSymbol == null || methodSymbol.DeclaredAccessibility != Accessibility.Public)
                    continue;

                string signature = $"{methodSymbol.ReturnType.ToDisplayString()} {methodSymbol.Name}{methodDecl.ParameterList}";

                var methodDocComment = XmlDocumentationHelper.GetDocumentationComment(methodDecl.GetLeadingTrivia(), semanticModel);

                var memberDetails = new MemberDetails();
                memberDetails.SummaryFragments = methodDocComment.SummaryFragments;
                memberDetails.ReturnsFragments = methodDocComment.ReturnsFragments;
                memberDetails.SeeAlso = methodDocComment.SeeAlso;
                memberDetails.ReturnType = methodSymbol.ReturnType.Name;

                foreach (var param in methodSymbol.Parameters)
                {
                    var parameter = methodDocComment.ParameterDocumentation.Find(p => p.Name == param.Name);
                    memberDetails.Parameters.Add(new ParameterDetails
                    {
                        Name = param.Name,
                        DefaultValue = param.HasExplicitDefaultValue ? param.ExplicitDefaultValue?.ToString() ?? "null" : null,
                        DocumentationFragments = parameter?.DocumentationFragments ?? [],
                        IsOptional = param.IsOptional,
                        Type = param.Type.ToDisplayString(),
                    });
                }

                clientDocumentation.Methods.Add(new ClientMethodDocumentation
                {
                    Name = methodSymbol.Name,
                    Signature = signature,
                    Documentation = memberDetails
                });
            }

            return clientDocumentation;
        }
    }
}
