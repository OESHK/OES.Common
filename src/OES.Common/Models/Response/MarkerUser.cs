namespace OES;

/// <summary>
/// Represents a Maker user stored in the database.
/// </summary>
public class MarkerUser : UserWithDetailedName
{
    /// <summary>
    /// Creates a MakerUser instance.
    /// </summary>
    /// <param name="id">ID of the marker.</param>
    /// <param name="engFirstName">First name of the marker in English.</param>
    /// <param name="engLastName">Last name of the marker in English.</param>
    /// <param name="chiName">Full name of the marker in Chinese.</param>
    /// <param name="salt">Salt for logging in.</param>
    public MarkerUser(string id, string engFirstName, string engLastName, string chiName, string salt) : base(
        UserType.Marker, id, engFirstName, engLastName, chiName, salt)
    {
    }
}