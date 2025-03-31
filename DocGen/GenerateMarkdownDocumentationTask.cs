using System;
using Microsoft.Build.Framework;
using ProjectDocumentationGenerator;

namespace DocGen
{
    public class GenerateMarkdownDocumentationTask : Microsoft.Build.Utilities.Task
    {
        [Required]
        public string ProjectFile { get; set; }

        [Required]
        public string OutputDirectory { get; set; }

        [Required]
        public string TargetFramework { get; set; }

        public override bool Execute()
        {
            try
            {
                Log.LogMessage(MessageImportance.High, $"Processing file: {ProjectFile}");

                Generator.GenerateDocumentation(ProjectFile, OutputDirectory, TargetFramework).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex, true);
                return false;
            }
            return true;
        }
    }
}
