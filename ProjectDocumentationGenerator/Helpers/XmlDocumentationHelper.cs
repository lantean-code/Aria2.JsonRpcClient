using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Helpers
{
    public static class XmlDocumentationHelper
    {
        /// <summary>
        /// Parses XML documentation from the provided SyntaxTriviaList into a DocumentationComment.
        /// This method processes the root elements: summary, param, returns, seealso and exception.
        /// If an <inheritdoc> element is present, it returns an empty DocumentationComment.
        /// </summary>
        public static DocumentationComment GetDocumentationComment(SyntaxTriviaList trivia, SemanticModel semanticModel)
        {
            var docComment = new DocumentationComment();
            var localDocComment = trivia.Select(t => t.GetStructure())
                                        .OfType<DocumentationCommentTriviaSyntax>()
                                        .FirstOrDefault();
            if (localDocComment == null)
            {
                return docComment;
            }

            // Check for an <inheritdoc> element among root elements.
            var inheritdocElement = localDocComment.ChildNodes()
                .OfType<XmlEmptyElementSyntax>()
                .FirstOrDefault(e => e.Name.ToString() == "inheritdoc");
            if (inheritdocElement != null)
            {
                var hasCref = inheritdocElement.Attributes.Any(attr => attr.Name.LocalName.ValueText.Equals("cref", StringComparison.OrdinalIgnoreCase));
                if (hasCref)
                {
                    return docComment;
                }

                var docTrivia = trivia.FirstOrDefault(t => t.HasStructure && t.GetStructure() is DocumentationCommentTriviaSyntax);
                if (docTrivia == default)
                {
                    return docComment;
                }

                // With an <inheritdoc> without a cref, try to retrieve the base declaration's documentation.
                // Assume the parent of the local documentation comment is the declaration node.
                var parent = docTrivia.Token.Parent;
                if (parent != null)
                {
                    var symbol = semanticModel.GetDeclaredSymbol(parent);
                    if (symbol != null)
                    {
                        ISymbol? baseSymbol = null;
                        if (symbol is IMethodSymbol methodSymbol)
                        {
                            baseSymbol = methodSymbol.OverriddenMethod;
                        }
                        else if (symbol is IPropertySymbol propertySymbol)
                        {
                            // For properties, first try the overridden property.
                            baseSymbol = propertySymbol.OverriddenProperty;
                            if (baseSymbol == null)
                            {
                                // For a 'new' property, search the base type(s) for a property with the same name.
                                var baseType = propertySymbol.ContainingType.BaseType;
                                while (baseType != null && baseSymbol == null)
                                {
                                    baseSymbol = baseType.GetMembers(propertySymbol.Name)
                                                         .OfType<IPropertySymbol>()
                                                         .FirstOrDefault();
                                    baseType = baseType.BaseType;
                                }
                            }
                        }
                        else if (symbol is INamedTypeSymbol typeSymbol)
                        {
                            baseSymbol = typeSymbol.BaseType;
                        }

                        if (baseSymbol != null)
                        {
                            // Get the syntax for the base member.
                            var baseDeclRef = baseSymbol.DeclaringSyntaxReferences.FirstOrDefault();
                            if (baseDeclRef != null)
                            {
                                var baseNode = baseDeclRef.GetSyntax();
                                // Assume the base member is a member declaration whose leading trivia includes the documentation.
                                if (baseNode is MemberDeclarationSyntax memberDeclaration)
                                {
                                    return GetDocumentationComment(memberDeclaration.GetLeadingTrivia(), semanticModel);
                                }
                            }
                        }
                    }
                }
            }

            // Process <summary>
            var summaryElement = localDocComment.ChildNodes()
                                                .OfType<XmlElementSyntax>()
                                                .FirstOrDefault(e => e.StartTag.Name.ToString() == "summary");
            if (summaryElement != null)
            {
                docComment.SummaryFragments = DocumentationFragmentHelper.ExtractFragmentsFromXmlElement(summaryElement);
            }

            // Process <param> elements.
            var paramElements = localDocComment.ChildNodes()
                                               .OfType<XmlElementSyntax>()
                                               .Where(e => e.StartTag.Name.ToString() == "param");
            foreach (var paramElement in paramElements)
            {
                var nameAttr = paramElement.StartTag.Attributes
                                    .OfType<XmlNameAttributeSyntax>()
                                    .FirstOrDefault(a => a.Name.ToString() == "name");
                if (nameAttr != null)
                {
                    var fragments = DocumentationFragmentHelper.ExtractFragmentsFromXmlElement(paramElement);
                    docComment.ParameterDocumentation.Add(new ParameterDocumentation
                    {
                        Name = nameAttr.Identifier.Identifier.ValueText,
                        DocumentationFragments = fragments
                    });
                }
            }

            // Process <returns>
            var returnsElement = localDocComment.ChildNodes()
                                                .OfType<XmlElementSyntax>()
                                                .FirstOrDefault(e => e.StartTag.Name.ToString() == "returns");
            if (returnsElement != null)
            {
                docComment.ReturnsFragments = DocumentationFragmentHelper.ExtractFragmentsFromXmlElement(returnsElement);
            }

            // Process <seealso>
            var seealsoElement = localDocComment.ChildNodes()
                                                .OfType<XmlEmptyElementSyntax>()
                                                .FirstOrDefault(e => e.Name.ToString() == "seealso");
            if (seealsoElement != null)
            {
                var hrefAttr = seealsoElement.Attributes.OfType<XmlTextAttributeSyntax>().FirstOrDefault(t => t.Name.LocalName.Text == "href");
                if (hrefAttr != null)
                {
                    var hrefValue = string.Concat(hrefAttr.TextTokens.Select(t => t.ValueText)).Trim();
                    docComment.SeeAlso = hrefValue;
                }
            }

            var exceptionElement = localDocComment.ChildNodes()
                                                  .OfType<XmlElementSyntax>()
                                                  .FirstOrDefault(e => e.StartTag.Name.ToString() == "exception");
            if (exceptionElement != null)
            {
                var exceptionDocumentation = new ExceptionDocumentation();
                var fragments = DocumentationFragmentHelper.ExtractFragmentsFromXmlElement(exceptionElement);
                exceptionDocumentation.Description = fragments;
                var crefAttribute = exceptionElement.StartTag.Attributes.OfType<XmlCrefAttributeSyntax>().FirstOrDefault();
                if (crefAttribute != null)
                {
                    if (crefAttribute.Cref is NameMemberCrefSyntax nameMemberCref)
                    {
                        exceptionDocumentation.Type = nameMemberCref.Name.ToFullString();
                    }
                    else
                    {
                        exceptionDocumentation.Type = crefAttribute.Cref.ToFullString();
                    }
                }

                docComment.Exception = exceptionDocumentation;
            }
            return docComment;
        }
    }
}
