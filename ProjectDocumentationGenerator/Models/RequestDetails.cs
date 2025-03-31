namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds the complete information for a request record including its name, the record documentation,
    /// the source document name, and the list of constructors.
    /// </summary>
    public class RequestDetails
    {
        public string Name { get; set; } = "";
        public RecordDetails Documentation { get; set; } = new();
        public List<ConstructorDetails> Constructors { get; set; } = new();
    }
}
