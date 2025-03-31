using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDocumentationGenerator.Models
{
    public class ExceptionDocumentation
    {
        public string Type { get; set; } = "";

        public List<DocumentationFragment> Description { get; set; } = new();
    }
}
