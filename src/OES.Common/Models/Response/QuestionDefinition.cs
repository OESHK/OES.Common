namespace OES;

/// <summary>
/// The base class for a question's definition.
/// Intended for internal use.
/// </summary>
public abstract class QuestionDefinition
{
    protected QuestionDefinition(int id, int scriptDefinitionId, int questionNumber, string questionName)
    {
        DefinitionId = id;
        ScriptDefinitionId = scriptDefinitionId;
        QuestionNumber = questionNumber;
        QuestionName = questionName;
    }

    /// <summary>
    /// The ID of this question definition.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The ID of the script definition to which this question definition belongs.
    /// </summary>
    public int ScriptDefinitionId { get; }
    
    /// <summary>
    /// The number of this question.
    /// </summary>
    public int QuestionNumber { get; }
    
    /// <summary>
    /// The short name of this question. Used in partial questions.
    /// E.g., 1(a)(ii) is a question under question number 1.
    /// <seealso cref="QuestionNumber"/>
    /// </summary>
    public string QuestionName { get; }
}