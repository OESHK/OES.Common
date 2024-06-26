using OES.Internal;

namespace OES;

/// <summary>
/// A wrapper of <see cref="Connection"/> that provides type-friendly methods.
/// </summary>
public class ApiConnection
{
    public ApiConnection(Connection connection)
    {
        Connection = connection;
    }
    
    public Connection Connection { get; private set; }

    public async Task<T> Get<T>(Uri endpoint, IDictionary<string, object>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        
        var response = await Connection.Get<T>(endpoint, parameters, contentType, authType).ConfigureAwait(false);
        return response.Body;
    }

    public async Task<T> Patch<T>(Uri endpoint, object body, IDictionary<string, object>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await Connection.Patch<T>(endpoint, body, parameters, contentType, authType).ConfigureAwait(false);
        return response.Body;
    }

    public async Task<T> Post<T>(Uri endpoint, object? body = null, IDictionary<string, object>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await Connection.Post<T>(endpoint, body, parameters, contentType, authType).ConfigureAwait(false);
        return response.Body;
    }

    public async Task<T> Put<T>(Uri endpoint, object body, IDictionary<string, object>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await Connection.Put<T>(endpoint, body, parameters, contentType, authType).ConfigureAwait(false);
        return response.Body;
    }
}