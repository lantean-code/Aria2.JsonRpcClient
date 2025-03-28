namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Represents the documentation for a parameter from an XML documentation comment.
    /// </summary>
    public class ParameterDocumentation
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the documentation fragments for the parameter.
        /// These fragments represent the inner XML content of the corresponding <c>&lt;param&gt;</c> element.
        /// </summary>
        public List<DocumentationFragment> DocumentationFragments { get; set; } = new List<DocumentationFragment>();
    }
}
