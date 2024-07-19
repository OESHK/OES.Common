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
    [JsonConstructor]
    internal AdminUser(string id, string userDisplayName, string loginSalt) : base(UserType.Admin, id, loginSalt)
    {
        UserDisplayName = userDisplayName;
    }

    /// <summary>
    /// The ID of the Admin.
    /// </summary>
    [JsonProperty("admin_id")]
    public string AdminId => Id;

    /// <summary>
    /// The name displayed on screen when the user is logged in.
    /// </summary>
    public string UserDisplayName { get; }

    /// <summary>
    /// Gets an object representing a Create Admin User request.
    /// </summary>
    /// <param name="id">The ID of the admin to be created.</param>
    /// <param name="displayName">The display name of the admin.</param>
    /// <param name="password">The login password of the admin.</param>
    public static CreateAdminUser ToCreate(string id, string displayName, string password)
        => new CreateAdminUser(id, displayName, password);

    /// <summary>
    /// Gets an object representing an Update Admin User request for the current AdminUser.
    /// </summary>
    public UpdateAdminUser ToUpdate()
        => new (this);
}