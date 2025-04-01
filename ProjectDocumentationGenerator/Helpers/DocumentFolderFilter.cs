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
            {
                return false;
            }

            // Compute the relative path from the project directory to the document.
            var relativePath = PathCompat.GetRelativePath(projectDirectory, documentFilePath);

            // Split the path into segments (handles both Windows and Unix separators).
            var segments = relativePath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar },
                                              StringSplitOptions.RemoveEmptyEntries);

            // If folderName is empty, match files in the root folder only.
            if (string.IsNullOrEmpty(folderName))
            {
                // A file in the project root will result in a single segment (the file name).
                return segments.Length == 1;
            }

            // Otherwise, check that the first segment exactly matches the folder name.
            return segments.Length > 0 && segments[0].Equals(folderName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
