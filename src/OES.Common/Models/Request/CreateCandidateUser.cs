using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to create a new Candidate User.
/// </summary>
public class CreateCandidateUser
{
    public CreateCandidateUser(
        string id,
        string engFirstName,
        string engLastName,
        string? chiName,
        string? phone,
        string email,
        Gender gender,
        string? @class,
        int? classNumber,
        string? idType,
        string? idNumber,
        DateOnly? dob)
    {
        CandidateId = id;
        EnglishFirstName = engFirstName;
        EnglishLastName = engLastName;
        ChineseFullName = chiName;
        PhoneNumber = phone;
        Email = email;
        Gender = gender;
        Class = @class;
        ClassNumber = classNumber;
        IdType = idType;
        IdNumber = idNumber;
        DateOfBirth = dob;
    }
    
    /// <summary>
    /// Creates a New Candidate User request with minimal information.
    /// </summary>
    /// <param name="id">The ID of the candidate.</param>
    /// <param name="engFirstName">The candidate's first name in English.</param>
    /// <param name="engLastName">The candidate's last name in English.</param>
    /// <param name="gender">The candidate's gender.</param>
    /// <param name="email">The candidate's email.</param>
    public CreateCandidateUser(string id, string engFirstName, string engLastName, Gender gender, string email) 
        : this(id, engFirstName, engLastName, null, null, email, gender, null, null, null, null, null) { }
    
    public string CandidateId { get; set; }
    
    public string EnglishFirstName { get; set; }
    
    public string EnglishLastName { get; set; }
    
    public string? ChineseFullName { get; set; }
    
    /// <summary>
    /// The type of candidate's registered identification document. E.g. HKID, Passport, etc.
    /// </summary>
    public string? IdType { get; set; }
    
    /// <summary>
    /// The number of the candidate's registered identification document.
    /// </summary>
    [JsonProperty("id_no")]
    public string? IdNumber { get; set; }
    
    public Gender Gender { get; set; }
    
    public string Email { get; set; }
    
    /// <summary>
    /// The candidate's mobile phone number. Region codes included.
    /// </summary>
    [JsonProperty("phone_no")]
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// The candidate's class. E.g. 6A
    /// </summary>
    public string? Class { get; set; }
    
    /// <summary>
    /// The class number of the candidate.
    /// </summary>
    [JsonProperty("class_no")]
    public int? ClassNumber { get; set; }
    
    public DateOnly? DateOfBirth { get; set; }
}