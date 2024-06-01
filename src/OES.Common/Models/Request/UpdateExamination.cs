namespace OES;

/// <summary>
/// A request to update information of an existing examination.
/// </summary>
public class UpdateExamination
{
    internal UpdateExamination(Examination examination)
    {
        ExaminationId    = examination.ExaminationId;
        ExaminationLevel = examination.ExaminationLevel;
        ExaminationYear  = examination.ExaminationYear;
        ExaminationName  = examination.ExaminationName;
        SubjectCode      = examination.SubjectCode;
        SubjectName      = examination.SubjectName;
        PaperCode        = examination.PaperCode;
        PaperName        = examination.PaperName;
    }
    
    /// <inheritdoc cref="Examination.ExaminationId"/>
    public int ExaminationId { get; }
    
    /// <inheritdoc cref="Examination.ExaminationLevel"/>
    public string? ExaminationLevel { get; set; }
    
    /// <inheritdoc cref="Examination.ExaminationYear"/>
    public string? ExaminationYear { get; set; }
    
    /// <inheritdoc cref="Examination.ExaminationName"/>
    public string? ExaminationName { get; set; }
    
    /// <inheritdoc cref="Examination.SubjectCode"/>
    public string SubjectCode { get; set; }
    
    /// <inheritdoc cref="Examination.SubjectName"/>
    public string? SubjectName { get; set; }
    
    /// <inheritdoc cref="Examination.PaperCode"/>
    public string PaperCode { get; set; }
    
    /// <inheritdoc cref="Examination.PaperName"/>
    public string? PaperName { get; set; }
}