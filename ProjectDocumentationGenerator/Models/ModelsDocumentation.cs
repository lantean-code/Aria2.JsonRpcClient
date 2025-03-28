namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds the overall documentation for models.
    /// </summary>
    public class ModelsDocumentation
    {
        public List<RecordDetails> Records { get; set; } = new();
        public List<EnumDocumentation> Enums { get; set; } = new();
    }
}
