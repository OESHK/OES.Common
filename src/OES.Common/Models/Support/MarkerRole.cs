namespace OES;

/// <summary>
/// The marker's role in a marking panel.
/// </summary>
public enum MarkerRole
{
    /// <summary>
    /// A supervisor of the marking panel. Once assigned, the marker automatically gain a role of supervisor
    /// in all marking panels of the same examination.
    /// </summary>
    Supervisor = 0,
    
    /// <summary>
    /// A general marker of the marking panel.
    /// </summary>
    Marker = 1,
}