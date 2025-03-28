using ProjectDocumentationGenerator;

namespace ProjectDocumentationGeneratorRunner
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var gen = new Generator();

            await gen.GenerateDocumentation(@"..\..\..\..\Aria2.JsonRpcClient\Aria2.JsonRpcClient.csproj", "..\\..\\..\\docs");
        }
    }
}
