using OES.Internal;

namespace OES;

/// <summary>
/// Provides a series of methods for interacting with the OES API.
/// </summary>
public class OESClient
{
    internal OESClient(Uri baseAddress, HttpClient? httpClient)
    {
        _connection    = new Connection(baseAddress, httpClient ?? new HttpClient());
        _apiConnection = new ApiConnection(_connection);
        
        Examinations                 = new ExaminationsClient(_apiConnection);
        ExaminationScriptDefinitions = new ExaminationScriptDefinitionsClient(_apiConnection);
        MarkingPanels                = new MarkingPanelsClient(_apiConnection);
    }

    /// <summary>
    /// Creates an OESClient instance.
    /// </summary>
    /// <param name="baseAddress">The base address of the API server.</param>
    /// <param name="httpClient">The custom HTTP client to be used by the OESClient.</param>
    /// <param name="login">The login information for interacting with the API.</param>
    /// <returns>The created OESClient instance.</returns>
    /// <exception cref="UnsupportedApiVersionException">Thrown when the API server specified uses an API version that is not supported.</exception>
    public static async Task<OESClient> Create(Uri baseAddress, HttpClient? httpClient = null, Credentials? login = null)
    {
        if (!baseAddress.IsAbsoluteUri)
            throw new ArgumentException("Base address must be an absolute Uri.", nameof(baseAddress));
        if (!baseAddress.ToString().EndsWith('/')) // BaseAddress MUST end with a slash
            baseAddress = new Uri(baseAddress + "/", UriKind.Absolute);
        
        var client = new OESClient(baseAddress, httpClient);
        client.ApiInfo = await client._apiConnection.Get<ApiInfo>(ApiEndpoints.GetApiInfo(), authType: AuthenticationType.Anonymous).ConfigureAwait(false);
        if (SupportedApiVersions.All(ver => ver != client.ApiInfo.ApiVersion))
            throw new UnsupportedApiVersionException(client.ApiInfo.ApiVersion, SupportedApiVersions);
        
        // append version at the end of base uri
        client._connection.BaseAddress = new Uri(
            new Uri(baseAddress.ToString(), UriKind.Absolute),
            new Uri(client.ApiInfo.ApiVersion + "/", UriKind.Relative));
        
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

    public ApiInfo? ApiInfo { get; private set; }

    private static readonly string[] SupportedApiVersions = 
    {
        "v1"
        // TODO: move this field to another class for easy maintenance in the future
    };

    private readonly Connection _connection;

    private readonly ApiConnection _apiConnection;
    
    public ExaminationsClient Examinations { get; }
    
    public ExaminationScriptDefinitionsClient ExaminationScriptDefinitions { get; }
    
    public MarkingPanelsClient MarkingPanels { get; }
}