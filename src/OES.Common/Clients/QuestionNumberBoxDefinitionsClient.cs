using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for <see cref="QuestionNumberBoxDefinition"/>.
/// </summary>
public class QuestionNumberBoxDefinitionsClient : ApiClient
{
    internal QuestionNumberBoxDefinitionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new <see cref="QuestionNumberBoxDefinition"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The created <see cref="QuestionNumberBoxDefinition"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <see cref="CreateQuestionNumberBoxDefinition.IsValid"/>
    /// of request body returns false.</exception>
    public Task<QuestionNumberBoxDefinition> Create(CreateQuestionNumberBoxDefinition body)
    {
        if (!body.IsValid())
            throw new ArgumentException("The request body is invalid. " +
                                        "Every question must have an ImageMargin defined.", nameof(body));

        return ApiConnection.Post<QuestionNumberBoxDefinition>(ApiEndpoints.QuestionNumberBoxDefinitions(), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="QuestionNumberBoxDefinition"/>.
    /// </summary>
    /// <param name="delObj">The request body.</param>
    /// <returns>The status of the request.</returns>
    public Task<HttpStatusCode> Delete(DeleteObject delObj)
    {
        return Delete(int.Parse(delObj.Id));
    }

    /// <summary>
    /// Deletes an existing <see cref="QuestionNumberBoxDefinition"/>.
    /// </summary>
    /// <param name="qnbDefinitionId">The ID of the <see cref="QuestionNumberBoxDefinition"/> to be deleted.</param>
    /// <returns>The status of the request.</returns>
    public Task<HttpStatusCode> Delete(int qnbDefinitionId)
    {
        return Connection.Delete(ApiEndpoints.QuestionNumberBoxDefinitionById(qnbDefinitionId));
    }

    /// <summary>
    /// Gets a <see cref="QuestionNumberBoxDefinition"/> by ID.
    /// </summary>
    /// <param name="qnbDefinitionId">The ID of the <see cref="QuestionNumberBoxDefinition"/>.</param>
    /// <returns>The retrieved <see cref="QuestionNumberBoxDefinition"/>.</returns>
    public Task<QuestionNumberBoxDefinition> Get(int qnbDefinitionId)
    {
        return ApiConnection.Get<QuestionNumberBoxDefinition>(
            ApiEndpoints.QuestionNumberBoxDefinitionById(qnbDefinitionId));
    }

    /// <summary>
    /// Gets all <see cref="QuestionNumberBoxDefinition"/> with given pagination options.
    /// </summary>
    /// <param name="perPage">Number of items to get per page. (Default: 30)</param>
    /// <param name="page">Page number to get. (Default: 1)</param>
    /// <returns>The list of retrieved <see cref="QuestionNumberBoxDefinition"/>.</returns>
    public Task<IReadOnlyCollection<QuestionNumberBoxDefinition>> GetAll(int perPage = 30, int page = 1)
    {
        return ApiConnection.Get<IReadOnlyCollection<QuestionNumberBoxDefinition>>(
            ApiEndpoints.QuestionNumberBoxDefinitions(),
            new Dictionary<string, object>
            {
                { "per_page", perPage },
                { "page", page }
            });
    }
}