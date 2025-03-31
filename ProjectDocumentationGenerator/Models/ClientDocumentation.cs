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

        /// <summary>
        /// Documentation for the interface itself.
        /// </summary>
        public MemberDetails Documentation { get; set; } = new();

        /// <summary>
        /// Documentation for each public method in the interface.
        /// </summary>
        public List<MethodDocumentation> Methods { get; set; } = new();
    }
}
