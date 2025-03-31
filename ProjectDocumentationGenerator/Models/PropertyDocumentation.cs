namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation details for a record property.
    /// </summary>
    public class PropertyDocumentation
    {
        /// <summary>
        /// The property name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The property's type (as a string).
        /// </summary>
        public string Type { get; set; } = "";

        /// <summary>
        /// The JSON property name from the JsonPropertyName attribute, if specified.
        /// </summary>
        public string? JsonPropertyName { get; set; }

        public bool IsStatic { get; set; }

        /// <summary>
        /// The property summary, stored as inline documentation fragments.
        /// </summary>
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();
        public string SeeAlso { get; set; } = "";
    }
}
