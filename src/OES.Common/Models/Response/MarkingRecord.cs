using System.Globalization;
using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents one marker's marking record.
/// </summary>
public class MarkingRecord
{
    /// <summary>
    /// Creates an instance of a MarkingRecord.
    /// </summary>
    [JsonConstructor]
    internal MarkingRecord(
        int                       recordId,
        string                    markerId,
        int                       markedEntryId,
        DateTime                  startTime,
        DateTime?                 endTime,
        ICollection<IAnnotation>? annotations,
        Dictionary<int, double>   marks,
        string?                   remarks
        )
    {
        RecordId    = recordId;
        MarkerId    = markerId;
        MarkedEntryId     = markedEntryId;
        StartTime   = startTime;
        EndTime     = endTime;
        Annotations = annotations;
        Marks       = marks;
        Remarks     = remarks;
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
    public int MarkedEntryId { get; }
    
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
    public ICollection<IAnnotation>? Annotations { get; }
    
    /// <summary>
    /// The marks the marker has given to the candidate.
    /// Stored in a QuestionID:Marks key pair.
    /// </summary>
    public IReadOnlyDictionary<int, double> Marks { get; }
    
    /// <summary>
    /// The remarks the marker has entered. Only visible to the marker him/herself.
    /// </summary>
    public string? Remarks { get; }

    /// <summary>
    /// Gets an object representing a create <see cref="MarkingRecord"/> request.
    /// </summary>
    public static CreateMarkingRecord ToCreate(
        string                    markerId,
        int                       markedEntryId,
        DateTime                  startTime,
        DateTime?                 endTime,
        ICollection<IAnnotation>? annotations,
        Dictionary<int, double>   marks,
        string?                   remarks)
        => new(markerId, markedEntryId, startTime, endTime, annotations, marks, remarks);

    /// <summary>
    /// Gets an object representing a request to update an existing <see cref="MarkingRecord"/>.
    /// </summary>
    public UpdateMarkingRecord ToUpdate() => new(this);

    /// <summary>
    /// Gets an object representing a request to delete an existing <see cref="MarkingRecord"/>.
    /// </summary>
    /// <returns></returns>
    public DeleteObject ToDelete() => new(RecordId.ToString(CultureInfo.InvariantCulture));
}