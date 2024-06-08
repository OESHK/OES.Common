using System.Text;
using Newtonsoft.Json;

namespace OES.Internal;

internal class Request
{
    public object Body { get; set; }
    
    public IDictionary<string, string> Headers { get; set; }
    
    public HttpMethod Method { get; set; }
    
    public IDictionary<string, string> Parameters { get; set; }
    
    public string ContentType { get; set; }

    public HttpRequestMessage GetHttpRequestMessage()
    {
        var result = new HttpRequestMessage();
        result.Method = Method;
        foreach (var header in Headers)
            result.Headers.Add(header.Key, header.Value);
        result.Content = new StringContent(JsonConvert.SerializeObject(Body), Encoding.UTF8);
        return result;
    }
}