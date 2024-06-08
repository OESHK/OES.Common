using System.Collections.ObjectModel;
using System.Net;

namespace OES.Internal;

internal class Response
{
    public Response(HttpStatusCode statusCode, object body, IDictionary<string, string> headers, string contentType)
    {
        Ensure.ArgumentNotNull(headers, nameof(headers));

        Body        = body;
        Headers     = new ReadOnlyDictionary<string, string>(headers);
        StatusCode  = statusCode;
        ContentType = contentType;
    }
    
    public object Body { get; private set; }
    
    public IReadOnlyDictionary<string, string> Headers { get; private set; }
    
    public HttpStatusCode StatusCode { get; private set; }
    
    public string ContentType { get; private set; }

    internal static async Task<Response> GetResponseFromMessage(HttpResponseMessage responseMessage)
    {
        object? responseBody;
        
        Ensure.ArgumentNotNull(responseMessage, nameof(responseMessage));

        var binaryContentTypes = new[]
        {
            "application/octet-stream"
        };
        var contentType = "text/plain";
        if (responseMessage.Content.Headers.ContentType?.MediaType is not null)
            contentType = responseMessage.Content.Headers.ContentType.MediaType;
        var content = responseMessage.Content;

        if (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase)
            || binaryContentTypes.Any(x => x.Equals(contentType, StringComparison.OrdinalIgnoreCase)))
        {
            // binary response content type
            responseBody = await content.ReadAsStreamAsync().ConfigureAwait(false);
        }
        else
        {
            // non-binary or unknown
            responseBody = await content.ReadAsStringAsync().ConfigureAwait(false);
            content.Dispose();
        }

        var headers = responseMessage.Headers.ToDictionary(x => x.Key, x => x.Value.First());

        return new Response(
            responseMessage.StatusCode,
            responseBody,
            headers,
            contentType);
    }
}

internal class ApiResponse<T>
{
    public ApiResponse(Response response, T body)
    {
        Ensure.ArgumentNotNull(response, nameof(response));
        
        HttpResponse = response;
        Body         = body;
    }
    
    public T Body { get; }
    
    public Response HttpResponse { get; }
}