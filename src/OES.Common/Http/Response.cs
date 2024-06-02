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