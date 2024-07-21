using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents a definition for a non-MC Question.
/// </summary>
public class NonMCQuestionDefinition
{
    /// <summary>
    /// Creates an instance for a non-MCQ definition
    /// </summary>
    [JsonConstructor]
    internal NonMCQuestionDefinition(
        int nonMcqDefinitionId,
        int scriptDefinitionId,
        [JsonProperty("question_no")]
        int questionNumber,
        string questionName,
        int    maxMarks,
        bool   allowHalfMarks)
    {
        NonMcqDefinitionId = nonMcqDefinitionId;
        ScriptDefinitionId = scriptDefinitionId;
        QuestionNumber     = questionNumber;
        QuestionName       = questionName;
        MaximumMarks       = maxMarks;
        AllowHalfMarks     = allowHalfMarks;
    }
    
    /// <summary>
    /// The ID of this question definition.
    /// </summary>
    public int NonMcqDefinitionId { get; }
    
    /// <summary>
    /// The ID of the script definition to which this question definition belongs.
    /// </summary>
    public int ScriptDefinitionId { get; }
    
    /// <summary>
    /// The number of this question.
    /// </summary>
    [JsonProperty("question_no")]
    public int QuestionNumber { get; }
    
    /// <summary>
    /// The short name of this question. Used in partial questions.
    /// E.g., 1(a)(ii) is a question under question number 1.
    /// <seealso cref="QuestionNumber"/>
    /// </summary>
    public string QuestionName { get; }
    
    /// <summary>
    /// The maximum marks can be given to this question.
    /// </summary>
    [JsonProperty("max_marks")]
    public int MaximumMarks { get; }
    
    /// <summary>
    /// Whether to allow markers give 0.5 marks.
    /// </summary>
    public bool AllowHalfMarks { get; }

    /// <summary>
    /// Gets an object representing a Create Non-MCQ definition request.
    /// </summary>
    /// <param name="scriptDefinitionId">The ID of the exam script definition to which this question definition belongs.</param>
    /// <param name="questionNumber">The numeric number of this question.</param>
    /// <param name="questionName">The short name of this question.</param>
    /// <param name="maximumMarks">The maximum marks can be given to this question.</param>
    /// <param name="allowHalfMarks">Whether to allow markers give 0.5 marks.</param>
    public static CreateNonMCQuestionDefinition ToCreate(
        int scriptDefinitionId, int questionNumber, string questionName, int maximumMarks, bool allowHalfMarks)
        => new(scriptDefinitionId, questionNumber, questionName, maximumMarks, allowHalfMarks);
}