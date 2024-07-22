using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for questions in a marking panel.
/// </summary>
public class MarkingPanelQuestionsClient : ApiClient
{
    internal MarkingPanelQuestionsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Links a question to a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the marking panel belongs.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="questionNumber">The number of the question.</param>
    /// <returns>Whether the request is successful.</returns>
    public async Task<bool> AddQuestion(int examinationId, int panelId, int questionNumber)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNull(questionNumber, nameof(questionNumber));

        var status = await Connection.Post(
            ApiEndpoints.MarkingPanelQuestions(examinationId, panelId),
            null,
            new Dictionary<string, object> { { "question_no", questionNumber } }).ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }

    /// <summary>
    /// Removes a linked question from a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the marking panel belongs.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="questionNumber">The number of the question.</param>
    /// <returns>Whether the request is successful.</returns>
    public async Task<bool> RemoveQuestion(int examinationId, int panelId, int questionNumber)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNull(questionNumber, nameof(questionNumber));

        var status = await Connection
                           .Delete(ApiEndpoints.MarkingPanelQuestionByNumber(examinationId, panelId, questionNumber))
                           .ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }
}