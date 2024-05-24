namespace OES;

/// <summary>
/// A request to create a new examination. Examination ID is assigned by server automatically.
/// </summary>
public class CreateExamination
{
    public CreateExamination(
        string? examinationLevel,
        string? examinationYear,
        string? examinationName,
        string subjectCode,
        string? subjectName,
        string paperCode,
        string? paperName
        )
    {
        ExaminationLevel = examinationLevel;
        ExaminationYear = examinationYear;
        ExaminationName = examinationName;
        SubjectCode = subjectCode;
        SubjectName = subjectName;
        PaperCode = paperCode;
        PaperName = paperName;
    }

    public CreateExamination(string subjectCode, string paperCode)
        : this(null, null, null, subjectCode, null, paperCode, null) { }

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