namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for a parameter.
    /// </summary>
    public class ParameterDetails
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public List<DocumentationFragment> DocumentationFragments { get; set; } = new();

        /// <summary>
        /// Indicates whether the parameter is optional (i.e. has an explicit default value).
        /// </summary>
        public bool IsOptional { get; set; }

        /// <summary>
        /// The default value as a string, if one is provided.
        /// </summary>
        public string? DefaultValue { get; set; }
    }
}
