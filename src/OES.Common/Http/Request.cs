using System.Text;
using Newtonsoft.Json;

namespace OES.Internal;

internal class Request
{
    public object? Body { get; set; }

    public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    
    public HttpMethod Method { get; set; } = HttpMethod.Get;

    public IDictionary<string, string>? Parameters { get; set; }

    public string ContentType { get; set; } = "application/json";

    public HttpRequestMessage GetHttpRequestMessage(Uri baseAddress, Uri endpoint)
    {
        var result = new HttpRequestMessage();
        result.Method     = Method;

        if (endpoint.ToString().StartsWith('/')) // removes leading slash(es)
            endpoint = new Uri(endpoint.ToString().TrimStart('/'));
        result.RequestUri = new Uri(baseAddress, endpoint).ApplyParams(Parameters);
        
        foreach (var header in Headers)
            result.Headers.Add(header.Key, header.Value);

        switch (Body)
        {
            case null when Method == HttpMethod.Get:
                return result; // request body can be null when method is GET
            case null:
                throw new NullReferenceException("Request body is null.");
        }

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