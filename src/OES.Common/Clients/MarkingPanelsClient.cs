using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client to interact with API endpoints for marking panels.
/// </summary>
public class MarkingPanelsClient : ApiClient
{
    internal MarkingPanelsClient(ApiConnection apiConnection) : base(apiConnection)
    {
        Members = new MarkingPanelMembersClient(apiConnection);
    }

    /// <summary>
    /// Creates a new <see cref="MarkingPanel"/>.
    /// </summary>
    /// <param name="body">The request body for creating a marking panel.</param>
    /// <returns>The created <see cref="MarkingPanel"/>.</returns>
    public Task<MarkingPanel> CreateMarkingPanel(CreateMarkingPanel body)
    {
        return ApiConnection.Post<MarkingPanel>(ApiEndpoints.MarkingPanels(body.ExaminationId), body);
    }

    /// <summary>
    /// Deletes an existing <see cref="MarkingPanel"/>
    /// </summary>
    /// <param name="examinationId">The ID of the examination to which the <see cref="MarkingPanel"/> belongs.</param>
    /// <param name="panelId"></param>
    /// <returns>The status of the delete request.</returns>
    public Task<HttpStatusCode> Delete(int examinationId, int panelId)
    {
        return Connection.Delete(ApiEndpoints.MarkingPanelById(examinationId, panelId));
    }

    /// <summary>
    /// Gets all marking panels of an examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <returns>A list of all marking panels that belong to the specified examination.</returns>
    public Task<IReadOnlyCollection<MarkingPanel>> GetAllPanelsOfExamination(int examinationId)
    {
        return ApiConnection.Get<IReadOnlyCollection<MarkingPanel>>(
            ApiEndpoints.MarkingPanels(examinationId));
    }

    /// <summary>
    /// Gets a specific marking panel of a specific examination.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <returns>The specified marking panel.</returns>
    public Task<MarkingPanel> GetPanelOfExamination(int examinationId, int panelId)
    {
        return ApiConnection.Get<MarkingPanel>(ApiEndpoints.MarkingPanelById(examinationId, panelId));
    }

    /// <summary>
    /// Updates a <see cref="MarkingPanel"/>.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <returns>The updated marking panel.</returns>
    public Task<MarkingPanel> Update(UpdateMarkingPanel body)
    {
        return ApiConnection.Patch<MarkingPanel>(
            ApiEndpoints.MarkingPanelById(body.ExaminationId, body.PanelId), body);
    }
    
    public MarkingPanelMembersClient Members { get; }
}