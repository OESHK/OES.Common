namespace OES;

/// <summary>
/// The status of a specific answer script slice.
/// </summary>
public enum ScriptEntryStatus
{
    /// <summary>
    /// The slice is open for marking.
    /// </summary>
    Open = 0,
    
    Marked = 1,
    
    Empty = 2,
    
    ImageIrregularity = 3,
    
    PanelIrregularity = 4,
    
    OtherIrregularity = 5,
}