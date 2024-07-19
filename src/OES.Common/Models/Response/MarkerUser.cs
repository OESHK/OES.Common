using Newtonsoft.Json;

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
    [JsonConstructor]
    internal MarkerUser(string id, string engFirstName, string engLastName, string chiName, string salt) : base(
        UserType.Marker, id, engFirstName, engLastName, chiName, salt)
    {
    }
    
    /// <summary>
    /// The ID of the marker.
    /// </summary>
    public string MarkerId => Id;

    /// <summary>
    /// Gets an object representing a Create Marker request.
    /// </summary>
    public static CreateMarkerUser ToCreate(string id, string engFirstName, string engLastName, string? chiName,
        string password) => new(id, engFirstName, engLastName, chiName, password);

    /// <summary>
    /// Gets an object representing an Update Marker request.
    /// </summary>
    public UpdateMarkerUser ToUpdate() => new(this);
}