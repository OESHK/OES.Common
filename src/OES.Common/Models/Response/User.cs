namespace OES;

/// <summary>
/// Base class for OES users.
/// </summary>
public abstract class User
{
    /// <summary>
    /// The Id of the user.
    /// </summary>
    public string Id { get; }
    
    /// <summary>
    /// The type of this user.
    /// </summary>
    public UserType Type { get; }
    
    /// <summary>
    /// The salt for password authentication with server.
    /// </summary>
    public string LoginSalt { get; }
}