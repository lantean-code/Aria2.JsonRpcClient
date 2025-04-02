using Microsoft.Build.Locator;
using ProjectDocumentationGenerator;

namespace ProjectDocumentationGeneratorRunner
{
    internal static class Program
    {
        private static async Task Main(string[] args)
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

            await Generator.GenerateDocumentation(@"..\..\..\..\Aria2.JsonRpcClient\Aria2.JsonRpcClient.csproj", "..\\..\\..\\..\\docs", "net9.0");
        }
    }
}
