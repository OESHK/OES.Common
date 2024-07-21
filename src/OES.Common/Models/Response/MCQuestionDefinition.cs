using System.Globalization;
using Newtonsoft.Json;

namespace OES;

/// <summary>
/// Represents a definition of an MC Question.
/// </summary>
public class MCQuestionDefinition
{
    /// <summary>
    /// Creates an instance of an MCQ definition.
    /// </summary>
    [JsonConstructor]
    internal MCQuestionDefinition(
        int                                     mcqDefinitionId,
        int                                     scriptDefinitionId,
        int                                     panelId,
        [JsonProperty("question_no")]
        int                                     questionNumber,
        string                                  questionName,
        ImageMargin                             questionImageMargin,
        IReadOnlyCollection<MCOptionDefinition> options,
        MCMarkingMode                           markingMode,
        int                                     marksPerOption)
    {
        McqDefinitionId     = mcqDefinitionId;
        ScriptDefinitionId  = scriptDefinitionId;
        QuestionNumber      = questionNumber;
        QuestionName        = questionName;
        PanelId             = panelId;
        QuestionImageMargin = questionImageMargin;
        Options             = options;
        MarkingMode         = markingMode;
        MarksPerOption      = marksPerOption;
    }
    
    /// <summary>
    /// The ID of the MCQ definition.
    /// </summary>
    public int McqDefinitionId { get; }
    
    /// <summary>
    /// The ID of the examination script definition to which the MCQ definition belongs.
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
    
    /// <summary>
    /// The ID of the marking panel which will be responsible for marking this question.
    /// The panel must be an MC marking panel.
    /// </summary>
    public int PanelId { get; }

    /// <summary>
    /// The range of the question's image.
    /// </summary>
    public ImageMargin QuestionImageMargin { get; }
    
    /// <summary>
    /// The list of definitions for each option.
    /// </summary>
    public IReadOnlyCollection<MCOptionDefinition> Options { get; }

    /// <summary>
    /// The mode used when marking this question.
    /// </summary>
    public MCMarkingMode MarkingMode { get; }
    
    /// <summary>
    /// The marks to be given for each correct choice.
    /// This value is used as the total mark of the question
    /// when <see cref="MarkingMode"/> is set to GiveOnAllCorrect.
    /// </summary>
    public int MarksPerOption { get; }

    /// <summary>
    /// Gets an object representing a new Create MCQ definition request.
    /// </summary>
    /// <param name="questionNumber">The numeric number of this question.</param>
    /// <param name="questionName">The short name of this question.</param>
    /// <param name="panelId">The ID of the panel which will be responsible for marking the question.</param>
    /// <param name="questionImageMargin">The image margins of the question.</param>
    /// <param name="options">The list of image margins of each option.</param>
    /// <param name="markingMode">The mode of marking this MC question.</param>
    /// <param name="marksPerOption">The marks to be given per option.</param>
    public static CreateMCQuestionDefinition ToCreate(
        int                             questionNumber,
        string                          questionName,
        int                             panelId,
        ImageMargin                     questionImageMargin,
        ICollection<MCOptionDefinition> options,
        MCMarkingMode                   markingMode,
        int                             marksPerOption
    )
        => new(questionNumber, questionName, panelId, questionImageMargin, options, markingMode, marksPerOption);
}