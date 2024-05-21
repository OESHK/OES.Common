using Newtonsoft.Json;

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
    /// <param name="userDisplayName">The name that will be displayed for the Admin.</param>
    /// <param name="loginSalt">Salt for logging in.</param>
    public AdminUser(string id, string userDisplayName, string loginSalt) : base(UserType.Admin, id, loginSalt)
    {
        UserDisplayName = userDisplayName;
    }

    /// <summary>
    /// The ID of the Admin.
    /// </summary>
    [JsonProperty("admin_id")]
    public string AdminId
    {
        get => Id;
        set => Id = value;
    }
    
    /// <summary>
    /// The name displayed on screen when the user is logged in.
    /// </summary>
    public string UserDisplayName { get; }
}