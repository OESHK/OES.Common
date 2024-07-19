using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents a definition for a non-MC Question.
/// </summary>
public class NonMCQuestionDefinition : QuestionDefinition
{
    /// <summary>
    /// Creates an instance for a non-MCQ definition
    /// </summary>
    [JsonConstructor]
    internal NonMCQuestionDefinition(
        [JsonProperty("non_mcq_definition_id")]
        int id,
        int scriptDefinitionId,
        [JsonProperty("question_no")]
        int questionNumber,
        string questionName,
        int    maxMarks,
        bool   allowHalfMarks) : base(id, scriptDefinitionId, questionNumber, questionName)
    {
        MaximumMarks   = maxMarks;
        AllowHalfMarks = allowHalfMarks;
    }
    
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
    
    // ToUpdate() is not supported. This object cannot be modified upon creation.
}