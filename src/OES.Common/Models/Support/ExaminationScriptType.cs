namespace OES;

/// <summary>
/// The type of examination script.
/// </summary>
public enum ExaminationScriptType
{
    /// <summary>
    /// A standard A4 multiple-choice answer sheet.
    /// </summary>
    MCSheet = 0,
    
    /// <summary>
    /// A standard oral exam's (typically, English Language) score sheet.
    /// </summary>
    OralMarkSheet = 1,
    
    /// <summary>
    /// A question-answer book with mixed types of questions.
    /// </summary>
    QuestionAnswerBook = 2,
    
    /// <summary>
    /// A standard DSE answer book.
    /// </summary>
    AnswerBook = 3
}