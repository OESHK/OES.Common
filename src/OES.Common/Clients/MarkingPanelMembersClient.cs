using System.Net;
using OES.Internal;

namespace OES;

/// <summary>
/// A client for interacting with API endpoints for members of a marking panel.
/// </summary>
public class MarkingPanelMembersClient : ApiClient
{
    internal MarkingPanelMembersClient(ApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <summary>
    /// Assigns a marker user as a general marker in a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="markerId">The ID of the marker user.</param>
    /// <returns>Whether the request was successful.</returns>
    public async Task<bool> AddGeneralMarker(int examinationId, int panelId, string markerId)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNullOrEmpty(markerId, nameof(markerId));

        var status = await Connection.Post(
            ApiEndpoints.MarkingPanelMembersGeneralMarkers(examinationId, panelId),
            null,
            new Dictionary<string, object> { { "marker_id", markerId } }).ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }

    /// <summary>
    /// Assigns a marker user as a supervisor in a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="markerId">The ID of the marker user.</param>
    /// <returns>Whether the request was successful.</returns>
    public async Task<bool> AddSupervisor(int examinationId, int panelId, string markerId)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNullOrEmpty(markerId, nameof(markerId));

        var status = await Connection.Post(
            ApiEndpoints.MarkingPanelMembersSupervisors(examinationId, panelId),
            null,
            new Dictionary<string, object> { { "marker_id", markerId } }).ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }

    /// <summary>
    /// Removes an existing general marker from a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="markerId">The ID of the marker user.</param>
    /// <returns>Whether the request was successful.</returns>
    public async Task<bool> RemoveGeneralMarker(int examinationId, int panelId, string markerId)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNullOrEmpty(markerId, nameof(markerId));

        var status = await Connection.Post(
            ApiEndpoints.MarkingPanelMembersGeneralMarkerById(examinationId, panelId, markerId)).ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }

    /// <summary>
    /// Removes an existing supervisor from a marking panel.
    /// </summary>
    /// <param name="examinationId">The ID of the examination.</param>
    /// <param name="panelId">The ID of the marking panel.</param>
    /// <param name="markerId">The ID of the marker user.</param>
    /// <returns>Whether the request was successful.</returns>
    public async Task<bool> RemoveSupervisor(int examinationId, int panelId, string markerId)
    {
        Ensure.ArgumentNotNull(examinationId, nameof(examinationId));
        Ensure.ArgumentNotNull(panelId, nameof(panelId));
        Ensure.ArgumentNotNullOrEmpty(markerId, nameof(markerId));

        var status = await Connection.Post(
            ApiEndpoints.MarkingPanelMembersSupervisorById(examinationId, panelId, markerId)).ConfigureAwait(false);

        return status == HttpStatusCode.NoContent;
    }
}