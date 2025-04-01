namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds the overall documentation for the IAria2Client interface.
    /// </summary>
    public class ClientDocumentation
    {
        /// <summary>
        /// The interface name.
        /// </summary>
        public string InterfaceName { get; set; } = "";

        public List<DocumentationFragment> SummaryFragments { get; set; } = new();

        public string SeeAlso { get; set; } = "";

        /// <summary>
        /// Documentation for each public method in the interface.
        /// </summary>
        public List<MethodDocumentation> Methods { get; set; } = new();

        /// <summary>
        /// Documentation for each public event in the interface.
        /// </summary>
        public List<EventDocumentation> Events { get; set; } = new();
    }
}
