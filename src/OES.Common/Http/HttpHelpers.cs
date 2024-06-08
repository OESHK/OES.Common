namespace OES.Internal;

internal static class HttpHelpers
{
    /// <summary>
    /// Checks if the given content type is a binary file type.
    /// </summary>
    public static bool IsBinaryContentType(string contentType)
    {
        var binaryContentType = new[]
        {
            "application/octet-stream"
        };

        return contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)
               || binaryContentType.Any(x => x.Equals(contentType, StringComparison.OrdinalIgnoreCase));
    }
}