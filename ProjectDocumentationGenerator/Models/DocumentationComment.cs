namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Represents the XML documentation comment for a member or type.
    /// This includes the root elements: summary, parameters, returns, and seealso.
    /// </summary>
    public class DocumentationComment
    {
        /// <summary>
        /// The contents of the <c>&lt;summary&gt;</c> element, parsed into fragments.
        /// </summary>
        public List<DocumentationFragment> SummaryFragments { get; set; } = new List<DocumentationFragment>();

        /// <summary>
        /// The documentation for each parameter (from <c>&lt;param&gt;</c> elements).
        /// </summary>
        public List<ParameterDocumentation> ParameterDocumentation { get; set; } = new List<ParameterDocumentation>();

        /// <summary>
        /// The contents of the <c>&lt;returns&gt;</c> element, parsed into fragments.
        /// </summary>
        public List<DocumentationFragment> ReturnsFragments { get; set; } = new List<DocumentationFragment>();

        /// <summary>
        /// The value of the <c>&lt;seealso&gt;</c> element (if present).
        /// </summary>
        public string SeeAlso { get; set; } = "";
    }
}
