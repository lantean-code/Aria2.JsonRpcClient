namespace ProjectDocumentationGenerator.Models
{
    public class ExceptionDocumentation
    {
        public string Type { get; set; } = "";

        public List<DocumentationFragment> Description { get; set; } = new();
    }
}
