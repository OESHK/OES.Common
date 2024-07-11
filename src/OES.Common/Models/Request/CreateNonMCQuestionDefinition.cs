using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to Create a Non-MCQ Definition.
/// </summary>
public class CreateNonMCQuestionDefinition
{
    public CreateNonMCQuestionDefinition(int scriptDefinitionId, int questionNumber, string questionName, int maximumMarks, bool allowHalfMarks)
    {
        ScriptDefinitionId = scriptDefinitionId;
        QuestionNumber     = questionNumber;
        QuestionName       = questionName;
        MaximumMarks       = maximumMarks;
        AllowHalfMarks     = allowHalfMarks;
    }

    /// <inheritdoc cref="NonMCQuestionDefinition.ScriptDefinitionId"/>
    [JsonIgnore]
    public int ScriptDefinitionId { get; set; }
    
    /// <inheritdoc cref="NonMCQuestionDefinition.QuestionNumber"/>
    [JsonProperty("question_no")]
    public int QuestionNumber { get; set; }
    
    /// <inheritdoc cref="NonMCQuestionDefinition.QuestionName"/>
    public string QuestionName { get; set; }
    
    /// <inheritdoc cref="NonMCQuestionDefinition.MaximumMarks"/>
    [JsonProperty("max_marks")]
    public int MaximumMarks { get; set; }
    
    /// <inheritdoc cref="NonMCQuestionDefinition.AllowHalfMarks"/>
    public bool AllowHalfMarks { get; set; }
}