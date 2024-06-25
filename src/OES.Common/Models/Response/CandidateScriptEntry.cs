using System.Globalization;
using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents an entry of candidate's script under a marking panel.
/// </summary>
public class CandidateScriptEntry
{
    /// <summary>
    /// Creates an instance for a script entry.
    /// </summary>
    [JsonConstructor]
    internal CandidateScriptEntry(int id, string candidateId, int panelId, ScriptEntryStatus entryStatus)
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
    public string CandidateId { get; }
    
    /// <summary>
    /// The ID of the marking panel for which will be responsible marking this entry.
    /// </summary>
    public int PanelId { get; }
    
    /// <summary>
    /// The status of the entry.
    /// </summary>
    public ScriptEntryStatus EntryStatus { get; }

    /// <summary>
    /// Gets an object representing a create <see cref="CandidateScriptEntry"/> request.
    /// </summary>
    public static CreateCandidateScriptEntry ToCreate(string candidateId, int panelId)
        => new(candidateId, panelId);

    /// <summary>
    /// Gets an object representing a update existing <see cref="CandidateScriptEntry"/> request.
    /// </summary>
    public UpdateCandidateScriptEntry ToUpdate() => new(this);

    /// <summary>
    /// Gets an object representing a delete <see cref="CandidateScriptEntry"/> request.
    /// The images of the script entry will also be deleted.
    /// </summary>
    public DeleteObject ToDelete() => new(EntryId.ToString(CultureInfo.InvariantCulture));
}