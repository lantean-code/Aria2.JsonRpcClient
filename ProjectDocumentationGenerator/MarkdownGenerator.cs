using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Markdown
{
    public class MarkdownGenerator
    {
        public string OutputDirectory { get; }
        private readonly ISet<string> _modelTypeNames;

        /// <summary>
        /// Creates a new MarkdownGenerator.
        /// modelTypeNames should contain the simple names of types (e.g. "Aria2DownloadOptions")
        /// for which a link should be generated.
        /// </summary>
        public MarkdownGenerator(string outputDirectory, ISet<string> modelTypeNames)
        {
            OutputDirectory = outputDirectory;
            _modelTypeNames = modelTypeNames;
            Directory.CreateDirectory(OutputDirectory);
        }

        /// <summary>
        /// Converts a list of DocumentationFragment objects into a Markdown string.
        /// If currentPropertyNames is provided, any cref or paramref fragment that matches one of those names
        /// is rendered as a bookmark link.
        /// </summary>
        private string RenderFragments(
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
                        // Clean the cref value by removing nullable markers.
                        string crefValue = cf.Cref.Replace("?", "").Trim();
                        if (propNames != null && propNames.Contains(cf.DisplayText))
                        {
                            // Render as a bookmark link for a local property.
                            sb.Append($"[{cf.DisplayText}](#{cf.DisplayText})");
                        }
                        else
                        {
                            // Assume it's a type reference.
                            var parts = crefValue.Split('.');
                            string simpleName = parts.Last().Trim();
                            string prefix = modelLinkPrefix ?? "";
                            sb.Append($"[{cf.DisplayText}]({prefix}{simpleName}.md)");
                        }
                        break;
                    case ParamRefFragment prf:
                        if (propNames != null && propNames.Contains(prf.ParameterName))
                        {
                            sb.Append($"[{prf.ParameterName}](#{prf.ParameterName})");
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
            // Split the concatenated string by newlines and trim leading whitespace from each line.
            var lines = sb.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                            .Select(line => line.TrimStart());
            return string.Join(Environment.NewLine, lines);
        }


        /// <summary>
        /// Renders a parameter type string.
        /// If the type is in our model set, it is rendered as a Markdown link using the provided modelLinkPrefix.
        /// The type string is cleaned by removing namespaces and nullable markers.
        /// </summary>
        private string RenderParameterType(string type, string? modelLinkPrefix = null)
        {
            string cleanType = type.Replace("?", "").Trim();
            var parts = cleanType.Split('.');
            string simpleType = parts.Last();
            if (_modelTypeNames.Contains(simpleType))
            {
                string prefix = modelLinkPrefix ?? "";
                return $"[{simpleType}]({prefix}{simpleType}.md)";
            }
            return simpleType;
        }

        /// <summary>
        /// Generates a Markdown file for the client interface.
        /// </summary>
        public void GenerateClientMarkdown(ClientDocumentation clientDoc)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"# Interface: {clientDoc.InterfaceName}");
            sb.AppendLine();
            sb.AppendLine("## Overview");
            sb.AppendLine();
            sb.AppendLine(RenderFragments(clientDoc.Documentation.SummaryFragments));
            if (!string.IsNullOrWhiteSpace(clientDoc.Documentation.SeeAlso))
            {
                sb.AppendLine();
                sb.AppendLine($"**See Also:** {clientDoc.Documentation.SeeAlso}");
            }
            sb.AppendLine();
            sb.AppendLine("## Methods");
            foreach (var method in clientDoc.Methods)
            {
                sb.AppendLine($"### {method.Name}");
                sb.AppendLine();
                sb.AppendLine($"**Signature:** `{method.Signature}`");
                sb.AppendLine();
                sb.AppendLine("**Documentation:**");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(method.Documentation.SummaryFragments));
                if (method.Documentation.Parameters.Any())
                {
                    sb.AppendLine();
                    sb.AppendLine("**Parameters:**");
                    foreach (var param in method.Documentation.Parameters)
                    {
                        string renderedType = RenderParameterType(param.Type, "models/");
                        string optionalInfo = param.IsOptional ? $" (optional, default: {param.DefaultValue})" : "";
                        sb.AppendLine($"- `{param.Name}` ({renderedType}{optionalInfo}): {RenderFragments(param.DocumentationFragments)}");
                    }
                }
                if (method.Documentation.ReturnsFragments.Any())
                {
                    sb.AppendLine();
                    sb.AppendLine("**Returns:**");
                    sb.AppendLine();
                    sb.AppendLine(RenderFragments(method.Documentation.ReturnsFragments, null, "models/"));
                }
                // Optionally include SeeAlso section if present.
                if (!string.IsNullOrWhiteSpace(method.Documentation.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"**See Also:** {method.Documentation.SeeAlso}");
                }
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();
            }
            var filePath = Path.Combine(OutputDirectory, "client.md");
            File.WriteAllText(filePath, sb.ToString());
        }

        /// <summary>
        /// Generates Markdown files for each request record and an index file listing them.
        /// In request files (in docs/requests/), model links are generated with prefix "../models/".
        /// Also appends a "Back to Requests Index" link at the bottom of each request file.
        /// </summary>
        public void GenerateRequestsMarkdown(IEnumerable<RequestDetails> requests)
        {
            string requestsDir = Path.Combine(OutputDirectory, "requests");
            Directory.CreateDirectory(requestsDir);
            var indexEntries = new List<string>();

            foreach (var request in requests)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# Request: {request.Name}");
                sb.AppendLine();
                sb.AppendLine("## Overview");
                sb.AppendLine();
                sb.AppendLine(RenderFragments(request.Documentation.SummaryFragments));
                if (!string.IsNullOrWhiteSpace(request.Documentation.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"**See Also:** {request.Documentation.SeeAlso}");
                }
                sb.AppendLine();
                sb.AppendLine("## Constructors");
                foreach (var ctor in request.Constructors)
                {
                    sb.AppendLine($"### {ctor.Signature}");
                    sb.AppendLine();
                    sb.AppendLine("**Documentation:**");
                    sb.AppendLine();
                    sb.AppendLine(RenderFragments(ctor.Documentation.SummaryFragments));
                    if (ctor.Documentation.Parameters.Any())
                    {
                        sb.AppendLine();
                        sb.AppendLine("**Parameters:**");
                        foreach (var param in ctor.Documentation.Parameters)
                        {
                            string renderedType = RenderParameterType(param.Type, "../models/");
                            string optionalInfo = param.IsOptional ? $" (optional, default: {param.DefaultValue})" : "";
                            sb.AppendLine($"- `{param.Name}` ({renderedType}{optionalInfo}): {RenderFragments(param.DocumentationFragments)}");
                        }
                    }
                    if (ctor.Documentation.ReturnsFragments.Any())
                    {
                        sb.AppendLine();
                        sb.AppendLine("**Returns:**");
                        sb.AppendLine();
                        sb.AppendLine(RenderFragments(ctor.Documentation.ReturnsFragments));
                    }
                    if (!string.IsNullOrWhiteSpace(ctor.Documentation.SeeAlso))
                    {
                        sb.AppendLine();
                        sb.AppendLine($"**See Also:** {ctor.Documentation.SeeAlso}");
                    }
                    sb.AppendLine();
                    sb.AppendLine("---");
                    sb.AppendLine();
                }
                // Append back-to-index link.
                sb.AppendLine();
                sb.AppendLine("[Back to Requests Index](index.md)");
                string fileName = $"{request.Name}.md";
                File.WriteAllText(Path.Combine(requestsDir, fileName), sb.ToString());

                string shortSummary = RenderFragments(request.Documentation.SummaryFragments)
                                      .Split('\n').FirstOrDefault()?.Trim() ?? "";
                indexEntries.Add($"- [{request.Name}]({fileName}): {shortSummary}");
            }

            var indexSb = new StringBuilder();
            indexSb.AppendLine("# Requests");
            indexSb.AppendLine();
            indexSb.AppendLine("The following requests are available:");
            indexSb.AppendLine();
            foreach (var entry in indexEntries.OrderBy(e => e))
            {
                indexSb.AppendLine(entry);
            }
            // Optionally, add a link to the overall documentation if needed.
            File.WriteAllText(Path.Combine(requestsDir, "index.md"), indexSb.ToString());
        }

        /// <summary>
        /// Generates Markdown files for each model (records and enums) and an index file listing them.
        /// For record models, property types are rendered as links (with no prefix) since they are in the same folder.
        /// Each property is preceded by an anchor tag so that local cref references work as bookmark links.
        /// Also appends a "Back to Models Index" link at the bottom of each model file.
        /// </summary>
        public void GenerateModelsMarkdown(ModelsDocumentation modelsDoc)
        {
            string modelsDir = Path.Combine(OutputDirectory, "models");
            Directory.CreateDirectory(modelsDir);
            var indexEntries = new List<string>();

            // Process record models.
            foreach (var record in modelsDoc.Records)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# Model: {record.Name}");
                sb.AppendLine();
                sb.AppendLine("## Overview");
                sb.AppendLine();
                string summaryText = RenderFragments(record.SummaryFragments, record.Properties.Select(p => p.Name));
                sb.AppendLine(summaryText);
                if (!string.IsNullOrWhiteSpace(record.SeeAlso))
                {
                    sb.AppendLine();
                    sb.AppendLine($"**See Also:** {record.SeeAlso}");
                }
                if (!string.IsNullOrWhiteSpace(record.BaseRecordName))
                {
                    // Extract the simple name from the base record name.
                    var simpleBaseName = record.BaseRecordName.Split('.').Last().Trim();
                    sb.AppendLine();
                    sb.AppendLine($"**Inherits from:** [{simpleBaseName}]({simpleBaseName}.md)");
                }
                sb.AppendLine();
                sb.AppendLine("## Properties");
                foreach (var prop in record.Properties)
                {
                    sb.AppendLine($"<a id=\"{prop.Name}\"></a>");
                    string propSummary = RenderFragments(prop.SummaryFragments, record.Properties.Select(p => p.Name));
                    string renderedType = RenderParameterType(prop.Type);
                    sb.AppendLine($"- **{prop.Name}** (`{renderedType}`): {propSummary}");
                    if (!string.IsNullOrWhiteSpace(prop.JsonPropertyName))
                    {
                        sb.AppendLine($"  - JSON Name: `{prop.JsonPropertyName}`");
                    }
                }
                // Append back-to-index link.
                sb.AppendLine();
                sb.AppendLine("[Back to Models Index](index.md)");
                string fileName = $"{record.Name}.md";
                File.WriteAllText(Path.Combine(modelsDir, fileName), sb.ToString());

                string shortSummary = summaryText.Split('\n').FirstOrDefault()?.Trim() ?? "";
                indexEntries.Add($"- [Record: {record.Name}]({fileName}): {shortSummary}");
            }

            // Process enum models.
            foreach (var en in modelsDoc.Enums)
            {
                var sb = new StringBuilder();
                sb.AppendLine($"# Enum: {en.Name}");
                sb.AppendLine();
                string summaryText = RenderFragments(en.SummaryFragments);
                sb.AppendLine(summaryText);
                sb.AppendLine();
                sb.AppendLine("## Members");
                foreach (var member in en.Members)
                {
                    string memberSummary = RenderFragments(member.SummaryFragments);
                    sb.AppendLine($"- **{member.Name}**: {memberSummary}");
                    if (!string.IsNullOrWhiteSpace(member.JsonValue))
                    {
                        sb.AppendLine($"  - JSON Value: `{member.JsonValue}`");
                    }
                }
                // Append back-to-index link.
                sb.AppendLine();
                sb.AppendLine("[Back to Models Index](index.md)");
                string fileName = $"{en.Name}.md";
                File.WriteAllText(Path.Combine(modelsDir, fileName), sb.ToString());

                string shortSummary = summaryText.Split('\n').FirstOrDefault()?.Trim() ?? "";
                indexEntries.Add($"- [Enum: {en.Name}]({fileName}): {shortSummary}");
            }

            var indexSb = new StringBuilder();
            indexSb.AppendLine("# Models");
            indexSb.AppendLine();
            indexSb.AppendLine("The following models are available:");
            indexSb.AppendLine();
            foreach (var entry in indexEntries.OrderBy(e => e))
            {
                indexSb.AppendLine(entry);
            }
            File.WriteAllText(Path.Combine(modelsDir, "index.md"), indexSb.ToString());
        }
    }
}
