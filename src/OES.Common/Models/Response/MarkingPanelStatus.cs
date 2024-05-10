namespace OES;

/// <summary>
/// The status of the marking panel.
/// </summary>
public enum MarkingPanelStatus
{
    /// <summary>
    /// The panel is closed for markers. Markers can neither mark nor view the scripts in the panel.
    /// </summary>
    Closed = 0,
    
    /// <summary>
    /// The panel is open for marking. Markers can view and mark the scripts in the panel.
    /// </summary>
    OpenForMarking = 1,
    
    /// <summary>
    /// The panel is open for viewing. Markers can view the scripts in the panel, but not marking them.
    /// </summary>
    OpenForViewing = 2
}