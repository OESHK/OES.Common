namespace OES;

/// <summary>
/// Represents a slice of a candidate's answer script.
/// </summary>
public class CandidateScriptSlice
{
    /// <summary>
    /// Creates an instance for a script slice.
    /// </summary>
    public CandidateScriptSlice(int id, string candidateId, int definitionId, byte[] scriptImage)
    {
        SliceId = id;
        CandidateId = candidateId;
        DefinitionId = definitionId;
        ScriptImage = scriptImage;
    }

    /// <summary>
    /// The ID of the slice.
    /// </summary>
    public int SliceId { get; }
    
    /// <summary>
    /// The ID of the candidate to whom the slice belongs.
    /// </summary>
    public string CandidateId { get; }
    
    /// <summary>
    /// The configurations used for slicing the script slice.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The bytes of the image file of the slice.
    /// </summary>
    public byte[] ScriptImage { get; }
}