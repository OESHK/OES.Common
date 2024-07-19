using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for Non-MCQ definitions.
/// </summary>
public class NonMCQuestionDefinitionsClient : ApiClient
{
    internal NonMCQuestionDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="NonMCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="NonMCQuestionDefinition"/> belongs.</param>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="NonMCQuestionDefinition"/>.</returns>
    public Task<NonMCQuestionDefinition> Create(int examinationId, CreateNonMCQuestionDefinition body)
    {
        return ApiConnection.Post<NonMCQuestionDefinition>(
            ApiEndpoints.NonMCQuestionDefinitions(examinationId, body.ScriptDefinitionId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="NonMCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="NonMCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the script definition to which the <see cref="NonMCQuestionDefinition"/>
    /// belongs.</param>
    /// <param name="nonMCQuestionDefinitionId">The ID of the <see cref="NonMCQuestionDefinition"/> to be deleted.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(int examinationId, int scriptDefinitionId, int nonMCQuestionDefinitionId)
    {
        return Connection.Delete(
            ApiEndpoints.NonMCQuestionDefinitionById(examinationId, scriptDefinitionId, nonMCQuestionDefinitionId));
    }

    /// <summary>
    /// Gets a specific <see cref="NonMCQuestionDefinition"/> from an <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="NonMCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the <see cref="ExaminationScriptDefinition"/>.</param>
    /// <param name="nonMCQuestionDefinitionId">The ID of the <see cref="NonMCQuestionDefinition"/>.</param>
    /// <returns>The required <see cref="NonMCQuestionDefinition"/>.</returns>
    public Task<NonMCQuestionDefinition> Get(int examinationId, int scriptDefinitionId, int nonMCQuestionDefinitionId)
    {
        return ApiConnection.Get<NonMCQuestionDefinition>(
            ApiEndpoints.NonMCQuestionDefinitionById(examinationId, scriptDefinitionId, nonMCQuestionDefinitionId));
    }

    /// <summary>
    /// Gets all <see cref="NonMCQuestionDefinition"/>s under a <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="NonMCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the <see cref="ExaminationScriptDefinition"/>.</param>
    /// <returns>The list of the retrieved <see cref="NonMCQuestionDefinition"/>s.</returns>
    public Task<IReadOnlyCollection<NonMCQuestionDefinition>> GetAll(int examinationId, int scriptDefinitionId)
    {
        return ApiConnection.Get<IReadOnlyCollection<NonMCQuestionDefinition>>(
            ApiEndpoints.NonMCQuestionDefinitions(examinationId, scriptDefinitionId));
    }

    /// <summary>
    /// Gets <see cref="NonMCQuestionDefinition"/>s that have matching question number under a <see cref="ExaminationScriptDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="NonMCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The <see cref="ExaminationScriptDefinition"/></param>
    /// <param name="questionNumber">The question number to filter.</param>
    /// <returns>The list of matching <see cref="NonMCQuestionDefinition"/>s.</returns>
    public Task<IReadOnlyCollection<NonMCQuestionDefinition>> GetAllByQuestionNumber(
        int examinationId, int scriptDefinitionId, int questionNumber)
    {
        return ApiConnection.Get<IReadOnlyCollection<NonMCQuestionDefinition>>(
            ApiEndpoints.NonMCQuestionDefinitions(examinationId, scriptDefinitionId),
            new Dictionary<string, object>
            {
                { "question_number", questionNumber }
            });
    }
}