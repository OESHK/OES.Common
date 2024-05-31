namespace OES;

/// <summary>
/// Represents a request to update an existing <see cref="CandidateScriptEntry"/>.
/// Only its <see cref="ScriptEntryStatus"/> can be modified.
/// </summary>
public class UpdateCandidateScriptEntry
{
    internal UpdateCandidateScriptEntry(CandidateScriptEntry entry)
    {
        EntryId     = entry.EntryId;
        EntryStatus = entry.EntryStatus;
    }
    
    /// <inheritdoc cref="CandidateScriptEntry.EntryId"/>
    public int EntryId { get; }
    
    /// <inheritdoc cref="CandidateScriptEntry.EntryStatus"/>
    public ScriptEntryStatus EntryStatus { get; set; }
}