using Microsoft.CodeAnalysis.MSBuild;
using ProjectDocumentationGenerator.Markdown;
using ProjectDocumentationGenerator.Parsers;

namespace ProjectDocumentationGenerator
{
    public class Generator
    {
        /// <summary>
        /// Loads the project from <paramref name="projectFile"/> and writes out documentation to <paramref name="outputDirectory"/>.
        /// </summary>
        public async Task GenerateDocumentation(string projectFile, string outputDirectory)
        {
            // Ensure MSBuild is properly located (required for dotnet build CLI)
            //if (!MSBuildLocator.IsRegistered)
            //{
            //    MSBuildLocator.RegisterDefaults();
            //}

            var globalProperties = new Dictionary<string, string>
            {
                { "TargetFramework", "net8.0" }  // Force net6.0 target
            };

            using (var workspace = MSBuildWorkspace.Create(globalProperties))
            {
                // Load the project asynchronously (blocking here for simplicity)
                var project = await workspace.OpenProjectAsync(projectFile);

                var compilation = await project.GetCompilationAsync();
                if (compilation is null)
                {
                    throw new InvalidOperationException("No compilation");
                }

                var rp = new RequestParser();
                var mp = new ModelParser();
                var cp = new ClientParser();
                var clientData = await cp.ParseClientInterfaceAsync(project, compilation);
                var requestData = await rp.ParseRequestsAsync(project, compilation, clientData);
                var modelData = await mp.ParseModelsAsync(project, compilation);
                

                var modelTypeNames = new HashSet<string>(modelData.Records.Select(r => r.Name).Concat(modelData.Enums.Select(e => e.Name)));

                var generator = new MarkdownGenerator(outputDirectory, modelTypeNames);
                generator.GenerateClientMarkdown(clientData);
                generator.GenerateModelsMarkdown(modelData);
                generator.GenerateRequestsMarkdown(requestData);
            }
        }
    }
}
