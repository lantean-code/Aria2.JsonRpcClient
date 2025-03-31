namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds the overall documentation for non-model records.
    /// </summary>
    public class OthersDocumentation
    {
        public List<RecordDetails> Records { get; set; } = new();

        public List<ClassDetails> Classes { get; set; } = new();

        public List<EnumDocumentation> Enums { get; set; } = new();
    }
}
