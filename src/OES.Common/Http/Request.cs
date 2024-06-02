namespace OES.Internal;

internal class Request
{
    public object Body { get; set; }
    
    public IDictionary<string, string> Headers { get; set; }
    
    public HttpMethod Method { get; set; }
    
    public IDictionary<string, string> Parameters { get; set; }
    
    public string ContentType { get; set; }
}