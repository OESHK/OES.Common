namespace OES;

/// <summary>
/// A definition for a question on an MC sheet.
/// </summary>
public struct MCSheetQuestionDefinition
{
    public MCSheetQuestionDefinition(int questionNumber, MCSheetAnswer answer)
    {
        QuestionNumber = questionNumber;
        Answer         = answer;
    }
    
    /// <summary>
    /// The number of the question.
    /// </summary>
    public int QuestionNumber { get; set; }
    
    /// <summary>
    /// The correct answer of the question.
    /// </summary>
    public MCSheetAnswer Answer { get; set; }
}

public enum MCSheetAnswer
{
    A = 0,
    
    B = 1,
    
    C = 2,
    
    D = 3,
    
    /// <summary>
    /// The question should be skipped when reading the MC sheet.
    /// </summary>
    Skip = 4
}