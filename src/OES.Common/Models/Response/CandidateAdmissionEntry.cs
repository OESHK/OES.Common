namespace OES;

/// <summary>
/// Represents an entry of a candidate being admitted to sit an exam.
/// </summary>
public class CandidateAdmissionEntry
{
    /// <summary>
    /// Creates an instance for a CandidateAdmissionEntry.
    /// </summary>
    /// <param name="candidateId"></param>
    /// <param name="examinationId"></param>
    /// <param name="centreNumber"></param>
    /// <param name="seatNumber"></param>
    public CandidateAdmissionEntry(string candidateId, string examinationId, string centreNumber, int seatNumber)
    {
        CandidateId = candidateId;
        ExaminationId = examinationId;
        CentreNumber = centreNumber;
        SeatNumber = seatNumber;
    }

    /// <summary>
    /// The ID of the candidate.
    /// </summary>
    public string CandidateId { get; }
    
    /// <summary>
    /// The ID of the examination that the candidate has been admitted to sit.
    /// </summary>
    public string ExaminationId { get; }
    
    /// <summary>
    /// The number of exam centre in which the candidate will sit the exam.
    /// </summary>
    public string CentreNumber { get; }
    
    /// <summary>
    /// The candidate's seat number within the examination centre.
    /// </summary>
    public int SeatNumber { get; }
}