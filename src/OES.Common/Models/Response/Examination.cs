using System.Globalization;
using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents an Examination.
/// </summary>
public class Examination
{
    [JsonConstructor]
    internal Examination(
        int               examinationId,
        string?           examinationLevel,
        string?           examinationName,
        string?           examinationYear,
        string            subjectCode,
        string?           subjectName,
        string            paperCode,
        string?           paperName,
        ExaminationStatus examinationStatus)
    {
        ExaminationId     = examinationId;
        ExaminationLevel  = examinationLevel;
        ExaminationName   = examinationName;
        ExaminationYear   = examinationYear;
        SubjectCode       = subjectCode;
        SubjectName       = subjectName;
        PaperCode         = paperCode;
        PaperName         = paperName;
        ExaminationStatus = examinationStatus;
    }

    /// <summary>
    /// The identifier of the examination.
    /// </summary>
    public int ExaminationId { get; private set; }
    
    /// <summary>
    /// The level of the exam. E.g. DSE, UT, TSA etc.
    /// </summary>
    public string? ExaminationLevel { get; }
    
    /// <summary>
    /// The name of the exam.
    /// </summary>
    public string? ExaminationName { get; }
    
    /// <summary>
    /// The year of the exam. Can be non-integers, e.g. 2023/24 is acceptable.
    /// </summary>
    public string? ExaminationYear { get; }
    
    /// <summary>
    /// The code of the subject. This code should appear on a candidate's barcode.
    /// </summary>
    public string SubjectCode { get; }
    
    /// <summary>
    /// The name of the subject.
    /// </summary>
    public string? SubjectName { get; }
    
    /// <summary>
    /// The code of the paper. Typically, this should be 3-char long. E.g. 003.
    /// </summary>
    public string PaperCode { get; }
    
    /// <summary>
    /// The name of the paper. E.g. LT - Listening.
    /// </summary>
    public string? PaperName { get; }
    
    public ExaminationStatus ExaminationStatus { get; internal set; }

    /// <summary>
    /// Gets an object representing a Create Examination request.
    /// </summary>
    public static CreateExamination ToCreate(
        string? examinationLevel,
        string? examinationYear,
        string? examinationName,
        string  subjectCode,
        string? subjectName,
        string  paperCode,
        string? paperName)
        => new(examinationLevel, examinationYear, examinationName, subjectCode, subjectName, paperCode, paperName);

    /// <inheritdoc cref="ToCreate(string?,string?,string?,string,string?,string,string?)"/>
    public static CreateExamination ToCreate(string subjectCode, string paperCode)
        => ToCreate(null, null, null, subjectCode, null, paperCode, null);

    /// <summary>
    /// Gets an object representing an Update Examination request.
    /// </summary>
    public UpdateExamination ToUpdate() => new(this);
}