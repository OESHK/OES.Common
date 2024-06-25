using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to update the information of an existing candidate. 
/// </summary>
public class UpdateCandidateUser
{
    internal UpdateCandidateUser(CandidateUser candidateUser)
    {
        CandidateId = candidateUser.CandidateId;
    }
    
    /// <summary>
    /// The ID of the candidate whose information will be updated.
    /// This is immutable as candidate ID cannot be modified.
    /// </summary>
    public string CandidateId { get; }
    
    public string? EnglishFirstName { get; set; }
    
    public string? EnglishLastName { get; set; }
    
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
    
    public Gender? Gender { get; set; }
    
    public string? Email { get; set; }
    
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