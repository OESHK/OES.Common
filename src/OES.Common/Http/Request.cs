using System.Text;
using Newtonsoft.Json;

namespace OES.Internal;

internal class Request
{
    public object? Body { get; set; }

    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    
    public HttpMethod Method { get; set; } = HttpMethod.Get;

    public IDictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

    public string ContentType { get; set; } = "application/json";

    public HttpRequestMessage GetHttpRequestMessage(Uri baseAddress, Uri endpoint)
    {
        var result = new HttpRequestMessage();
        result.Method     = Method;

        if (endpoint.ToString().StartsWith('/')) // removes leading slash(es)
            endpoint = new Uri(endpoint.ToString().TrimStart('/'));
        result.RequestUri = new Uri(baseAddress, endpoint);
        
        foreach (var header in Headers)
            result.Headers.Add(header.Key, header.Value);

        if (Body is null) throw new NullReferenceException("The body of the request is null.");
        if (HttpHelpers.IsBinaryContentType(ContentType))
        {
            result.Content = new StreamContent(new MemoryStream((byte[])Body));
        }
        else
        {
            result.Content = new StringContent(JsonConvert.SerializeObject(Body), Encoding.UTF8);
        }
        
        return result;
    }
}