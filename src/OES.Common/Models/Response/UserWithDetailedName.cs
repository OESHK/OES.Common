namespace OES;

/// <summary>
/// Base class for users who have stored in database their names in both English and Chinese.
/// Typically, these users are either Candidate or Marker.
/// </summary>
public abstract class UserWithDetailedName : User
{
    /// <summary>
    /// Creates an instance for a User with detailed names.
    /// </summary>
    /// <param name="userType">Type of user.</param>
    /// <param name="id">ID of user.</param>
    /// <param name="englishFirstName">First name of user in English.</param>
    /// <param name="englishLastName">Last name of user in English.</param>
    /// <param name="chineseFullName">Full name of user in Chinese.</param>
    /// <param name="salt">Salt for logging in.</param>
    protected UserWithDetailedName(UserType userType, string id, string englishFirstName, string englishLastName, string chineseFullName, string salt) : base(userType, id, salt)
    {
        EnglishFirstName = englishFirstName;
        EnglishLastName = englishLastName;
        ChineseFullName = chineseFullName;
    }
    /// <summary>
    /// First name of user in English.
    /// </summary>
    public string EnglishFirstName { get; }
    
    /// <summary>
    /// Last name of user in English.
    /// </summary>
    public string EnglishLastName { get; }
    
    /// <summary>
    /// Full name of user in English.
    /// </summary>
    public string ChineseFullName { get; }
}