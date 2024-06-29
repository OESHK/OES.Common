using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents an entry of a candidate being admitted to sit an exam.
/// </summary>
public class CandidateAdmissionEntry
{
    /// <summary>
    /// Creates an instance for a CandidateAdmissionEntry.
    /// </summary>
    [JsonConstructor]
    internal CandidateAdmissionEntry(
        string                             candidateId,
        int                                examinationId,
        [JsonProperty("centre_no")] string centreNumber = "",
        [JsonProperty("seat_no")]   string seatNumber   = "")
    {
        CandidateId   = candidateId;
        ExaminationId = examinationId;
        CentreNumber  = centreNumber;
        SeatNumber    = seatNumber;
    }

    /// <summary>
    /// The ID of the candidate.
    /// </summary>
    public string CandidateId { get; }
    
    /// <summary>
    /// The ID of the examination that the candidate has been admitted to sit.
    /// </summary>
    public int ExaminationId { get; }
    
    /// <summary>
    /// The number of exam centre in which the candidate will sit the exam.
    /// </summary>
    [JsonProperty("centre_no")]
    public string CentreNumber { get; }
    
    /// <summary>
    /// The candidate's seat number within the examination centre.
    /// </summary>
    [JsonProperty("seat_no")]
    public string SeatNumber { get; }

    public static CreateCandidateAdmissionEntry ToCreate(string candidateId, string centreNumber = "", string seatNumber = "")
        => new CreateCandidateAdmissionEntry(candidateId, centreNumber, seatNumber);
}