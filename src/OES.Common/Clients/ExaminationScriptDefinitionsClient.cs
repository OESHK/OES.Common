using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for examination script definitions.
/// </summary>
public class ExaminationScriptDefinitionsClient : ApiClient
{
    public ExaminationScriptDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="ExaminationScriptDefinition"/>.</returns>
    public Task<ExaminationScriptDefinition> Create(CreateExaminationScriptDefinition body)
    {
        return ApiConnection.Post<ExaminationScriptDefinition>(ApiEndpoints.ExamScriptDefinitions(), body);
    }

    /// <summary>
    /// Deletes the existing <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The status code of the request.</returns>
    public Task<HttpStatusCode> Delete(DeleteObject body)
    {
        return Connection.Delete(ApiEndpoints.ExamScriptDefinitionById(int.Parse(body.Id)));
    }

    /// <summary>
    /// Gets a <see cref="ExaminationScriptDefinition"/> of from an <see cref="Examination"/> by ID.
    /// </summary>
    /// <param name="examinationId">The ID of the <see cref="Examination"/>.</param>
    /// <param name="definitionId">The ID of the <see cref="ExaminationScriptDefinition"/>.</param>
    /// <returns>The <see cref="ExaminationScriptDefinition"/> retrieved.</returns>
    public Task<ExaminationScriptDefinition> GetScriptDefinitionOfExam(int examinationId, int definitionId)
    {
        return ApiConnection.Get<ExaminationScriptDefinition>(
            ApiEndpoints.ExamScriptDefOfExamById(examinationId, definitionId));
    }

    /// <summary>
    /// Gets a <see cref="ExaminationScriptDefinition"/> of from an <see cref="Examination"/> by ID.
    /// </summary>
    /// <param name="examination">The <see cref="Examination"/>.</param>
    /// <param name="definitionId">The ID of the <see cref="ExaminationScriptDefinition"/>.</param>
    /// <returns>The retrieved <see cref="ExaminationScriptDefinition"/>.</returns>
    public Task<ExaminationScriptDefinition> GetScriptDefinitionOfExam(Examination examination, int definitionId)
    {
        return GetScriptDefinitionOfExam(examination.ExaminationId, definitionId);
    }

    /// <summary>
    /// Gets all <see cref="ExaminationScriptDefinition"/>s of a specific <see cref="Examination"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <returns>The list of <see cref="ExaminationScriptDefinition"/>s of the specified <see cref="Examination"/>.</returns>
    public Task<IReadOnlyCollection<ExaminationScriptDefinition>> GetScriptDefsOfExam(int examinationId)
    {
        return ApiConnection.Get<IReadOnlyCollection<ExaminationScriptDefinition>>(
            ApiEndpoints.ExamScriptDefsOfExam(examinationId));
    }

    /// <summary>
    /// Gets all <see cref="ExaminationScriptDefinition"/>s of a specific <see cref="Examination"/>.
    /// </summary>
    /// <param name="examination">The <see cref="Examination"/>.</param>
    /// <returns>The list of <see cref="ExaminationScriptDefinition"/>s of the specified <see cref="Examination"/>.</returns>
    public Task<IReadOnlyCollection<ExaminationScriptDefinition>> GetScriptDefsOfExam(Examination examination)
    {
        return GetScriptDefsOfExam(examination.ExaminationId);
    }
}