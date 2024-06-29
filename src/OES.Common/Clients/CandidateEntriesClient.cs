using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for candidate entries under examinations.
/// </summary>
public class CandidateEntriesClient : ApiClient
{
    internal CandidateEntriesClient(ApiConnection apiConnection) : base(apiConnection)
    {
        
    }

    public Task<CandidateAdmissionEntry> EnrollCandidate(int examinationId, CreateCandidateAdmissionEntry entry)
    {
        return ApiConnection.Post<CandidateAdmissionEntry>(ApiEndpoints.ExaminationCandidateEntries(examinationId),
            entry);
    }

    /// <summary>
    /// Enrolls a candidate into an examination.
    /// </summary>
    /// <param name="candidateId">The candidate to be enrolled.</param>
    /// <param name="examinationId">The examination to enroll.</param>
    /// <param name="centreNo">The examination centre's number.</param>
    /// <param name="seatNo">The candidate's seat number.</param>
    /// <returns>The record of the candidate's enrollment.</returns>
    public Task<CandidateAdmissionEntry> EnrollCandidate(
        string candidateId,
        int    examinationId,
        string centreNo = "",
        string seatNo   = "")
    {
        return EnrollCandidate(examinationId, new CreateCandidateAdmissionEntry(candidateId, centreNo, seatNo));
    }

    /// <summary>
    /// Enrolls a candidate into an examination.
    /// </summary>
    /// <param name="candidate">The <see cref="CandidateUser"/>.</param>
    /// <param name="examination">The <see cref="Examination"/>.</param>
    /// <param name="useClassAsCentreNo">Whether to use the candidate's class as the examination centre number.</param>
    /// <param name="useClassNoAsSeatNo">Whether to use the candidate's class number as his/her seat number.</param>
    /// <returns>The record of the candidate's enrollment.</returns>
    public Task<CandidateAdmissionEntry> EnrollCandidate(
        CandidateUser candidate,
        Examination   examination,
        bool          useClassAsCentreNo = false,
        bool          useClassNoAsSeatNo = false)
    {
        return EnrollCandidate(
            candidate.CandidateId,
            examination.ExaminationId,
            useClassAsCentreNo ? candidate.Class : "",
            useClassNoAsSeatNo ? candidate.ClassNumber.ToString() : "");
    }

    /// <summary>
    /// Gets a list of candidates of a specified examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="centreNumber">The Examination Centre No. to filter. Wildcard (*) can be used.</param>
    /// <param name="perPage">The number of candidates entry to get per page.</param>
    /// <param name="page">The page number of the candidate entry list.</param>
    /// <returns>A list of <see cref="CandidateAdmissionEntry"/></returns>
    public Task<IReadOnlyCollection<CandidateAdmissionEntry>> GetAll(
        int     examinationId,
        string? centreNumber = null,
        int     perPage      = 30,
        int     page         = 1)
    {
        var args = new Dictionary<string, object>
        {
            { "per_page", perPage },
            { "page", page }
        };
        if (centreNumber is not null) args.Add("centre_no", centreNumber);
        
        return ApiConnection.Get<IReadOnlyCollection<CandidateAdmissionEntry>>(
            ApiEndpoints.ExaminationCandidateEntries(examinationId), args);
    }
}