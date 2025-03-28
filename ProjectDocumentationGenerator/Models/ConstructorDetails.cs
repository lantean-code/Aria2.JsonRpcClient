namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds information about a constructor including its signature and full documentation.
    /// </summary>
    public class ConstructorDetails
    {
        public string Signature { get; set; } = "";
        public MemberDetails Documentation { get; set; } = new();
    }
}
