namespace OES;

/// <summary>
/// Represents a marker's rostering in a marking panel.
/// </summary>
public struct MarkerRosterEntry
{
    public MarkerRosterEntry(string markerId, int panelId, MarkerRole markerRole)
    {
        MarkerId = markerId;
        PanelId = panelId;
        MarkerRole = markerRole;
    }
    
    /// <summary>
    /// The ID of the marker.
    /// </summary>
    public string MarkerId { get; set; }
    
    /// <summary>
    /// The ID of the marking panel.
    /// </summary>
    public int PanelId { get; set; }
    
    /// <summary>
    /// The role of the marker in the marking panel.
    /// </summary>
    public MarkerRole MarkerRole { get; set; }
}