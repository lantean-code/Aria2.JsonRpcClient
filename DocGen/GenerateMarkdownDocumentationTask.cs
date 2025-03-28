using System;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace DocGen
{


    public class GenerateMarkdownDocumentationTask : Microsoft.Build.Utilities.Task
    {
        // The input source file to process.
        [Required]
        public string SourceFile { get; set; }

        // The output Markdown file.
        [Required]
        public string OutputFile { get; set; }

        public override bool Execute()
        {
            try
            {
                Log.LogMessage(MessageImportance.High, $"Processing file: {SourceFile}");
                string code = File.ReadAllText(SourceFile);

                // Parse the C# code into a syntax tree.
                SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
                SyntaxNode root = tree.GetRoot();

                // Find all class declarations in the file.
                var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                using (var writer = new StreamWriter(OutputFile))
                {
                    writer.WriteLine("# API Documentation");
                    writer.WriteLine();

                    foreach (var classDecl in classes)
                    {
                        string className = classDecl.Identifier.Text;
                        writer.WriteLine($"## Class: {className}");
                        writer.WriteLine();

                        // Write out XML documentation comments if available.
                        var trivia = classDecl.GetLeadingTrivia();
                        var docComment = trivia
                            .Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia))
                            .Select(t => t.ToFullString().Trim())
                            .FirstOrDefault();

                        if (!string.IsNullOrEmpty(docComment))
                        {
                            writer.WriteLine("### Summary");
                            writer.WriteLine();
                            writer.WriteLine("```xml");
                            writer.WriteLine(docComment);
                            writer.WriteLine("```");
                            writer.WriteLine();
                        }

                        // List method names
                        var methods = classDecl.DescendantNodes().OfType<MethodDeclarationSyntax>();
                        if (methods.Any())
                        {
                            writer.WriteLine("### Methods");
                            writer.WriteLine();
                            foreach (var method in methods)
                            {
                                string methodName = method.Identifier.Text;
                                writer.WriteLine($"- **{methodName}**");
                            }
                            writer.WriteLine();
                        }
                    }
                }
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
