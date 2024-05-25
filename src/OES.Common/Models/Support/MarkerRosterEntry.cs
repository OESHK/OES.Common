namespace OES;

/// <summary>
/// Represents a marker's rostering in a marking panel.
/// </summary>
public struct MarkerRosterEntry
{
    /// <summary>
    /// Create a new request to roster a marker into an existing marking panel.
    /// </summary>
    /// <param name="markerId">The ID of the marker to be enrolled.</param>
    /// <param name="panelId">The ID of the marking panel into which the marker is to be enrolled.</param>
    /// <param name="markerRole">The role of the marker to be enrolled.</param>
    public MarkerRosterEntry(string markerId, int panelId, MarkerRole markerRole) : this(markerId, markerRole)
    {
        PanelId = panelId;
    }

    /// <summary>
    /// Create a new request to roster a marker into a new marking panel.
    /// Used only with <see cref="CreateMarkingPanel"/> as the Panel ID is unknown at this stage.
    /// </summary>
    /// <param name="markerId">The ID of the marker to be enrolled.</param>
    /// <param name="markerRole">The role of the marker to be enrolled.</param>
    internal MarkerRosterEntry(string markerId, MarkerRole markerRole)
    {
        MarkerId = markerId;
        MarkerRole = markerRole;
    }
    
    /// <summary>
    /// The ID of the marker.
    /// </summary>
    public string MarkerId { get; set; }
    
    /// <summary>
    /// The ID of the marking panel.
    /// </summary>
    public int? PanelId { get; set; }
    
    /// <summary>
    /// The role of the marker in the marking panel.
    /// </summary>
    public MarkerRole MarkerRole { get; set; }
}