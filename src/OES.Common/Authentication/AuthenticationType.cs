namespace OES;

/// <summary>
/// The type of authentication used.
/// </summary>
public enum AuthenticationType
{
    /// <summary>
    /// Authorise anonymously.
    /// </summary>
    Anonymous = 0,
    
    /// <summary>
    /// Authorise using username and password.
    /// </summary>
    Basic = 1,
    
    /// <summary>
    /// Authorise using session ID and access token.
    /// </summary>
    AccessToken = 2
}