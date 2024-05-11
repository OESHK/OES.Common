namespace OES;

/// <summary>
/// Represents a definition for a non-MC Question.
/// </summary>
public class NonMCQuestionDefinition : QuestionDefinition
{
    /// <summary>
    /// Creates an instance for a non-MCQ definition
    /// </summary>
    public NonMCQuestionDefinition(
        int id,
        int scriptDefinitionId,
        int panelId, 
        int questionNumber,
        string questionName,
        int maxMarks,
        bool allowHalfMarks) : base(id, scriptDefinitionId, panelId, questionNumber, questionName)
    {
        MaximumMarks = maxMarks;
        AllowHalfMarks = allowHalfMarks;
    }
    
    /// <summary>
    /// The maximum marks can be given to this question.
    /// </summary>
    public int MaximumMarks { get; }
    
    /// <summary>
    /// Whether to allow markers give 0.5 marks.
    /// </summary>
    public bool AllowHalfMarks { get; }
}