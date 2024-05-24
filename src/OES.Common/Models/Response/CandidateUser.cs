using Newtonsoft.Json;

namespace OES;

/// Candidate users' login functionality is intended to be reserved at the moment.
/// They may login to the system using client softwares developed for them.
/// But for current plan, there will be no access points for candidates.
/// <summary>
/// Represents a Candidate user stored in the database.
/// </summary>
public class CandidateUser : UserWithDetailedName
{
    /// <summary>
    /// Creates a CandidateUser instance.
    /// </summary>
    public CandidateUser(
        string id,
        string engFirstName,
        string engLastName,
        string chiName,
        string phone,
        string email,
        Gender gender,
        string @class,
        int classNumber,
        string idType,
        string idNumber,
        DateOnly dob,
        string salt) : base(UserType.Candidate, id, engFirstName, engLastName, chiName, salt)
    {
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
    /// The ID of the candidate.
    /// </summary>
    public string CandidateId
    {
        get => Id;
        set => Id = value;
    }
    
    /// <summary>
    /// The type of candidate's registered identification document. E.g. HKID, Passport, etc.
    /// </summary>
    public string IdType { get; }
    
    /// <summary>
    /// The number of the candidate's registered identification document.
    /// </summary>
    [JsonProperty("id_no")]
    public string IdNumber { get; }
    
    public Gender Gender { get; }
    
    public string Email { get; }
    
    /// <summary>
    /// The candidate's mobile phone number. Region codes included.
    /// </summary>
    [JsonProperty("phone_no")]
    public string PhoneNumber { get; }
    
    /// <summary>
    /// The candidate's class. E.g. 6A
    /// </summary>
    public string Class { get; }
    
    /// <summary>
    /// The class number of the candidate.
    /// </summary>
    [JsonProperty("class_no")]
    public int ClassNumber { get; }
    
    public DateOnly DateOfBirth { get; }

    /// <summary>
    /// Gets an object representing a Create Candidate request.
    /// </summary>
    /// <param name="candidateId">The ID of the candidate.</param>
    /// <param name="engFirstName">The candidate's first name in English.</param>
    /// <param name="engLastName">The candidate's last name in English.</param>
    /// <param name="gender">The gender of the candidate.</param>
    /// <param name="email">The email of the candidate.</param>
    /// <returns>Object representing a Create Candidate request.</returns>
    public static CreateCandidateUser ToCreate(string candidateId, string engFirstName, string engLastName, Gender gender,
        string email)
        => new CreateCandidateUser(candidateId, engFirstName, engLastName, gender, email);

    /// <summary>
    /// Gets an object representing an Update Candidate request.
    /// </summary>
    /// <returns>Object representing an Update Candidate request.</returns>
    public UpdateCandidateUser ToUpdate() => new(this);

    /// <summary>
    /// Gets an object representing a Delete Candidate request.
    /// </summary>
    /// <returns>Object representing a Delete Candidate request.</returns>
    public DeleteObject ToDelete() => new(CandidateId);
}