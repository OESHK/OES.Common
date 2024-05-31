namespace OES;

/// <summary>
/// Represents a question number that is linked to a specific marking panel.
/// </summary>
public struct MarkingPanelQuestion
{
    public MarkingPanelQuestion(int scriptDefinitionId, int questionNumber)
    {
        ScriptDefinitionId = scriptDefinitionId;
        QuestionNumber     = questionNumber;
    }
    
    /// <summary>
    /// The ID of the script definition that the question is linked to.
    /// </summary>
    public int ScriptDefinitionId { get; }
    
    /// <summary>
    /// The number of the question.
    /// </summary>
    public int QuestionNumber { get; }

    public static bool operator ==(MarkingPanelQuestion first, MarkingPanelQuestion second)
        => first.ScriptDefinitionId == second.ScriptDefinitionId && first.QuestionNumber == second.QuestionNumber;

    public static bool operator !=(MarkingPanelQuestion first, MarkingPanelQuestion second) => !(first == second);
}