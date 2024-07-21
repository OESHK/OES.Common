using System.Net;
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
    /// Create a new <see cref="MCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="MCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the script definition to which the <see cref="MCQuestionDefinition"/>
    /// belongs.</param>
    /// <param name="body">The request body.</param>
    /// <returns>The creqted <see cref="MCQuestionDefinition"/>.</returns>
    public Task<MCQuestionDefinition> Create(int examinationId, int scriptDefinitionId, CreateMCQuestionDefinition body)
    {
        return ApiConnection.Post<MCQuestionDefinition>(
            ApiEndpoints.MCQuestionDefinitions(examinationId, scriptDefinitionId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="MCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="MCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the script definition to which the <see cref="MCQuestionDefinition"/>
    /// belongs.</param>
    /// <param name="mcqDefinitionId">The ID of the <see cref="MCQuestionDefinition"/>.</param>
    /// <returns>The status of the request.</returns>
    public Task<HttpStatusCode> Delete(int examinationId, int scriptDefinitionId, int mcqDefinitionId)
    {
        return Connection.Delete(
            ApiEndpoints.MCQuestionDefinitionById(examinationId, scriptDefinitionId, mcqDefinitionId));
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

    /// <summary>
    /// Gets a list of <see cref="MCQuestionDefinition"/>.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="MCQuestionDefinition"/> belongs.</param>
    /// <param name="scriptDefinitionId">The ID of the script definition to which the <see cref="MCQuestionDefinition"/>
    /// belongs.</param>
    /// <param name="questionNumber">Filters the list by its question number.</param>
    /// <returns>The requested list of <see cref="MCQuestionDefinition"/>s.</returns>
    public Task<IReadOnlyCollection<MCQuestionDefinition>> GetAll(int examinationId, int scriptDefinitionId, int? questionNumber = null)
    {
        return ApiConnection.Get<IReadOnlyCollection<MCQuestionDefinition>>(
            ApiEndpoints.MCQuestionDefinitions(examinationId, scriptDefinitionId),
            questionNumber is null
                ? null
                : new Dictionary<string, object> { { "question_no", questionNumber } });
    }
}