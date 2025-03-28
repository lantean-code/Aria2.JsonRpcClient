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
    public class ModelParser
    {
        /// <summary>
        /// Parses all public model types (records and enums) from the project.
        /// Only models in the "Aria2.JsonRpcClient.Models" namespace are processed.
        /// XML documentation is parsed from each model’s leading trivia (using XmlDocumentationHelper)
        /// and then converted inline into RecordDetails (for records) or EnumDocumentation (for enums).
        /// </summary>
        public async Task<ModelsDocumentation> ParseModelsAsync(Project project, Compilation compilation)
        {
            var modelsDoc = new ModelsDocumentation();
            var projectDir = !string.IsNullOrEmpty(project.FilePath)
                ? Path.GetDirectoryName(project.FilePath)
                : null;
            if (projectDir == null)
                throw new InvalidOperationException("Project.FilePath is not available.");

            var modelDocuments = project.Documents.Where(doc =>
                !string.IsNullOrEmpty(doc.FilePath) &&
                DocumentFolderFilter.IsInRootFolder(doc.FilePath, projectDir, "Models"));

            foreach (var document in modelDocuments)
            {
                var syntaxTree = await document.GetSyntaxTreeAsync().ConfigureAwait(false);
                if (syntaxTree == null)
                    continue;

                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var root = syntaxTree.GetCompilationUnitRoot();

                // Process public record declarations.
                var recordDeclarations = root.DescendantNodes().OfType<RecordDeclarationSyntax>();
                foreach (var record in recordDeclarations)
                {
                    var ns = record.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Models")
                        continue;

                    var recordSymbol = semanticModel.GetDeclaredSymbol(record) as INamedTypeSymbol;
                    if (recordSymbol == null || recordSymbol.DeclaredAccessibility != Accessibility.Public)
                        continue;

                    // Parse the record's documentation.
                    var docComment = XmlDocumentationHelper.GetDocumentationComment(record.GetLeadingTrivia(), semanticModel);
                    // Create a new RecordDetails object inline.
                    var recordDetails = new RecordDetails
                    {
                        Name = record.Identifier.Text,
                        SummaryFragments = docComment.SummaryFragments,
                        SeeAlso = docComment.SeeAlso
                    };

                    // If the record inherits from another type, store the base type name.
                    if (record.BaseList != null && record.BaseList.Types.Any())
                    {
                        recordDetails.BaseRecordName = record.BaseList.Types.First().Type.ToString();
                    }

                    // Process each property declared on the record.
                    var propDeclarations = record.Members.OfType<PropertyDeclarationSyntax>();
                    foreach (var prop in propDeclarations)
                    {
                        var propSymbol = semanticModel.GetDeclaredSymbol(prop) as IPropertySymbol;
                        if (propSymbol == null || propSymbol.DeclaredAccessibility != Accessibility.Public)
                            continue;

                        // Only include properties declared in this record.
                        bool isDeclaredHere = propSymbol.DeclaringSyntaxReferences.Any(r =>
                        {
                            var syntax = r.GetSyntax();
                            return syntax.Parent is RecordDeclarationSyntax parentRecord &&
                                   SymbolEqualityComparer.Default.Equals(semanticModel.GetDeclaredSymbol(parentRecord), recordSymbol);
                        });
                        if (!isDeclaredHere)
                            continue;

                        // Get the JSON property name if present.
                        string? jsonPropertyName = null;
                        var jsonAttr = propSymbol.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "JsonPropertyNameAttribute");
                        if (jsonAttr != null && jsonAttr.ConstructorArguments.Length > 0)
                        {
                            jsonPropertyName = jsonAttr.ConstructorArguments[0].Value as string;
                        }

                        // Parse the property's documentation.
                        var propDocComment = XmlDocumentationHelper.GetDocumentationComment(prop.GetLeadingTrivia(), semanticModel);
                        var propDetails = new PropertyDocumentation
                        {
                            Name = prop.Identifier.Text,
                            Type = propSymbol.Type.ToDisplayString(),
                            JsonPropertyName = jsonPropertyName,
                            SummaryFragments = propDocComment.SummaryFragments
                        };

                        recordDetails.Properties.Add(propDetails);
                    }

                    modelsDoc.Records.Add(recordDetails);
                }

                // Process public enum declarations.
                var enumDeclarations = root.DescendantNodes().OfType<EnumDeclarationSyntax>();
                foreach (var enumDecl in enumDeclarations)
                {
                    var ns = enumDecl.FirstAncestorOrSelf<NamespaceDeclarationSyntax>();
                    if (ns == null || ns.Name.ToString() != "Aria2.JsonRpcClient.Models")
                        continue;

                    var enumSymbol = semanticModel.GetDeclaredSymbol(enumDecl) as INamedTypeSymbol;
                    if (enumSymbol == null || enumSymbol.DeclaredAccessibility != Accessibility.Public)
                        continue;

                    // Parse the enum's documentation.
                    var docCommentEnum = XmlDocumentationHelper.GetDocumentationComment(enumDecl.GetLeadingTrivia(), semanticModel);
                    var enumDoc = new EnumDocumentation
                    {
                        Name = enumDecl.Identifier.Text,
                        SummaryFragments = docCommentEnum.SummaryFragments
                    };

                    // Process each enum member.
                    foreach (var member in enumDecl.Members)
                    {
                        var memberSymbol = semanticModel.GetDeclaredSymbol(member);
                        if (memberSymbol == null || memberSymbol.DeclaredAccessibility != Accessibility.Public)
                            continue;

                        var memberDocComment = XmlDocumentationHelper.GetDocumentationComment(member.GetLeadingTrivia(), semanticModel);
                        var memberDoc = new EnumMemberDocumentation
                        {
                            Name = member.Identifier.Text,
                            SummaryFragments = memberDocComment.SummaryFragments
                        };

                        // Extract the JSON value if available.
                        foreach (var attrList in member.AttributeLists)
                        {
                            foreach (var attr in attrList.Attributes)
                            {
                                var attrName = attr.Name.ToString();
                                if (attrName.Contains("JsonStringEnumMemberName"))
                                {
                                    if (attr.ArgumentList?.Arguments.Count > 0)
                                    {
                                        var argExpr = attr.ArgumentList.Arguments.First().Expression;
                                        if (argExpr is LiteralExpressionSyntax literal &&
                                            literal.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.StringLiteralExpression))
                                        {
                                            memberDoc.JsonValue = literal.Token.ValueText;
                                        }
                                    }
                                }
                            }
                        }
                        enumDoc.Members.Add(memberDoc);
                    }
                    modelsDoc.Enums.Add(enumDoc);
                }
            }

            return modelsDoc;
        }
    }
}
