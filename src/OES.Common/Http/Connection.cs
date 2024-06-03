namespace OES.Internal;

/// <summary>
/// A connection for sending requests to the OES API endpoints.
/// </summary>
internal class Connection
{
    private readonly Uri         _baseAddress;
    private readonly HttpClient  _httpClient;
    private readonly Credentials _credentials;

    private static Credentials _anonymousCredentials = Credentials.Anonymous;
    private const string       UserAgent             = "OES.Common/1.0.0";

    /// <summary>
    /// Creates a new connection instance with a custom <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    /// <param name="httpClient">The custom <see cref="HttpClient"/>.</param>
    /// <param name="credentials">The credentials for authorising API requests.</param>
    public Connection(Uri baseAddress, HttpClient httpClient, Credentials credentials)
    {
        // credentials must be of AuthenticationType.Basic i.e. login+password
        if (credentials.AuthenticationType != AuthenticationType.Basic)
            throw new ArgumentException(
                "AuthenticationType of Credentials for creating a new Connection must be Basic.",
                nameof(credentials));
        if (!baseAddress.IsAbsoluteUri)
            throw new ArgumentException("Base URI must be absolute.", nameof(baseAddress));
        
        _baseAddress = baseAddress;
        _httpClient  = httpClient;
        _credentials = credentials;
    }

    /// <summary>
    /// Creates a new connection.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    /// <param name="credentials">The credentials for authorising API requests.</param>
    public Connection(Uri baseAddress, Credentials credentials) : this(baseAddress, new HttpClient(), credentials)
    {
    }

    /// <summary>
    /// Creates a new connection.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    /// <param name="login">The login of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <param name="userType">The type of the user.</param>
    /// <param name="salt">The salt for hashing the user's password.</param>
    public Connection(Uri baseAddress, string login, string password, UserType userType, string salt) : this(
        baseAddress, new HttpClient(), new Credentials(login, password, userType, salt))
    {
    }
    
}