using System.Globalization;

namespace OES;

/// <summary>
/// Represents a definition of an MC Question.
/// </summary>
public class MCQuestionDefinition : QuestionDefinition
{
    /// <summary>
    /// Creates an instance of an MCQ definition.
    /// </summary>
    public MCQuestionDefinition(
        int                                     id,
        int                                     scriptDefinitionId,
        int                                     panelId,
        int                                     questionNumber,
        string                                  questionName,
        ImageMargin                             questionRange,
        IReadOnlyCollection<MCOptionDefinition> optionsDefinition,
        MCMarkingMode                           markingMode,
        int                                     markPerOption
        ) : base(id, scriptDefinitionId, questionNumber, questionName)
    {
        PanelId = panelId;
        QuestionRange = questionRange;
        OptionsDefinition = optionsDefinition;
        MarkingMode = markingMode;
        MarkPerOption = markPerOption;
    }
    
    /// <summary>
    /// The ID of the marking panel which will be responsible for marking this question.
    /// The panel must be an MC marking panel.
    /// </summary>
    public int PanelId { get; }

    /// <summary>
    /// The range of the question's image.
    /// </summary>
    public ImageMargin QuestionRange { get; }
    
    /// <summary>
    /// The collection of options and their respective definitions.
    /// </summary>
    public IReadOnlyCollection<MCOptionDefinition> OptionsDefinition { get; }

    /// <summary>
    /// The collection of correct options.
    /// </summary>
    public IReadOnlyCollection<MCOptionDefinition> CorrectOptions 
        => OptionsDefinition.Where(def => def.IsCorrect).ToList();

    /// <summary>
    /// The mode used when marking this question.
    /// </summary>
    public MCMarkingMode MarkingMode { get; }
    
    /// <summary>
    /// The marks to be given for each correct choice.
    /// This value is used as the total mark of the question
    /// when <see cref="MarkingMode"/> is set to GiveOnAllCorrect.
    /// </summary>
    public int MarkPerOption { get; }

    /// <summary>
    /// Gets an object representing a new Create MCQ definition request.
    /// </summary>
    /// <param name="scriptDefinitionId">The ID of the exam script definition to which this question definition belongs.</param>
    /// <param name="questionNumber">The numeric number of this question.</param>
    /// <param name="questionName">The short name of this question.</param>
    /// <param name="panelId">The ID of the panel which will be responsible for marking the question.</param>
    /// <param name="questionRange">The image margins of the question.</param>
    /// <param name="optionsDefinition">The list of image margins of each option.</param>
    /// <param name="markingMode">The mode of marking this MC question.</param>
    /// <param name="markPerOption">The marks to be given per option.</param>
    /// <seealso cref="MCMarkingMode.PenaltyOnIncorrect"/>
    /// <seealso cref="MCMarkingMode.GiveOnAllCorrect"/>
    public static CreateMCQuestionDefinition ToCreate(
        int                             scriptDefinitionId,
        int                             questionNumber,
        string                          questionName,
        int                             panelId,
        ImageMargin                     questionRange,
        ICollection<MCOptionDefinition> optionsDefinition,
        MCMarkingMode                   markingMode,
        int                             markPerOption
    )
        => new(scriptDefinitionId, questionNumber, questionName, panelId, questionRange, optionsDefinition, markingMode,
            markPerOption);
    
    // ToUpdate() not implemented as this object cannot be modified upon creation.

    /// <summary>
    /// Gets an object representing a delete MCQ definition request.
    /// </summary>
    public DeleteObject ToDelete()
        => new(DefinitionId.ToString(CultureInfo.InvariantCulture));
}