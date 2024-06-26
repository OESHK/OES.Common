using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Provides basic information about the API server.
/// </summary>
public class ApiInfo
{
    [JsonConstructor]
    internal ApiInfo(string apiVersion)
    {
        ApiVersion = apiVersion;
    }
    
    public string ApiVersion { get; set; }
}