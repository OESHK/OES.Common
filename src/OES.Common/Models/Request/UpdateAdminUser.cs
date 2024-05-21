using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to update an existing Admin user. Only properties with non-null values are changed.
/// </summary>
public class UpdateAdminUser
{
    internal UpdateAdminUser(string adminId)
    {
        AdminId = adminId;
    }
    
    /// <summary>
    /// The ID of the Admin whose information is to be updated.
    /// </summary>
    public string AdminId { get; }
    
    /// <summary>
    /// The new display name of the Admin.
    /// </summary>
    public string? UserDisplayName { get; set; }

    /// <summary>
    /// The new password of the Admin.
    /// </summary>
    /****
     * Currently, user-initiated password update is not supported.
     * Request to update a user's password will only be accepted by the root user of the system.
     * Requests made by other admin users will be rejected.
     ***/
    [JsonIgnore]
    public string? Password
    {
        get => _password;
        set
        {
            // When password is modified, the salt must be changed as well.
            // When password remains unchanged, the salt will also remain unchanged.
            _password = value;
            LoginSalt = value is null ? null : PasswordHash.GetSalt();
            PasswordHashed = value is null ? null : PasswordHash.Hash(value, LoginSalt!);
        }
    }
    private string? _password;

    [JsonProperty("login_hash")]
    public string? PasswordHashed { get; private set; }

    public string? LoginSalt { get; private set; }
}