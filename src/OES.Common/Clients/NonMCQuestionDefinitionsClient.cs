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
}