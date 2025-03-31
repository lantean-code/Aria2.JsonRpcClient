using Microsoft.Build.Locator;
using ProjectDocumentationGenerator;

namespace ProjectDocumentationGeneratorRunner
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (!MSBuildLocator.IsRegistered)
            {
                var instance = MSBuildLocator.QueryVisualStudioInstances().FirstOrDefault();
                if (instance is null)
                {
                    MSBuildLocator.RegisterMSBuildPath("C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin");
                }
                else
                {
                    MSBuildLocator.RegisterInstance(instance);
                }
            }

            var gen = new Generator();

            await Generator.GenerateDocumentation(@"..\..\..\..\Aria2.JsonRpcClient\Aria2.JsonRpcClient.csproj", "..\\..\\..\\docs", "net9.0");
        }
    }
}
