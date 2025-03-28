using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Helpers
{
    public static class XmlDocumentationHelper
    {
        /// <summary>
        /// Parses XML documentation from the provided SyntaxTriviaList into a DocumentationComment.
        /// This method processes the root elements: summary, param, returns, and seealso.
        /// If an <inheritdoc> element is present, it returns an empty DocumentationComment.
        /// </summary>
        public static DocumentationComment GetDocumentationComment(SyntaxTriviaList trivia, SemanticModel semanticModel)
        {
            var docComment = new DocumentationComment();
            var localDocComment = trivia.Select(t => t.GetStructure())
                                        .OfType<DocumentationCommentTriviaSyntax>()
                                        .FirstOrDefault();
            if (localDocComment == null)
                return docComment;

            // Check for an <inheritdoc> element among root elements.
            var inheritdocElement = localDocComment.ChildNodes()
                .OfType<XmlEmptyElementSyntax>()
                .FirstOrDefault(e => e.Name.ToString() == "inheritdoc");
            if (inheritdocElement != null)
            {
                return docComment;
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
                                                .OfType<XmlElementSyntax>()
                                                .FirstOrDefault(e => e.StartTag.Name.ToString() == "seealso");
            if (seealsoElement != null)
            {
                var hrefAttr = seealsoElement.StartTag.Attributes
                                             .FirstOrDefault(a => a.ToString().StartsWith("href=", StringComparison.OrdinalIgnoreCase));
                if (hrefAttr != null)
                {
                    string hrefValue = hrefAttr.ToString().Substring("href=".Length).Trim('\"');
                    docComment.SeeAlso = hrefValue;
                }
            }
            return docComment;
        }
    }
}
