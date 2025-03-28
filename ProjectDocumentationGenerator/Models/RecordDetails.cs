using System.Collections.Generic;

namespace ProjectDocumentationGenerator.Models
{
    /// <summary>
    /// Holds documentation for a record type.
    /// </summary>
    public class RecordDetails
    {
        /// <summary>
        /// The record's name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// The record summary, broken into inline fragments.
        /// </summary>
        public List<DocumentationFragment> SummaryFragments { get; set; } = new();

        /// <summary>
        /// See-also information.
        /// </summary>
        public string SeeAlso { get; set; } = "";

        /// <summary>
        /// If this record inherits from another record, the name of the base record.
        /// </summary>
        public string? BaseRecordName { get; set; }

        /// <summary>
        /// Documentation for each property in the record.
        /// </summary>
        public List<PropertyDocumentation> Properties { get; set; } = new();
    }
}
