using OES.Internal;

namespace OES;

/// <summary>
/// A client for Candidates Entries API.
/// </summary>
public class CandidateEntriesClient : ApiClient
{
    internal CandidateEntriesClient(ApiConnection apiConnection) : base(apiConnection)
    {
        
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