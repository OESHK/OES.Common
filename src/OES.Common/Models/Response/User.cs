namespace OES;

/// <summary>
/// Base class for OES users.
/// </summary>
public abstract class User
{
    /// <summary>
    /// Creates an User instance. This class in intended for internal use only.
    /// </summary>
    /// <param name="type">Type of user. Specified in inherited classes.</param>
    /// <param name="id">ID of the user.</param>
    /// <param name="loginSalt">Salt of the user.</param>
    protected User(UserType type, string id, string loginSalt)
    {
        UserType = type;
        Id = id;
        LoginSalt = loginSalt;
    }
    
    /// <summary>
    /// The Id of the user.
    /// </summary>
    public string Id { get; }
    
    /// <summary>
    /// The type of this user.
    /// </summary>
    public UserType UserType { get; }
    
    /// <summary>
    /// The salt for password authentication with server.
    /// </summary>
    public string LoginSalt { get; }
}