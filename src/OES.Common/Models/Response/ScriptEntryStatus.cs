namespace OES;

/// <summary>
/// The status of a specific answer script entry.
/// </summary>
public enum ScriptEntryStatus
{
    /// <summary>
    /// The entry is open for marking.
    /// </summary>
    Open = 0,
    
    /// <summary>
    /// The entry is marked and no more marking is required.
    /// </summary>
    Marked = 1,
    
    /// <summary>
    /// The entry is marked as an empty script. 0 marks will be scored and no other markers will get this entry.
    /// </summary>
    Empty = 2,
    
    /// <summary>
    /// There is unresolved irregularity regarding script image with this entry. Markers will not be able to mark.
    /// </summary>
    ImageIrregularity = 3,
    
    /// <summary>
    /// There is unresolved irregularity regarding the marking panel, i.e., it is assigned to an incorrect panel.
    /// Admins will need to manually re-assign the scripts to the correct panel.
    /// </summary>
    PanelIrregularity = 4,
    
    /// <summary>
    /// There are other irregularities which prevent markers from marking the entry.
    /// </summary>
    OtherIrregularity = 5,
}