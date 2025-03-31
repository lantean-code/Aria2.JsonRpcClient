namespace ProjectDocumentationGenerator
{
    public class TemplateEngine
    {
        private readonly string _headerTemplate;
        private readonly string _footerTemplate;
        private readonly Dictionary<string, string>? _variables;

        /// <summary>
        /// Creates a new TemplateEngine by loading the header and footer template from files.
        /// You can also modify this constructor to accept the template strings directly.
        /// </summary>
        public TemplateEngine(string headerTemplatePath, string footerTemplatePath, Dictionary<string, string>? variables = null)
        {
            if (!File.Exists(headerTemplatePath))
            {
                throw new FileNotFoundException("Header template file not found." + headerTemplatePath, headerTemplatePath);
            }

            if (!File.Exists(footerTemplatePath))
            {
                throw new FileNotFoundException("Footer template file not found." + footerTemplatePath, footerTemplatePath);
            }

            _headerTemplate = File.ReadAllText(headerTemplatePath);
            _footerTemplate = File.ReadAllText(footerTemplatePath);
            _variables = variables;
        }

        /// <summary>
        /// Applies the header and footer templates to the given page content.
        /// Optional variables can be provided for substitution in the templates.
        /// Placeholders in the templates are in the form of {{VariableName}}.
        /// </summary>
        public string ApplyTemplate(string pageContent, Dictionary<string, string>? variables = null)
        {
            var content = _headerTemplate + Environment.NewLine + pageContent + Environment.NewLine + _footerTemplate;
            content = ReplaceVariables(variables, content);
            return content;
        }

        private string ReplaceVariables(Dictionary<string, string>? variables, string content)
        {
            if (_variables is null && variables is null)
            {
                return content;
            }

            variables = (variables ?? []).Union(_variables ?? []).ToDictionary(d => d.Key, d => d.Value);

            foreach (var kvp in variables)
            {
                content = content.Replace($"{{{{{kvp.Key}}}}}", kvp.Value);
            }

            return content;
        }
    }
}
