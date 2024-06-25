namespace OES;

/// <summary>
/// A request to update an existing Admin user. Only properties with non-null values are changed.
/// </summary>
public class UpdateAdminUser
{
    internal UpdateAdminUser(AdminUser adminUser)
    {
        AdminId = adminUser.AdminId;
    }
    
    /// <summary>
    /// The ID of the Admin whose information is to be updated.
    /// </summary>
    public string AdminId { get; }
    
    /// <summary>
    /// The new display name of the Admin.
    /// </summary>
    public string? UserDisplayName { get; set; }
    
    /*
     * For password reset/update, separate requests are to be made as the endpoints are different.
     */
}