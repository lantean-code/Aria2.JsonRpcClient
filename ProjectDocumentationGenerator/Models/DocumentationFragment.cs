namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Represents an inline piece of documentation text.
    /// </summary>
    public abstract record DocumentationFragment;

    /// <summary>
    /// A simple text fragment.
    /// </summary>
    public record TextFragment(string Text) : DocumentationFragment;

    /// <summary>
    /// Represents a cref reference within a summary. The <paramref name="Cref"/>
    /// is the original reference (e.g. "IAria2Client.AddMetalink") and <paramref name="DisplayText"/>
    /// is the text to display for the link.
    /// </summary>
    public record CrefFragment(string Cref, string DisplayText) : DocumentationFragment;

    /// <summary>
    /// Represents a parameter reference (from a <paramref> element) within documentation.
    /// </summary>
    public record ParamRefFragment(string ParameterName) : DocumentationFragment;

    /// <summary>
    /// Represents an external link defined via a <see> element with an href attribute.
    /// </summary>
    public record HrefFragment(string Href, string DisplayText) : DocumentationFragment;
}
