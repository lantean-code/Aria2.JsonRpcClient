using Microsoft.CodeAnalysis.MSBuild;
using ProjectDocumentationGenerator.Models;
using ProjectDocumentationGenerator.Parsers;

namespace ProjectDocumentationGenerator
{
    public static class Generator
    {
        public static async Task GenerateDocumentation(string projectFile, string outputDirectory, string targetFramework)
        {
            var projectFolder = Path.GetDirectoryName(projectFile)!;

            var globalProperties = new Dictionary<string, string>
            {
                { "TargetFramework", targetFramework }
            };

            ClientDocumentation clientData;
            RequestDocumentation requestData;
            ModelsDocumentation modelData;
            OthersDocumentation othersData;
            using (var workspace = MSBuildWorkspace.Create(globalProperties))
            {
                var project = await workspace.OpenProjectAsync(projectFile);

                var compilation = await project.GetCompilationAsync() ?? throw new InvalidOperationException("No compilation");

                clientData = await ClientParser.ParseClientInterfaceAsync(project, compilation);
                requestData = await RequestParser.ParseRequestsAsync(project, compilation, clientData);
                modelData = await ModelParser.ParseModelsAsync(project, compilation);
                othersData = await OthersParser.ParseOthersAsync(project, compilation);
            }

            var models = new Dictionary<string, string>();
            foreach (var model in modelData.Records)
            {
                models[model.Name] = "model_";
            }
            foreach (var @enum in modelData.Enums)
            {
                models[@enum.Name] = "model_";
            }
            foreach (var @enum in requestData.Records)
            {
                models[@enum.Name] = "request_";
            }
            foreach (var record in othersData.Records)
            {
                models[record.Name] = "";
            }
            foreach (var @class in othersData.Classes)
            {
                models[@class.Name] = "";
            }
            foreach (var @enum in othersData.Enums)
            {
                models[@enum.Name] = "";
            }

            var variables = new Dictionary<string, string>
            {
                { "GeneratedDate", DateTime.Now.ToString("yyyy-MM-dd") }
            };
            var indexPath = PathCompat.Join(projectFolder, "_index.md");
            var examplesPath = PathCompat.Join(projectFolder, "_examples.md");
            var headerTemplatePath = PathCompat.Join(projectFolder, "_header.md");
            var footerTemplatePath = PathCompat.Join(projectFolder, "_footer.md");

            var templateEngine = new TemplateEngine(headerTemplatePath, footerTemplatePath, variables);

            var generator = new MarkdownGenerator(outputDirectory, models, templateEngine);
            generator.GenerateClientMarkdown(clientData);
            generator.GenerateModelsMarkdown(modelData);
            generator.GenerateRequestsMarkdown(requestData);
            generator.GenerateOthersMarkdown(othersData, indexPath, examplesPath);
        }
    }
}
