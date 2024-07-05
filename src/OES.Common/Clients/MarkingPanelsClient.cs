using OES.Internal;

namespace OES;

/// <summary>
/// A client to interact with API endpoints for marking panels.
/// </summary>
public class MarkingPanelsClient : ApiClient
{
    internal MarkingPanelsClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Creates a new marking panel.
    /// </summary>
    /// <param name="body">The request body for creating a marking panel.</param>
    /// <returns>The created marking panel.</returns>
    public Task<MarkingPanel> CreateMarkingPanel(CreateMarkingPanel body)
    {
        return ApiConnection.Post<MarkingPanel>(ApiEndpoints.MarkingPanels(), body);
    }

    /// <summary>
    /// Gets a specific marking panel by its ID.
    /// </summary>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <returns>The specified marking panel.</returns>
    public Task<MarkingPanel> Get(int panelId)
    {
        return ApiConnection.Get<MarkingPanel>(ApiEndpoints.MarkingPanelById(panelId));
    }

    /// <summary>
    /// Gets all marking panels of an examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <returns>A list of all marking panels that belong to the specified examination.</returns>
    public Task<IReadOnlyCollection<MarkingPanel>> GetAllPanelsOfExamination(int examinationId)
    {
        return ApiConnection.Get<IReadOnlyCollection<MarkingPanel>>(
            ApiEndpoints.MarkingPanelsOfExamination(examinationId));
    }

    /// <summary>
    /// Gets a specific marking panel of a specific examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <returns>The specified marking panel.</returns>
    public Task<MarkingPanel> GetPanelOfExamination(int examinationId, int panelId)
    {
        return ApiConnection.Get<MarkingPanel>(ApiEndpoints.MarkingPanelOfExamination(examinationId, panelId));
    }

    public Task<MarkingPanel> Update(UpdateMarkingPanel body)
    {
        return ApiConnection.Patch<MarkingPanel>(ApiEndpoints.MarkingPanelById(body.PanelId), body);
    }
}