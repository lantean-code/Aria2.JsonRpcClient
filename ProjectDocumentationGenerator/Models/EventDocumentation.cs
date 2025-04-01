namespace ProjectDocumentationGenerator.Models
{
    public class EventDocumentation
    {
        public string Name { get; set; } = "";
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();
        public string SeeAlso { get; set; } = "";
        public string Type { get; set; } = "";
    }
}
