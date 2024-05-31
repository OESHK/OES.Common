namespace OES;

/// <summary>
/// Creates a new <see cref="CandidateScriptEntry"/>.
/// </summary>
public class CreateCandidateScriptEntry
{
    public CreateCandidateScriptEntry(string candidateId, int panelId)
    {
        CandidateId = candidateId;
        PanelId     = panelId;
        EntryStatus = ScriptEntryStatus.Open; // must be default to Open
    }

    /// <inheritdoc cref="CandidateScriptEntry.CandidateId"/>
    public string CandidateId { get; set; }
    
    /// <inheritdoc cref="CandidateScriptEntry.PanelId"/>
    public int PanelId { get; set; }
    
    /// <inheritdoc cref="CandidateScriptEntry.EntryStatus"/>
    public ScriptEntryStatus EntryStatus { get; }
}