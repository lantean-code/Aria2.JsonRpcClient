namespace ProjectDocumentationGenerator.Models
{
    public class ClassDetails : RecordDetails
    {
        public List<MethodDocumentation> ConversionOperators { get; set; } = new();
    }
}
