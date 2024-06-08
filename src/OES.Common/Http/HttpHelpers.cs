namespace OES.Internal;

internal static class HttpHelpers
{
    public static Uri ApplyParams(this Uri uri, IDictionary<string, string>? parameters)
    {
        Ensure.ArgumentNotNull(uri, nameof(uri));
        if (parameters is null || !parameters.Any()) return uri;

        var queryStringIndex = uri.OriginalString.IndexOf('?');
        var uriWithoutQuery = queryStringIndex == -1
            ? uri.ToString()
            : uri.OriginalString[..queryStringIndex];
        var queryString = uri.IsAbsoluteUri ? uri.Query : uri.OriginalString[queryStringIndex..];
        var values = queryString.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries);
        
        var existingParams = values.ToDictionary(
            key => key[..key.IndexOf('=')],
            value => value[(value.IndexOf('=') + 1)..]);
        
        foreach (var parameter in parameters)
            if (existingParams.TryGetValue(parameter.Key, out _))
                existingParams[parameter.Key] = parameter.Value;
            else
                existingParams.Add(parameter.Key, parameter.Value);

        var query = string.Join('&', existingParams.Select(kvp => kvp.Key + "=" + kvp.Value));

        if (!uri.IsAbsoluteUri) return new Uri(uriWithoutQuery + "?" + query, UriKind.Relative);
        
        var builder = new UriBuilder(uri) { Query = query};
        return builder.Uri;
    }
    
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