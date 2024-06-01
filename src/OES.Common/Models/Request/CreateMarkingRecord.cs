using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to create a new <see cref="MarkingRecord"/>.
/// </summary>
public class CreateMarkingRecord
{
    public CreateMarkingRecord(
        string                    markerId,
        int                       markedEntryId,
        DateTime                  startTime,
        DateTime?                 endTime,
        ICollection<IAnnotation>? annotations,
        IDictionary<int, double>  marks,
        string?                   remarks)
    {
        MarkerId    = markerId;
        MarkedEntryId     = markedEntryId;
        StartTime   = startTime;
        EndTime     = endTime;
        Annotations = annotations;
        Marks       = marks;
        Remarks     = remarks;
    }

    /// <inheritdoc cref="MarkingRecord.MarkerId"/>
    public string MarkerId { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.MarkedEntryId"/>
    public int MarkedEntryId { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.StartTime"/>
    [JsonProperty("marking_start_time")]
    public DateTime StartTime { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.EndTime"/>
    [JsonProperty("marking_end_time")]
    public DateTime? EndTime { get; set; }

    /// <inheritdoc cref="MarkingRecord.Annotations"/>
    public ICollection<IAnnotation>? Annotations { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.Marks"/>
    public IDictionary<int, double> Marks { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.Remarks"/>
    public string? Remarks { get; set; }
}