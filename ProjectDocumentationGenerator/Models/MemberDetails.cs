using System.Collections.Generic;

namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for a member (method, constructor, etc.), including inline fragments.
    /// </summary>
    public class MemberDetails
    {
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();
        public List<ParameterDetails> Parameters { get; set; } = new();
        public List<DocumentationFragment> ReturnsFragments { get; set; } = new();
        public string ReturnType { get; set; } = "";
        public string SeeAlso { get; set; } = "";
    }
}
