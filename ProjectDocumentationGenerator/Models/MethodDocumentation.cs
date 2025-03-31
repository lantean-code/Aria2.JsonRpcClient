namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for a single method in IAria2Client.
    /// </summary>
    public class MethodDocumentation
    {
        /// <summary>
        /// The method name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// A string representing the method's signature.
        /// </summary>
        public string Signature { get; set; } = "";

        /// <summary>
        /// A string representing the method's signature without return type.
        /// </summary>
        public string SimpleSignature { get; set; } = "";

        /// <summary>
        /// A string representing the method's signature without return type or parameter names.
        /// </summary>
        public string BasicSignature { get; set; } = "";

        /// <summary>
        /// Detailed XML documentation for the method.
        /// </summary>
        public MemberDetails Documentation { get; set; } = new();
    }
}
