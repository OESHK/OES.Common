/***
 * NOTE:
 * TO MAINTAIN READABILITY, ALL MEMBERS OF THIS CLASS SHOULD BE ARRANGED BY THEIR TYPES THEN THEIR NAMES.
 * THE ORDER OF MEMBER TYPES WOULD BE:
 *      - FIELDS
 *      - PROPERTIES
 *      - CONSTRUCTORS
 *      - METHODS
 */

using System.Net;
using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A connection for sending requests to the OES API endpoints.
/// </summary>
public class Connection
{
    private readonly HttpClient   _httpClient;
    private readonly Session?     _session;

    private static readonly JsonSerializerSettings JsonSerializerSettings =
        new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore // skip null values, especially for updating models
        };

    private static Credentials _anonymousCredentials = Credentials.Anonymous;
    private const string       UserAgent             = "OES.Common/1.0.0";
    
    public Credentials? Credentials { get; set; }
    public Uri BaseAddress { get; internal set; }

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
        
        BaseAddress = baseAddress;
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

    public async Task<HttpStatusCode> Delete(Uri endpoint, IDictionary<string, string>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));

        var response = await InternalSendRequest(GetRequest(null, HttpMethod.Delete, parameters, contentType), endpoint, authType).ConfigureAwait(false);
        return response.StatusCode;
    }

    public Task<ApiResponse<T>> Get<T>(Uri endpoint, IDictionary<string, string>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));

        return InternalSendRequest<T>(GetRequest(null, HttpMethod.Get, parameters, contentType), endpoint, authType);
    }

    public async Task<Stream> GetRaw(Uri endpoint, IDictionary<string, string>? parameters = null, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));

        var response = await InternalSendRequest(GetRequest(null, HttpMethod.Get, parameters, contentType), endpoint, authType)
            .ConfigureAwait(false);
        if (response.Body is not Stream s)
            throw new InvalidDataException("Data returned from server is not of type \"Stream\"");
        return s;
    }

    /// <summary>
    /// Constructs a <see cref="Request"/> object.
    /// </summary>
    private static Request GetRequest(object? body, HttpMethod method, IDictionary<string, string>? parameters, string? contentType)
        => new Request { Body = body, Method = method, Parameters = parameters, ContentType = contentType };

    // Requests made by every client will ultimately go through this method.
    private async Task<Response> InternalSendRequest(Request request, Uri endpoint, AuthenticationType authType)
    {
        request.Headers.Add("User-Agent", UserAgent);
        request        = ApplyCredentials(request, authType);
        var responseMessage = await _httpClient.SendAsync(request.GetHttpRequestMessage(BaseAddress, endpoint)).ConfigureAwait(false);
        // todo: handle error http status codes

        return await Response.GetResponseFromMessage(responseMessage).ConfigureAwait(false);
    }

    private async Task<ApiResponse<T>> InternalSendRequest<T>(
        Request            request,
        Uri                endpoint,
        AuthenticationType authType)
    {
        var response = await InternalSendRequest(request, endpoint, authType).ConfigureAwait(false);
        var responseBody = JsonConvert.DeserializeObject<T>((string) response.Body, JsonSerializerSettings);
        if (responseBody is null) throw new NullReferenceException("The response body is null.");
        return new ApiResponse<T>(response, responseBody);
    }

    public Task<ApiResponse<T>> Patch<T>(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        return InternalSendRequest<T>(GetRequest(body, HttpMethod.Patch, parameters, contentType), endpoint, authType);
    }

    public async Task<HttpStatusCode> Patch(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await InternalSendRequest(GetRequest(body, HttpMethod.Patch, parameters, contentType), endpoint, authType).ConfigureAwait(false);
        return response.StatusCode;
    }

    public Task<ApiResponse<T>> Post<T>(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        return InternalSendRequest<T>(GetRequest(body, HttpMethod.Post, parameters, contentType), endpoint, authType);
    }

    public async Task<HttpStatusCode> Post(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await InternalSendRequest(GetRequest(body, HttpMethod.Post, parameters, contentType), endpoint, authType).ConfigureAwait(false);
        return response.StatusCode;
    }
    
    public Task<ApiResponse<T>> Put<T>(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        return InternalSendRequest<T>(GetRequest(body, HttpMethod.Put, parameters, contentType), endpoint, authType);
    }

    public async Task<HttpStatusCode> Put(Uri endpoint, object body, IDictionary<string, string> parameters, string? contentType = null, AuthenticationType authType = AuthenticationType.AccessToken)
    {
        Ensure.ArgumentNotNull(endpoint, nameof(endpoint));
        Ensure.ArgumentNotNull(body, nameof(body));

        var response = await InternalSendRequest(GetRequest(body, HttpMethod.Put, parameters, contentType), endpoint, authType).ConfigureAwait(false);
        return response.StatusCode;
    }
}