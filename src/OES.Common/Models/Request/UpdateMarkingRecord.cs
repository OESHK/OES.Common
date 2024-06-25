using Newtonsoft.Json;

namespace OES;

/// <summary>
/// An object representing a request to update an existing <see cref="MarkingRecord"/>.
/// </summary>
public class UpdateMarkingRecord
{
    internal UpdateMarkingRecord(MarkingRecord record)
    {
        RecordId = record.RecordId;
    }
    
    /// <inheritdoc cref="MarkingRecord.RecordId"/>
    public int RecordId { get; }
    
    /// <inheritdoc cref="MarkingRecord.EndTime"/>
    [JsonProperty("marking_end_time")]
    public DateTime? EndTime { get; set; }

    /// <inheritdoc cref="MarkingRecord.Annotations"/>
    public ICollection<IAnnotation>? Annotations { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.Marks"/>
    public IDictionary<int, double>? Marks { get; set; }
    
    /// <inheritdoc cref="MarkingRecord.Remarks"/>
    public string? Remarks { get; set; }
}