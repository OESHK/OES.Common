namespace OES;

/// <summary>
/// Represents one marker's marking record.
/// </summary>
public class MarkingRecord
{
    public MarkingRecord(
        int id,
        string markerId,
        int entryId,
        DateTime startTime,
        DateTime? endTime,
        ICollection<IAnnotation> annotations,
        Dictionary<int, double> marks,
        string remarks
        )
    {
        RecordId = id;
        MarkerId = markerId;
        EntryId = entryId;
        StartTime = startTime;
        EndTime = endTime;
        Annotations = annotations;
        Marks = marks;
        Remarks = remarks;
    }
    
    /// <summary>
    /// The ID of the marking record.
    /// </summary>
    public int RecordId { get; }
    
    /// <summary>
    /// The ID of the marker.
    /// </summary>
    public string MarkerId { get; }
    
    /// <summary>
    /// The ID of the script entry marked.
    /// </summary>
    public int EntryId { get; }
    
    /// <summary>
    /// The time when the marker started marking.
    /// </summary>
    public DateTime StartTime { get; }
    
    /// <summary>
    /// The time when the marker finished marking and submitted the marks. Null when marking has not finished.
    /// </summary>
    public DateTime? EndTime { get; }

    /// <summary>
    /// The annotations the marker has made on the script.
    /// </summary>
    public ICollection<IAnnotation> Annotations { get; }
    
    /// <summary>
    /// The marks the marker has given to the candidate.
    /// Stored in a QuestionID:Marks key pair.
    /// </summary>
    public Dictionary<int, double> Marks { get; }
    
    /// <summary>
    /// The remarks the marker has entered. Only visible to the marker him/herself.
    /// </summary>
    public string Remarks { get; }
}