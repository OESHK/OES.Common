/***
 * NOTE:
 * TO MAINTAIN READABILITY, ALL MEMBERS OF THIS CLASS SHOULD BE ARRANGED BY THEIR TYPES THEN THEIR NAMES.
 * THE ORDER OF MEMBER TYPES WOULD BE:
 *      - FIELDS
 *      - PROPERTIES
 *      - CONSTRUCTORS
 *      - METHODS
 */

using Newtonsoft.Json;

namespace OES.Internal;

/// <summary>
/// A connection for sending requests to the OES API endpoints.
/// </summary>
internal class Connection
{
    private readonly Uri          _baseAddress;
    private readonly HttpClient   _httpClient;
    private readonly Session?     _session;

    private static Credentials _anonymousCredentials = Credentials.Anonymous;
    private const string       UserAgent             = "OES.Common/1.0.0";
    
    public Credentials? Credentials { get; set; }

    /// <summary>
    /// Creates a new connection instance.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    public Connection(Uri baseAddress) : this(baseAddress, new HttpClient())
    {
    }

    /// <summary>
    /// Creates a new connection instance with a cusomt <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    /// <param name="httpClient">The custom <see cref="HttpClient"/>.</param>
    public Connection(Uri baseAddress, HttpClient httpClient)
    {
        if (!baseAddress.IsAbsoluteUri)
            throw new ArgumentException("Base URI must be absolute.", nameof(baseAddress));
        
        _baseAddress = baseAddress;
        _httpClient = httpClient;
    }

    /// <summary>
    /// Creates a new connection instance with a custom <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="baseAddress">The base address of the OES API server.</param>
    /// <param name="httpClient">The custom <see cref="HttpClient"/>.</param>
    /// <param name="credentials">The credentials for authorising API requests.</param>
    public Connection(Uri baseAddress, HttpClient httpClient, Credentials credentials) : this(baseAddress, httpClient)
    {
        // credentials must be of AuthenticationType.Basic i.e. login+password
        if (credentials.AuthenticationType != AuthenticationType.Basic)
            throw new ArgumentException(
                "AuthenticationType of Credentials for creating a new Connection must be Basic.",
                nameof(credentials));
        Credentials = credentials;
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

    private Request ApplyCredentials(Request request, AuthenticationType authType)
    {
        switch (authType)
        {
            case AuthenticationType.Anonymous:
                Credentials.Anonymous.ApplyCredentials(request);
                break;
            
            case AuthenticationType.Basic:
                if (Credentials is null)
                    throw new ArgumentNullException(nameof(Credentials), "No login credentials supplied.");
                Credentials.ApplyCredentials(request);
                break;
            
            case AuthenticationType.AccessToken:
                if (_session is null)
                    break; // todo: obtain a new session
                if (_session.IsExpiring())
                    break; // todo: renew the current session
                new Credentials(_session).ApplyCredentials(request);
                break;
            
            default:
                throw new ArgumentException("Invalid authentication type.", nameof(authType));
        }

        return request;
    }

    // Requests made by every client will ultimately go through this method.
    private async Task<Response> InternalSendRequest(Request request, Uri endpoint, AuthenticationType authType)
    {
        request.Headers.Add("User-Agent", UserAgent);
        request = ApplyCredentials(request, authType);
        var responseMessage = await _httpClient.SendAsync(request.GetHttpRequestMessage(_baseAddress, endpoint)).ConfigureAwait(false);
        // todo: handle error http status codes

        return await Response.GetResponseFromMessage(responseMessage).ConfigureAwait(false);
    }

    private async Task<ApiResponse<T>> InternalSendRequest<T>(
        Request            request,
        Uri                endpoint,
        AuthenticationType authType)
    {
        var response = await InternalSendRequest(request, endpoint, authType).ConfigureAwait(false);
        var responseBody = JsonConvert.DeserializeObject<T>((string) response.Body);
        if (responseBody is null) throw new NullReferenceException("The response body is null.");
        return new ApiResponse<T>(response, responseBody);
    }
}