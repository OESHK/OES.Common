namespace OES;

/// <summary>
/// Represents a Admin user stored in the database.
/// </summary>
public class AdminUser : User
{
    /// <summary>
    /// Creates an AdminUser instance.
    /// </summary>
    /// <param name="id">The ID of the Admin.</param>
    /// <param name="displayName">The name that will be displayed for the Admin.</param>
    /// <param name="loginSalt">Salt for logging in.</param>
    public AdminUser(string id, string displayName, string loginSalt) : base(UserType.Admin, id, loginSalt)
    {
        DisplayName = displayName;
    }
    
    /// <summary>
    /// The name displayed on screen when the user is logged in.
    /// </summary>
    public string DisplayName { get; }
}