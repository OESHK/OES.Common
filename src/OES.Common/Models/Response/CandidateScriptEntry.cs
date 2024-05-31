namespace OES;

/// <summary>
/// Represents an entry of candidate's script under a marking panel.
/// </summary>
public class CandidateScriptEntry
{
    /// <summary>
    /// Creates an instance for a script entry.
    /// </summary>
    public CandidateScriptEntry(int id, int candidateId, int panelId, ScriptEntryStatus entryStatus)
    {
        EntryId = id;
        CandidateId = candidateId;
        PanelId = panelId;
        EntryStatus = entryStatus;
    }

    /// <summary>
    /// The ID of the entry.
    /// </summary>
    public int EntryId { get; }
    
    /// <summary>
    /// The ID of the candidate to which this entry belongs.
    /// </summary>
    public int CandidateId { get; }
    
    /// <summary>
    /// The ID of the marking panel for which will be responsible marking this entry.
    /// </summary>
    public int PanelId { get; }
    
    /// <summary>
    /// The status of the entry.
    /// </summary>
    public ScriptEntryStatus EntryStatus { get; }
}