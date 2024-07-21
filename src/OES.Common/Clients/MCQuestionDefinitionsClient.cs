using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for MCQ definitions.
/// </summary>
public class MCQuestionDefinitionsClient : ApiClient
{
    internal MCQuestionDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Gets a <see cref="MCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="MCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the script definition to which the <see cref="MCQuestionDefinition"/>
    /// belongs.</param>
    /// <param name="mcqDefinitionId">The ID of the <see cref="MCQuestionDefinition"/>.</param>
    /// <returns>The required <see cref="MCQuestionDefinition"/>.</returns>
    public Task<MCQuestionDefinition> Get(int examinationId, int scriptDefinitionId, int mcqDefinitionId)
    {
        return ApiConnection.Get<MCQuestionDefinition>(
            ApiEndpoints.MCQuestionDefinitionById(examinationId, scriptDefinitionId, mcqDefinitionId));
    }
}