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
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="NonMCQuestionDefinition"/>.</returns>
    public Task<NonMCQuestionDefinition> Create(CreateNonMCQuestionDefinition body)
    {
        return ApiConnection.Post<NonMCQuestionDefinition>(
            ApiEndpoints.NonMCQuestionDefinitions(body.ScriptDefinitionId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="NonMCQuestionDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(DeleteQuestionDefinition body)
    {
        return Connection.Delete(ApiEndpoints.NonMCQuestionDefinitionById(body.ScriptDefinitionId, int.Parse(body.Id)));
    }

    /// <summary>
    /// Deletes an existing <see cref="NonMCQuestionDefinition"/>.
    /// </summary>
    /// <param name="scriptDefinitionId">
    /// The ID of the <see cref="ExaminationScriptDefinition"/> to which the <see cref="NonMCQuestionDefinition"/> belongs.
    /// </param>
    /// <param name="nonMCQuestionDefinitionId">The ID of the <see cref="NonMCQuestionDefinition"/>.</param>
    /// <returns>The HTTP status code of the request.</returns>
    public Task<HttpStatusCode> Delete(int scriptDefinitionId, int nonMCQuestionDefinitionId)
    {
        return Connection.Delete(
            ApiEndpoints.NonMCQuestionDefinitionById(scriptDefinitionId, nonMCQuestionDefinitionId));
    }
}