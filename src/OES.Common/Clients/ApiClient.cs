namespace OES;

/// <summary>
/// Base class of a Client class.
/// </summary>
public abstract class ApiClient
{
    protected ApiClient(ApiConnection apiConnection)
    {
        ApiConnection = apiConnection;
        Connection    = ApiConnection.Connection;
    }
    
    protected ApiConnection ApiConnection { get; }
    
    protected Connection Connection { get; }
}