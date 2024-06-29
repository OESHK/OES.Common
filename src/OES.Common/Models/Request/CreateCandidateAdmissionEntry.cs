using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents a request to create a candidate's admission entry.
/// </summary>
public class CreateCandidateAdmissionEntry
{
    internal CreateCandidateAdmissionEntry(
        string candidateId,
        string centreNumber = "",
        string seatNumber   = "")
    {
        CandidateId  = candidateId;
        CentreNumber = centreNumber;
        SeatNumber   = seatNumber;
    }
    
    /// <inheritdoc cref="CandidateAdmissionEntry.CandidateId"/>
    public string CandidateId { get; }
    
    /// <inheritdoc cref="CandidateAdmissionEntry.CentreNumber"/>
    [JsonProperty("centre_no")]
    public string CentreNumber { get; }
    
    /// <inheritdoc cref="CandidateAdmissionEntry.SeatNumber"/>
    [JsonProperty("seat_no")]
    public string SeatNumber { get; }
}