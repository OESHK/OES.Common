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
}