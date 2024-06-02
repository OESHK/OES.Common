using OES.Internal;

namespace OES;

/// <summary>
/// Stores credentials for authorising API requests.
/// </summary>
public class Credentials
{
    /// <summary>
    /// The anonymous credential.
    /// </summary>
    public static readonly Credentials Anonymous = new();

    /// <summary>
    /// Creates an anonymous credential.
    /// </summary>
    private Credentials()
    {
        AuthenticationType = AuthenticationType.Anonymous;
        Login = string.Empty;
        Password = string.Empty;
    }

    /// <summary>
    /// Create credentials with user's login and password.
    /// </summary>
    /// <param name="username">The user's ID.</param>
    /// <param name="password">The password for logging in.</param>
    /// <param name="userType">The type of user of this credential.</param>
    /// <param name="salt">The salt for hashing the password.</param>
    public Credentials(string username, string password, UserType userType, string salt)
    {
        AuthenticationType = AuthenticationType.Basic;
        Login = username;
        Password = PasswordHash.Hash(password, salt);
        UserType = userType;
    }

    /// <summary>
    /// Create credentials with session's access token.
    /// </summary>
    /// <param name="sessionId"></param>
    /// <param name="sessionAccessToken"></param>
    public Credentials(string sessionId, string sessionAccessToken)
    {
        AuthenticationType = AuthenticationType.AccessToken;
        Login = sessionId;
        Password = sessionAccessToken;
    }

    /// <summary>
    /// Create credentials with an active session.
    /// </summary>
    /// <param name="session">The session instance.</param>
    public Credentials(Session session) : this(session.SessionId, session.AccessToken) { }
    
    /// <summary>
    /// The type of authentication this credential uses.
    /// </summary>
    public AuthenticationType AuthenticationType { get; }
    
    /// <summary>
    /// The user type of this credential. Only used when <see cref="AuthenticationType"/> is <see cref="AuthenticationType.Basic"/>.
    /// </summary>
    public UserType? UserType { get; }
    
    /// <summary>
    /// The login of the credential.
    /// </summary>
    public string Login { get; private set; }
    
    /// <summary>
    /// The password of the credential.
    /// </summary>
    public string Password { get; private set; }
}