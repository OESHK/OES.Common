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
    /// The type of candidate's registered identification document. E.g. HKID, Passport, etc.
    /// </summary>
    public string IdType { get; }
    
    /// <summary>
    /// The number of the candidate's registered identification document.
    /// </summary>
    public string IdNumber { get; }
    
    public Gender Gender { get; }
    
    public string Email { get; }
    
    /// <summary>
    /// The candidate's mobile phone number. Region codes included.
    /// </summary>
    public string PhoneNumber { get; }
    
    /// <summary>
    /// The candidate's class. E.g. 6A
    /// </summary>
    public string Class { get; }
    
    /// <summary>
    /// The class number of the candidate.
    /// </summary>
    public int ClassNumber { get; }
    
    public DateOnly DateOfBirth { get; }
}