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
                    var text = textSyntax.TextTokens.TrimStartAndEnd(token => token.ValueText);
                    foreach (var token in text)
                    {
                        fragments.Add(new TextFragment(token));
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

        private static IEnumerable<string> TrimStartAndEnd<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            var started = false;
            // Buffer to hold potential trailing null/whitespace items.
            var buffer = new List<string>();

            foreach (var tt in source)
            {
                var item = selector(tt);
                if (!started)
                {
                    // Skip leading null/whitespace until we find the first valid item.
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        started = true;
                        yield return item;
                    }
                }
                else
                {
                    // We're inside the trimmed segment.
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        // Flush any buffered items (they're not trailing).
                        foreach (var buffered in buffer)
                        {
                            yield return buffered;
                        }
                        buffer.Clear();
                        yield return item;
                    }
                    else
                    {
                        // Buffer the null/whitespace item in case it's interior.
                        buffer.Add(item);
                    }
                }
            }
            // Any items left in the buffer at the end are trailing and are not yielded.
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
