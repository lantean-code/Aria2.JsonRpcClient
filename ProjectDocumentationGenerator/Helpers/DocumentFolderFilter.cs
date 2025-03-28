using System.IO;
using System;

namespace ProjectDocumentationGenerator.Helpers
{
    public static class DocumentFolderFilter
    {
        /// <summary>
        /// Determines whether the given document file path is located in the specified root-level folder
        /// relative to the provided project directory.
        /// </summary>
        /// <param name="documentFilePath">The absolute file path of the document.</param>
        /// <param name="projectDirectory">The root directory of the project.</param>
        /// <param name="folderName">The folder name to check for (e.g., "Requests").</param>
        /// <returns>True if the document is in the specified folder at the root of the project; otherwise, false.</returns>
        public static bool IsInRootFolder(string documentFilePath, string projectDirectory, string folderName)
        {
            if (string.IsNullOrEmpty(documentFilePath))
                return false;

            // Compute the relative path from the project directory to the document.
            string relativePath = Path.GetRelativePath(projectDirectory, documentFilePath);

            // Split the path into segments (handles both Windows and Unix separators).
            var segments = relativePath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar },
                                              StringSplitOptions.RemoveEmptyEntries);

            // Check that there is at least one segment and that the first segment exactly matches the folder name.
            return segments.Length > 0 && segments[0].Equals(folderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
