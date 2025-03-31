namespace ProjectDocumentationGenerator
{
    public static class PathCompat
    {
        /// <summary>
        /// Joins all the given path segments into a single path.
        /// On frameworks that support it, the native Path.Join is used.
        /// </summary>
        /// <param name="paths">An array of path segments.</param>
        /// <returns>A combined path string.</returns>
        public static string Join(params string[] paths)
        {
#if NETCOREAPP || NETSTANDARD2_1
            // Use the built-in method on supported frameworks
            return Path.Join(paths);
#else
        // Custom implementation for .NET Framework 4.7.2 and others.
        if (paths == null)
            throw new ArgumentNullException(nameof(paths));
        if (paths.Length == 0)
            return string.Empty;

        // Start with the first segment (or empty if null)
        var result = paths[0] ?? string.Empty;

        for (var i = 1; i < paths.Length; i++)
        {
            var segment = paths[i];
            if (string.IsNullOrEmpty(segment))
                continue;

            var resultEndsWithSeparator =
                result.EndsWith(Path.DirectorySeparatorChar.ToString()) ||
                result.EndsWith(Path.AltDirectorySeparatorChar.ToString());
            var segmentStartsWithSeparator =
                segment.StartsWith(Path.DirectorySeparatorChar.ToString()) ||
                segment.StartsWith(Path.AltDirectorySeparatorChar.ToString());

            if (!resultEndsWithSeparator && !segmentStartsWithSeparator)
            {
                result += Path.DirectorySeparatorChar;
            }
            else if (resultEndsWithSeparator && segmentStartsWithSeparator)
            {
                // Avoid duplicate separators
                segment = segment.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }

            result += segment;
        }

        return result;
#endif
        }

        /// <summary>
        /// Returns a relative path from one absolute path to another.
        /// On frameworks that support it, the native Path.GetRelativePath is used.
        /// Both parameters should be absolute paths.
        /// </summary>
        /// <param name="relativeTo">The base path you want to calculate the relative path from.</param>
        /// <param name="path">The destination path.</param>
        /// <returns>The relative path from <paramref name="relativeTo"/> to <paramref name="path"/>.</returns>
        public static string GetRelativePath(string relativeTo, string path)
        {
#if NETCOREAPP || NETSTANDARD2_1
            // Use the built-in method on supported frameworks
            return Path.GetRelativePath(relativeTo, path);
#else
        // Custom implementation for .NET Framework 4.7.2 and others.
        if (relativeTo == null)
            throw new ArgumentNullException(nameof(relativeTo));
        if (path == null)
            throw new ArgumentNullException(nameof(path));

        // Ensure the base path ends with a directory separator
        var basePath = AddTrailingSeparator(relativeTo);

        // Create Uri instances for both paths (they must be absolute)
        var baseUri = new Uri(basePath, UriKind.Absolute);
        var pathUri = new Uri(path, UriKind.Absolute);

        // If the schemes are different (e.g. file vs. http) then return the original path.
        if (!string.Equals(baseUri.Scheme, pathUri.Scheme, StringComparison.OrdinalIgnoreCase))
        {
            return path;
        }

        // Compute the relative Uri and then unescape it.
        var relativeUri = baseUri.MakeRelativeUri(pathUri);
        var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

        // For file URIs, convert the forward slashes to backslashes.
        if (string.Equals(pathUri.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase))
        {
            relativePath = relativePath.Replace('/', Path.DirectorySeparatorChar);
        }

        return relativePath;
#endif
        }

#if !(NETCOREAPP || NETSTANDARD2_1)
    /// <summary>
    /// Ensures that the provided path ends with a directory separator.
    /// </summary>
    /// <param name="path">The input path.</param>
    /// <returns>The path ending with a directory separator if needed.</returns>
    private static string AddTrailingSeparator(string path)
    {
        if (string.IsNullOrEmpty(path))
            return path;
        if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()) &&
            !path.EndsWith(Path.AltDirectorySeparatorChar.ToString()))
        {
            return path + Path.DirectorySeparatorChar;
        }
        return path;
    }
#endif
    }
}
