namespace OES;

/// <summary>
/// A session established with the API server.
/// </summary>
public class Session
{
    /// <summary>
    /// Creates a session instance.
    /// </summary>
    public Session(string sessionId, string accessToken, DateTime sessionExpiry)
    {
        SessionId = sessionId;
        AccessToken = accessToken;
        SessionExpiry = sessionExpiry;
    }

    /// <summary>
    /// The ID of the session.
    /// </summary>
    public string SessionId { get; }
    
    /// <summary>
    /// The access token.
    /// </summary>
    public string AccessToken { get; }
    
    /// <summary>
    /// The time of the expiry of this session.
    /// </summary>
    public DateTime SessionExpiry { get; }
}