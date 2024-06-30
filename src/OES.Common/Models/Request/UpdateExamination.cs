using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to update information of an existing examination.
/// </summary>
public class UpdateExamination
{
    internal UpdateExamination(Examination examination)
    {
        ExaminationId = examination.ExaminationId;
    }
    
    /// <inheritdoc cref="Examination.ExaminationId"/>
    [JsonIgnore]
    public int ExaminationId { get; }

    /// <inheritdoc cref="Examination.ExaminationLevel"/>
    public string? ExaminationLevel { get; set; }
    
    /// <inheritdoc cref="Examination.ExaminationYear"/>
    public string? ExaminationYear { get; set; }
    
    /// <inheritdoc cref="Examination.ExaminationName"/>
    public string? ExaminationName { get; set; }
    
    /// <inheritdoc cref="Examination.SubjectCode"/>
    public string? SubjectCode { get; set; }
    
    /// <inheritdoc cref="Examination.SubjectName"/>
    public string? SubjectName { get; set; }
    
    /// <inheritdoc cref="Examination.PaperCode"/>
    public string? PaperCode { get; set; }
    
    /// <inheritdoc cref="Examination.PaperName"/>
    public string? PaperName { get; set; }
}