using System.Text;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator
{
    public class MarkdownGenerator
    {
        private readonly Dictionary<string, string> _modelTypeNames;
        private readonly TemplateEngine _templateEngine;

        /// <summary>
        /// Creates a new MarkdownGenerator.
        /// modelTypeNames should contain the simple names of types (e.g. "Aria2DownloadOptions")
        /// for which a link should be generated.
        /// A TemplateEngine is provided that already includes default variables.
        /// </summary>
        public MarkdownGenerator(string outputDirectory, Dictionary<string, string> modelTypeNames, TemplateEngine templateEngine)
        {
            OutputDirectory = outputDirectory;
            _modelTypeNames = modelTypeNames;
            _templateEngine = templateEngine;
            Directory.CreateDirectory(OutputDirectory);
        }

        public string OutputDirectory { get; }

        /// <summary>
        /// Generates a Markdown file for the client interface.
        /// </summary>
        public void GenerateClientMarkdown(ClientDocumentation clientDoc)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# {clientDoc.InterfaceName} Interface");
            sb.AppendLine();
            sb.AppendLine("## Overview");
            sb.AppendLine();
            sb.AppendLine(RenderFragments(clientDoc.SummaryFragments));
            if (!string.IsNullOrWhiteSpace(clientDoc.SeeAlso))
            {
                sb.AppendLine();
                sb.AppendLine($"> [{clientDoc.SeeAlso}]({clientDoc.SeeAlso})");
            }
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
            RenderMethods(clientDoc.Methods, sb);
            RenderEvents(clientDoc.Events, sb);
            var content = sb.ToString();
            // Apply the header and footer via the template engine.
            var fullContent = _templateEngine.ApplyTemplate(content);
            var filePath = Path.Combine(OutputDirectory, "client.md");
            File.WriteAllText(filePath, fullContent);
        }

        /// <summary>
        /// Generates Markdown files for each model (records and enums) and an index page listing them.
        /// Each model page includes a "<- Models Index" link immediately before the Overview header.
        /// Separate tables for models and enums are generated in the index.
        /// </summary>
        public void GenerateModelsMarkdown(ModelsDocumentation modelsDoc)
        {
            var recordIndexEntries = new List<(string ModelLink, string Summary)>();
            var enumIndexEntries = new List<(string ModelLink, string Summary)>();

            // Process record models.
            foreach (var record in modelsDoc.Records)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# {record.Name} Model {(record.IsAbstract ? "`abstract`" : "")}");
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();

                RenderRecord(record, sb, "model_");

                var fileName = $"model_{record.Name}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = record.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                recordIndexEntries.Add(($"[{record.Name}]({fileName})", shortSummary));
            }

            // Process enum models.
            foreach (var en in modelsDoc.Enums)
            {
                var sb = new StringBuilder();
                RenderEnum(en, sb);
                var fileName = $"model_{en.Name}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = en.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                enumIndexEntries.Add(($"[{en.Name}]({fileName})", shortSummary));
            }

            // Generate the models index page with separate tables for records and enums.
            var indexSb = new StringBuilder();
            indexSb.AppendLine("# Models");
            indexSb.AppendLine();

            // Table for record models.
            indexSb.AppendLine("## Models");
            indexSb.AppendLine();
            indexSb.AppendLine("| Model Type | Summary |");
            indexSb.AppendLine("|------------|---------|");
            foreach (var entry in recordIndexEntries.OrderBy(e => e.ModelLink))
            {
                indexSb.AppendLine($"| {entry.ModelLink} | {entry.Summary} |");
            }
            indexSb.AppendLine();

            // Table for enum models.
            indexSb.AppendLine("## Enums");
            indexSb.AppendLine();
            indexSb.AppendLine("| Enum Type | Summary |");
            indexSb.AppendLine("|-----------|---------|");
            foreach (var entry in enumIndexEntries.OrderBy(e => e.ModelLink))
            {
                indexSb.AppendLine($"| {entry.ModelLink} | {entry.Summary} |");
            }
            var indexContent = indexSb.ToString();
            var fullIndex = _templateEngine.ApplyTemplate(indexContent);
            File.WriteAllText(Path.Combine(OutputDirectory, "models.md"), fullIndex);
        }

        private static void RenderEnum(EnumDocumentation en, StringBuilder sb)
        {
            sb.AppendLine($"# {en.Name} Enum");
            sb.AppendLine();
            sb.AppendLine("## Overview");
            sb.AppendLine();
            var summaryText = RenderFragments(en.SummaryFragments);
            sb.AppendLine(summaryText);
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
            sb.AppendLine("## Members");
            foreach (var member in en.Members)
            {
                var memberSummary = RenderFragments(member.SummaryFragments);
                sb.AppendLine($"#### `{member.Name}`");
                sb.AppendLine(memberSummary);
                if (!string.IsNullOrWhiteSpace(member.JsonValue))
                {
                    sb.AppendLine($"> JSON value: `{member.JsonValue}`");
                }
            }
            sb.AppendLine();
        }

        /// <summary>
        /// Generates Markdown files for each record and an index page listing them.
        /// Each record page includes a "<- Records Index" link immediately before the Overview header.
        /// Separate tables for models and enums are generated in the index.
        /// </summary>
        public void GenerateOthersMarkdown(OthersDocumentation othersDoc, string indexPath, string examplesPath)
        {
            var recordIndexEntries = new List<(string ModelLink, string Summary)>();

            // Process record models.
            foreach (var record in othersDoc.Records)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# {record.Name}{RenderTypeParameter(record.TypeParameters)}{(record.IsAbstract ? " `abstract`" : "")}");
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();

                RenderRecord(record, sb);

                var recordName = $"{record.Name}{string.Join("", record.TypeParameters ?? [])}";
                var fileName = $"{recordName}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = record.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                recordIndexEntries.Add(($"[{recordName}]({fileName})", shortSummary));
            }

            foreach (var @class in othersDoc.Classes)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# {@class.Name}{RenderTypeParameter(@class.TypeParameters)}{(@class.IsAbstract ? " `abstract`" : "")}");
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();

                RenderClass(@class, sb);

                var className = $"{@class.Name}{string.Join("", @class.TypeParameters ?? [])}";
                var fileName = $"{className}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = @class.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                recordIndexEntries.Add(($"[{className}]({fileName})", shortSummary));
            }

            foreach (var @enum in othersDoc.Enums)
            {
                var sb = new StringBuilder();
                RenderEnum(@enum, sb);
                var fileName = $"{@enum.Name}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = @enum.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                recordIndexEntries.Add(($"[{@enum.Name}]({fileName})", shortSummary));
            }

            // Generate the models index page with separate tables for records and enums.
            var indexSb = new StringBuilder(File.ReadAllText(indexPath));
            indexSb.AppendLine();

            // Table for record models.
            indexSb.AppendLine("## Others");
            indexSb.AppendLine();
            indexSb.AppendLine("| Type | Summary |");
            indexSb.AppendLine("|------------|---------|");
            foreach (var entry in recordIndexEntries.OrderBy(e => e.ModelLink))
            {
                indexSb.AppendLine($"| {entry.ModelLink} | {entry.Summary} |");
            }
            indexSb.AppendLine();

            var indexContent = indexSb.ToString();
            var fullIndex = _templateEngine.ApplyTemplate(indexContent);
            File.WriteAllText(Path.Combine(OutputDirectory, "index.md"), fullIndex);

            var examplesDb = new StringBuilder(File.ReadAllText(examplesPath));
            var examplesContent = examplesDb.ToString();
            var fullExamples = _templateEngine.ApplyTemplate(examplesContent);
            File.WriteAllText(Path.Combine(OutputDirectory, "examples.md"), fullExamples);
        }

        /// <summary>
        /// Generates Markdown files for each request record and an index page listing them.
        /// Each request page includes a "<- Requests Index" link immediately before the Overview header.
        /// </summary>
        public void GenerateRequestsMarkdown(IEnumerable<RequestDetails> requests)
        {
            var indexEntries = new List<(string RequestLink, string Summary)>();

            foreach (var request in requests)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# {request.Name}");
                sb.AppendLine();
                sb.AppendLine("## Overview");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(request.Documentation.SummaryFragments, null, "request_"));
                if (!string.IsNullOrWhiteSpace(request.Documentation.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"> [{request.Documentation.SeeAlso}]({request.Documentation.SeeAlso})");
                }
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();

                RenderConstructors(request.Constructors, sb);

                var fileName = $"request_{request.Name}.md";
                var pageContent = sb.ToString();
                var fullPage = _templateEngine.ApplyTemplate(pageContent);
                File.WriteAllText(Path.Combine(OutputDirectory, fileName), fullPage);

                var shortSummary = request.Documentation.SummaryFragments.OfType<TextFragment>().FirstOrDefault()?.Text ?? "";
                indexEntries.Add(($"[{request.Name}]({fileName})", shortSummary));
            }

            // Generate the requests index page as a Markdown table.
            var indexSb = new StringBuilder();
            indexSb.AppendLine("# Requests");
            indexSb.AppendLine();
            indexSb.AppendLine("The following requests are available:");
            indexSb.AppendLine();
            indexSb.AppendLine("| Request | Summary |");
            indexSb.AppendLine("|---------|---------|");
            foreach (var entry in indexEntries.OrderBy(e => e.RequestLink))
            {
                indexSb.AppendLine($"| {entry.RequestLink} | {entry.Summary} |");
            }
            var indexContent = indexSb.ToString();
            var fullIndex = _templateEngine.ApplyTemplate(indexContent);
            File.WriteAllText(Path.Combine(OutputDirectory, "requests.md"), fullIndex);
        }

        private static string RenderTypeParameter(List<string>? typeParameters)
        {
            if (typeParameters is null || typeParameters.Count == 0)
            {
                return "";
            }

            var x = string.Join(",", typeParameters);

            return $"\\<{x}\\>";
        }

        private static string LinkifySignature(string signature)
        {
            var result = new StringBuilder(signature.Length);
            foreach (var c in signature)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(c);
                }
                else
                {
                    result.Append('_');
                }
            }
            return result.ToString();
        }

        private void RenderConstructors(List<ConstructorDetails> constructors, StringBuilder sb)
        {
            if (constructors.Count == 0)
            {
                return;
            }
            sb.AppendLine("## Constructors");
            foreach (var constructor in constructors)
            {
                sb.AppendLine($"#### `{constructor.Signature}`");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(constructor.Documentation.SummaryFragments, constructor.Documentation.Parameters.Select(p => LinkifySignature(constructor.Signature) + p.Name)));
                if (!string.IsNullOrWhiteSpace(constructor.Documentation.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"> [{constructor.Documentation.SeeAlso}]({constructor.Documentation.SeeAlso})");
                }
                if (constructor.Documentation.Parameters.Count != 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("**Parameters:**");
                    foreach (var param in constructor.Documentation.Parameters)
                    {
                        RenderBookmark(LinkifySignature(constructor.Signature) + param.Name, sb);
                        var renderedType = RenderParameterType(param.Type);
                        var optionalInfo = param.IsOptional ? $" (optional, default: {param.DefaultValue})" : "";
                        sb.AppendLine($"- `{param.Name}` ({renderedType}{optionalInfo}): {RenderFragments(param.DocumentationFragments)}");
                    }
                }
                if (constructor.Documentation.ReturnsFragments.Count != 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("**Returns:**");
                    sb.AppendLine();
                    sb.AppendLine(RenderFragments(constructor.Documentation.ReturnsFragments, null, "model_"));
                }
                if (constructor.Documentation.Exception is not null)
                {
                    sb.AppendLine();
                    sb.AppendLine("**Throws:**");
                    sb.AppendLine();
                    sb.AppendLine(RenderParameterType(constructor.Documentation.Exception.Type));
                    sb.AppendLine(RenderFragments(constructor.Documentation.Exception.Description));
                }
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();
            }
            sb.AppendLine();
        }

        /// <summary>
        /// Converts a list of DocumentationFragment objects into a Markdown string.
        /// Optionally uses current property names for local cref/paramref bookmark links,
        /// and an optional modelLinkPrefix for type links.
        /// </summary>
        private static string RenderFragments(
    IEnumerable<DocumentationFragment> fragments,
    IEnumerable<string>? currentPropertyNames = null,
    string? modelLinkPrefix = null)
        {
            var propNames = currentPropertyNames != null
                ? new HashSet<string>(currentPropertyNames, StringComparer.OrdinalIgnoreCase)
                : null;

            var sb = new StringBuilder();
            foreach (var fragment in fragments)
            {
                switch (fragment)
                {
                    case TextFragment tf:
                        sb.Append(tf.Text);
                        break;
                    case CrefFragment cf:
                        var crefValue = cf.Cref.Replace("?", "").Trim();
                        if (crefValue.StartsWith("IAria2Client"))
                        {
                            sb.Append($"[{cf.DisplayText}](client.md)");
                        }
                        else
                        {
                            if (propNames != null && propNames.Contains(cf.DisplayText))
                            {
                                sb.Append($"[{cf.DisplayText}](#{cf.DisplayText})");
                            }
                            else
                            {
                                var parts = crefValue.Split('.');
                                var simpleName = parts[^1].Trim();
                                var prefix = modelLinkPrefix ?? "";
                                sb.Append($"[{cf.DisplayText}]({prefix}{simpleName}.md)");
                            }
                        }
                        break;
                    case ParamRefFragment prf:
                        if (propNames != null && propNames.Contains(prf.ParameterName))
                        {
                            sb.Append($"[{prf.ParameterName}](#{prf.ParameterName})");
                        }
                        else if (propNames != null && propNames.Any(i => i.EndsWith(prf.ParameterName)))
                        {
                            var linkName = propNames.First(p => p.EndsWith(prf.ParameterName));
                            sb.Append($"[{prf.ParameterName}](#{linkName})");
                        }
                        else
                        {
                            sb.Append($"`{prf.ParameterName}`");
                        }
                        break;
                    case HrefFragment hf:
                        sb.Append($"[{hf.DisplayText}]({hf.Href})");
                        break;
                }
            }
            // Trim leading whitespace on each line.
            var lines = sb.ToString()
                          .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                          .Select(line => line.TrimStart());
            return string.Join(Environment.NewLine, lines);
        }

        private void RenderMethods(List<MethodDocumentation> methods, StringBuilder sb)
        {
            if (methods.Count == 0)
            {
                return;
            }
            sb.AppendLine("## Methods");
            foreach (var method in methods.Where(m => !m.Documentation.IsStatic))
            {
                RenderMethod(method, sb);
            }
            foreach (var method in methods.Where(m => m.Documentation.IsStatic))
            {
                RenderMethod(method, sb);
            }
            sb.AppendLine();
        }

        private void RenderEvents(List<EventDocumentation> events, StringBuilder sb)
        {
            if (events.Count == 0)
            {
                return;
            }
            sb.AppendLine("## Events");
            foreach (var @event in events)
            {
                sb.AppendLine($"### {@event.Name}");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(@event.SummaryFragments));
                sb.AppendLine();
                if (!string.IsNullOrWhiteSpace(@event.SeeAlso))
                {
                    sb.AppendLine($"> [{@event.SeeAlso}]({@event.SeeAlso})");
                    sb.AppendLine();
                }
                sb.AppendLine();
                sb.AppendLine("**Callback:**");
                var renderedType = RenderParameterType(@event.Type);
                sb.AppendLine(renderedType);
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();
            }
            sb.AppendLine();
        }

        private static void RenderBookmark(string id, StringBuilder sb)
        {
            sb.AppendLine($"<a id=\"{id}\"></a>");
        }

        private void RenderMethod(MethodDocumentation method, StringBuilder sb)
        {
            RenderBookmark(method.SimpleSignature, sb);
            sb.AppendLine($"### {method.Name}");
            sb.AppendLine();
            sb.AppendLine(RenderFragments(method.Documentation.SummaryFragments, method.Documentation.Parameters.Select(p => LinkifySignature(method.Signature + p.Name))));
            sb.AppendLine();
            if (!string.IsNullOrWhiteSpace(method.Documentation.SeeAlso))
            {
                sb.AppendLine($"> [{method.Documentation.SeeAlso}]({method.Documentation.SeeAlso})");
                sb.AppendLine();
            }
            if (method.Documentation.IsStatic)
            {
                sb.AppendLine($"**Signature:** `static` `{method.Signature}`");
            }
            else
            {
                sb.AppendLine($"**Signature:** `{method.Signature}`");
            }
            sb.AppendLine();
            if (method.Documentation.Parameters.Count != 0)
            {
                sb.AppendLine();
                sb.AppendLine("**Parameters:**");
                foreach (var param in method.Documentation.Parameters)
                {
                    RenderBookmark(LinkifySignature(method.Signature + param.Name), sb);
                    var renderedType = RenderParameterType(param.Type);
                    var optionalInfo = param.IsOptional ? $" (optional, default: {param.DefaultValue})" : "";
                    sb.AppendLine($"- `{param.Name}` ({renderedType}{optionalInfo}): {RenderFragments(param.DocumentationFragments)}");
                }
            }
            if (method.Documentation.ReturnsFragments.Count != 0)
            {
                sb.AppendLine();
                sb.AppendLine("**Returns:**");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(method.Documentation.ReturnsFragments, null, "model_"));
            }
            if (method.Documentation.Exception is not null)
            {
                sb.AppendLine();
                sb.AppendLine("**Throws:**");
                sb.AppendLine();
                sb.AppendLine(RenderParameterType(method.Documentation.Exception.Type));
                sb.AppendLine(RenderFragments(method.Documentation.Exception.Description));
            }
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
        }

        /// <summary>
        /// Renders a parameter type string. If the type is in our model set,
        /// it is rendered as a Markdown link using the provided modelLinkPrefix.
        /// </summary>
        private string RenderParameterType(string type)
        {
            if (type.StartsWith("System."))
            {
                return $"`{type}`";
            }
            var cleanType = type.Replace("?", "").Trim();
            var parts = cleanType.Split('.');
            var simpleType = parts[^1];
            if (_modelTypeNames.TryGetValue(simpleType, out var prefix))
            {
                return $"[`{simpleType}`]({prefix}{simpleType}.md)";
            }
            return $"`{simpleType}`";
        }

        private void RenderProperties(List<PropertyDocumentation> properties, StringBuilder sb, string? prefix = null)
        {
            if (properties.Count == 0)
            {
                return;
            }
            sb.AppendLine("## Properties");
            var propertyNames = properties.Select(p => p.Name);
            foreach (var prop in properties.Where(p => !p.IsStatic))
            {
                RenderProperty(prop, propertyNames, sb, prefix);
            }

            foreach (var prop in properties.Where(p => p.IsStatic))
            {
                RenderProperty(prop, propertyNames, sb, prefix);
            }

            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
        }

        private void RenderProperty(PropertyDocumentation property, IEnumerable<string> propertyNames, StringBuilder sb, string? prefix = null)
        {
            sb.AppendLine($"<a id=\"{property.Name}\"></a>");

            var renderedType = RenderParameterType(property.Type);
            sb.AppendLine($"#### {renderedType} {property.Name} {(property.IsStatic ? "[static]" : "")}");
            sb.AppendLine();
            var propSummary = RenderFragments(property.SummaryFragments, propertyNames, prefix);
            if (string.IsNullOrEmpty(propSummary))
            {
                sb.AppendLine($"> [{property.SeeAlso}]({property.SeeAlso})  ");
            }
            else
            {
                sb.AppendLine(propSummary);
                if (!string.IsNullOrEmpty(property.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"> [{property.SeeAlso}]({property.SeeAlso})  ");
                }
            }
            if (!string.IsNullOrWhiteSpace(property.JsonPropertyName))
            {
                sb.AppendLine($"> JSON key: `{property.JsonPropertyName}`");
            }
            sb.AppendLine();
        }

        private void RenderRecord(RecordDetails record, StringBuilder sb, string? prefix = null)
        {
            sb.AppendLine("## Overview");
            sb.AppendLine();
            var summaryText = RenderFragments(record.SummaryFragments, record.Properties.Select(p => p.Name), prefix);
            sb.AppendLine(summaryText);
            if (!string.IsNullOrWhiteSpace(record.SeeAlso))
            {
                sb.AppendLine();
                sb.AppendLine($"> [{record.SeeAlso}]({record.SeeAlso})");
            }
            if (!string.IsNullOrWhiteSpace(record.BaseTypeName))
            {
                var simpleBaseName = record.BaseTypeName!.Split('.')[^1].Trim();
                string baseLink;
                if (_modelTypeNames.TryGetValue(simpleBaseName, out var basePrefix))
                {
                    baseLink = $"[`{simpleBaseName}`]({basePrefix}{simpleBaseName}.md)";
                }
                else
                {
                    baseLink = $"`{simpleBaseName}`";
                }
                sb.AppendLine();
                sb.AppendLine($"**Inherits from:** {baseLink}");
            }
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();

            RenderConstructors(record.Constructors, sb);

            RenderMethods(record.Methods, sb);

            RenderProperties(record.Properties, sb, prefix);
        }

        private void RenderClass(ClassDetails @class, StringBuilder sb)
        {
            sb.AppendLine("## Overview");
            sb.AppendLine();
            var summaryText = RenderFragments(@class.SummaryFragments, @class.Properties.Select(p => p.Name));
            sb.AppendLine(summaryText);
            if (!string.IsNullOrWhiteSpace(@class.SeeAlso))
            {
                sb.AppendLine();
                sb.AppendLine($"> [{@class.SeeAlso}]({@class.SeeAlso})");
            }
            if (!string.IsNullOrWhiteSpace(@class.BaseTypeName))
            {
                var simpleBaseName = @class.BaseTypeName!.Split('.')[^1].Trim();
                string baseLink;
                if (_modelTypeNames.TryGetValue(simpleBaseName, out var basePrefix))
                {
                    baseLink = $"[`{simpleBaseName}`]({basePrefix}{simpleBaseName}.md)";
                }
                else
                {
                    baseLink = $"`{simpleBaseName}`";
                }
                sb.AppendLine();
                sb.AppendLine($"**Inherits from:** {baseLink}");
            }
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();

            RenderConstructors(@class.Constructors, sb);

            RenderMethods(@class.Methods, sb);

            RenderProperties(@class.Properties, sb);

            RenderConversionOperators(@class.ConversionOperators, sb);
        }

        private void RenderConversionOperators(List<MethodDocumentation> operators, StringBuilder sb)
        {
            if (operators.Count == 0)
            {
                return;
            }
            sb.AppendLine("## Conversion Operators");
            foreach (var @operator in operators)
            {
                sb.AppendLine("**Documentation:**");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(@operator.Documentation.SummaryFragments));
                if (@operator.Documentation.Parameters.Count != 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("**Parameters:**");
                    foreach (var param in @operator.Documentation.Parameters)
                    {
                        var renderedType = RenderParameterType(param.Type);
                        var optionalInfo = param.IsOptional ? $" (optional, default: {param.DefaultValue})" : "";
                        sb.AppendLine($"- `{param.Name}` ({renderedType}{optionalInfo}): {RenderFragments(param.DocumentationFragments)}");
                    }
                }
                if (@operator.Documentation.ReturnsFragments.Count != 0)
                {
                    sb.AppendLine();
                    sb.AppendLine("**Returns:**");
                    sb.AppendLine();
                    sb.AppendLine(RenderFragments(@operator.Documentation.ReturnsFragments, null, "models/"));
                }
                if (!string.IsNullOrWhiteSpace(@operator.Documentation.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"> [{@operator.Documentation.SeeAlso}]({@operator.Documentation.SeeAlso})");
                }
            }
            sb.AppendLine();
            sb.AppendLine("---");
            sb.AppendLine();
        }
    }
}
