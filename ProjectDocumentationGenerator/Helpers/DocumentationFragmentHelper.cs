using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Helpers
{
    public static class DocumentationFragmentHelper
    {
        /// <summary>
        /// Normalizes a text string by splitting it into lines, trimming only the leading whitespace on each line,
        /// and rejoining the lines with newline characters.
        /// </summary>
        private static string NormalizeText(string text)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (var i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimStart();
            }
            return string.Join(Environment.NewLine, lines);
        }

        /// <summary>
        /// Extracts documentation fragments from an XmlElementSyntax (the inner content of a root element such as <summary>).
        /// This method is used by XmlDocumentationHelper to break down a root element’s inner XML into fragments.
        /// </summary>
        public static List<DocumentationFragment> ExtractFragmentsFromXmlElement(XmlElementSyntax element)
        {
            var fragments = new List<DocumentationFragment>();
            foreach (var node in element.Content)
            {
                if (node is XmlTextSyntax textSyntax)
                {
                    // Skip leading tokens that are null, empty, or whitespace until a token with content is encountered.
                    var tokensToInclude = textSyntax.TextTokens.SkipWhile(token => string.IsNullOrWhiteSpace(token.ValueText));
                    foreach (var token in tokensToInclude)
                    {
                        var tokenText = token.ValueText;
                        if (!string.IsNullOrEmpty(tokenText))
                        {
                            fragments.Add(new TextFragment(tokenText));
                        }
                    }
                }
                else if (node is XmlEmptyElementSyntax emptyElement)
                {
                    fragments.AddRange(ExtractFragmentFromElement(ConvertToXmlElement(emptyElement)));
                }
                else if (node is XmlElementSyntax childElement)
                {
                    fragments.AddRange(ExtractFragmentFromElement(childElement));
                }
            }
            return fragments;
        }


        /// <summary>
        /// Converts an XmlEmptyElementSyntax into a full XmlElementSyntax so it can be processed uniformly.
        /// </summary>
        private static XmlElementSyntax ConvertToXmlElement(XmlEmptyElementSyntax emptyElement)
        {
            var startTag = SyntaxFactory.XmlElementStartTag(emptyElement.Name)
                                         .WithAttributes(emptyElement.Attributes);
            var endTag = SyntaxFactory.XmlElementEndTag(emptyElement.Name);
            return SyntaxFactory.XmlElement(startTag, SyntaxFactory.List<XmlNodeSyntax>(), endTag);
        }

        /// <summary>
        /// Extracts documentation fragments from an XmlElementSyntax that represents a special element
        /// (for example, a <paramref> or <see> element). For other elements, it recursively processes the content.
        /// </summary>
        private static List<DocumentationFragment> ExtractFragmentFromElement(XmlElementSyntax element)
        {
            var fragments = new List<DocumentationFragment>();
            var elementName = element.StartTag.Name.ToString();
            if (elementName == "paramref")
            {
                // For <paramref>, extract the "name" attribute.
                var nameAttr = element.StartTag.Attributes.OfType<XmlNameAttributeSyntax>().FirstOrDefault();
                if (nameAttr != null)
                {
                    fragments.Add(new ParamRefFragment(nameAttr.Identifier.Identifier.ValueText));
                }
            }
            else if (elementName == "see")
            {
                // First, check for an href attribute.
                var hrefAttr = element.StartTag.Attributes
                                       .OfType<XmlTextAttributeSyntax>()
                                       .FirstOrDefault(a => a.Name.LocalName.Text == "href");
                if (hrefAttr != null)
                {
                    // Concatenate the text tokens from the attribute to get the href value.
                    var hrefValue = string.Concat(hrefAttr.TextTokens.Select(t => t.ValueText)).Trim();
                    // Use element.Content (filtered for XmlTextSyntax) to get the inner display text.
                    var displayText = string.Concat(
                        element.Content.OfType<XmlTextSyntax>()
                               .SelectMany(ts => ts.TextTokens)
                               .Select(t => t.ValueText)
                    );
                    displayText = NormalizeText(displayText);
                    if (string.IsNullOrWhiteSpace(displayText))
                    {
                        displayText = hrefValue;
                    }
                    fragments.Add(new HrefFragment(hrefValue, displayText));
                }
                else
                {
                    // Fallback: check for a cref attribute.
                    var crefAttr = element.StartTag.Attributes.OfType<XmlCrefAttributeSyntax>().FirstOrDefault();
                    if (crefAttr != null)
                    {
                        fragments.Add(new CrefFragment(crefAttr.Cref.ToString(), crefAttr.Cref.ToString()));
                    }
                }
            }
            else
            {
                // For any other element, recursively process its content.
                fragments.AddRange(ExtractFragmentsFromXmlElement(element));
            }
            return fragments;
        }
    }
}
