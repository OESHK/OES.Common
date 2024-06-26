using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for OES API Examinations endpoints.
/// </summary>
public class ExaminationsClient : IClient
{
    internal ExaminationsClient(ApiConnection apiConnection)
    {
        ApiConnection = apiConnection;
        Connection    = ApiConnection.Connection;
    }
    
    public ApiConnection ApiConnection { get; }
    public Connection Connection { get; }

    /// <summary>
    /// Creates an Examination.
    /// </summary>
    /// <param name="createExamination">The Examination to be created.</param>
    /// <returns>The created <see cref="Examination"/>.</returns>
    public Task<Examination> Create(CreateExamination createExamination)
    {
        return ApiConnection.Post<Examination>(ApiEndpoints.Examinations(), createExamination);
    }

    /// <summary>
    /// Deletes an existing Examination.
    /// </summary>
    /// <param name="delete">The <see cref="DeleteObject"/> request.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(DeleteObject delete)
    {
        return Connection.Delete(ApiEndpoints.ExaminationById(int.Parse(delete.Id)));
    }

    /// <summary>
    /// Deletes an existing Examination.
    /// </summary>
    /// <param name="examination">The Examination to be deleted.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(Examination examination)
    {
        return Delete(examination.ExaminationId);
    }

    /// <summary>
    /// Deletes an existing Examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to be deleted.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(int examinationId)
    {
        return Delete(new DeleteObject(examinationId.ToString()));
    }

    /// <summary>
    /// Gets the specified Examination.
    /// </summary>
    /// <param name="examinationId">The ID of the Examination.</param>
    /// <returns>An <see cref="Examination"/>.</returns>
    public Task<Examination> Get(int examinationId)
    {
        return ApiConnection.Get<Examination>(ApiEndpoints.ExaminationById(examinationId));
    }

    public Task<IReadOnlyCollection<Examination>> GetAll(int perPage = 30, int page = 1)
    {
        return ApiConnection.Get<IReadOnlyCollection<Examination>>(
            ApiEndpoints.Examinations(),
            new Dictionary<string, object>
            {
                { "per_page", perPage },
                { "page", page }
            });
    }

    /// <summary>
    /// Marks the status of an Examination as "Open".
    /// </summary>
    /// <param name="examination">The Examination to be marked as Open.</param>
    /// <returns>The updated <see cref="Examination"/>.</returns>
    public async Task<Examination> MarkAsOpen(Examination examination)
    {
        if (examination.ExaminationStatus == ExaminationStatus.Open)
            throw new ArgumentException("Examination is already open.");
        
        var statusCode = await Connection.Post(ApiEndpoints.ExaminationById(examination.ExaminationId)).ConfigureAwait(false);
        if (statusCode == HttpStatusCode.NoContent)
            return await ApiConnection.Get<Examination>(ApiEndpoints.ExaminationById(examination.ExaminationId)).ConfigureAwait(false);
        
        throw new Exception($"Request to mark examination as open failed with error. HTTP status: {statusCode.ToString()}");
    }

    /// <summary>
    /// Updates an existing Examination.
    /// </summary>
    /// <param name="updateExamination">The <see cref="UpdateExamination"/> request object.</param>
    /// <returns>The updated <see cref="Examination"/>.</returns>
    public Task<Examination> Update(UpdateExamination updateExamination)
    {
        return ApiConnection.Patch<Examination>(ApiEndpoints.ExaminationById(updateExamination.ExaminationId),
            updateExamination);
    }
}