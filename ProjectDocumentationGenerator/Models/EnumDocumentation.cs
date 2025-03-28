using System.Collections.Generic;

namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for an enum type.
    /// </summary>
    public class EnumDocumentation
    {
        /// <summary>
        /// The enum's name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The enum summary as inline documentation fragments.
        /// </summary>
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();

        /// <summary>
        /// The documentation for each enum member.
        /// </summary>
        public List<EnumMemberDocumentation> Members { get; set; } = new();
    }
}
