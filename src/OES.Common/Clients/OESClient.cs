using OES.Internal;

namespace OES;

/// <summary>
/// Provides a series of methods for interacting with the OES API.
/// </summary>
public class OESClient
{
    internal OESClient(Uri baseAddress)
    {
        _connection    = new Connection(baseAddress);
        _apiConnection = new ApiConnection(_connection);
        
        Examinations   = new ExaminationsClient(_apiConnection);
    }

    /// <summary>
    /// Creates an OESClient instance.
    /// </summary>
    /// <param name="baseAddress">The base address of the API server.</param>
    /// <param name="login">The login information for interacting with the API.</param>
    /// <returns>The created OESClient instance.</returns>
    /// <exception cref="UnsupportedApiVersionException">Thrown when the API server specified uses an API version that is not supported.</exception>
    public static async Task<OESClient> Create(Uri baseAddress, Credentials? login = null)
    {
        if (!baseAddress.IsAbsoluteUri)
            throw new ArgumentException("Base address must be an absolute Uri.", nameof(baseAddress));
        
        var client = new OESClient(baseAddress);
        client._apiInfo = await client._apiConnection.Get<ApiInfo>(ApiEndpoints.GetApiInfo()).ConfigureAwait(false);
        if (SupportedApiVersions.All(ver => ver != client._apiInfo.ApiVersion))
            throw new UnsupportedApiVersionException(client._apiInfo.ApiVersion, SupportedApiVersions);
        
        // append version at the end of base uri
        client._connection.BaseAddress = new Uri(
            new Uri(baseAddress.ToString(), UriKind.Absolute),
            new Uri(client._apiInfo.ApiVersion, UriKind.Relative));
        
        client.SetCredentials(login);
        
        return client;
    }

    /// <summary>
    /// Sets the credentials for the OESClient instance.
    /// The credential's authentication type must be <see cref="AuthenticationType.Basic"/>.
    /// </summary>
    /// <param name="credentials">The Basic Credentials to be assigned to the OESClient instance.</param>
    /// <exception cref="InvalidOperationException">The credentials given is not of type Basic.</exception>
    public void SetCredentials(Credentials? credentials) => BasicAuthCredentials = credentials;

    private Credentials? BasicAuthCredentials
    {
        get => _basicAuthCredentials;
        set
        {
            if (value is null) return;
            if (value.AuthenticationType != AuthenticationType.Basic)
                throw new InvalidOperationException("Credentials for OESClient must be of AuthenticationType.Basic.");
            _basicAuthCredentials = value;

            _connection.Credentials = _basicAuthCredentials;
        }
    }
    private Credentials? _basicAuthCredentials;

    private ApiInfo? _apiInfo;

    private static readonly string[] SupportedApiVersions = 
    {
        "v1"
        // TODO: move this field to another class for easy maintenance in the future
    };

    private readonly Connection _connection;

    private readonly ApiConnection _apiConnection;
    
    public ExaminationsClient Examinations { get; }
}