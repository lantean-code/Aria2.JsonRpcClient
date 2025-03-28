using System.Collections.Generic;

namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for a single enum member.
    /// </summary>
    public class EnumMemberDocumentation
    {
        /// <summary>
        /// The enum member name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The member summary as inline documentation fragments.
        /// </summary>
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();

        /// <summary>
        /// Optionally, the value from a JsonStringEnumMemberName attribute.
        /// </summary>
        public string? JsonValue { get; set; }
    }
}
