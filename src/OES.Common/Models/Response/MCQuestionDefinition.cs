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
        int id,
        int scriptDefinitionId,
        int panelId,
        int questionNumber,
        string questionName,
        ImageMargin questionRange,
        ICollection<MCOptionDefinition> optionsDefinition,
        MCMarkingMode markingMode,
        int markPerOption) : base(id, scriptDefinitionId, panelId, questionNumber, questionName)
    {
        QuestionRange = questionRange;
        OptionsDefinition = optionsDefinition;
        MarkingMode = markingMode;
        MarkPerOption = markPerOption;
    }

    /// <summary>
    /// The range of the question's image.
    /// </summary>
    public ImageMargin QuestionRange { get; }
    
    /// <summary>
    /// The collection of options and their respective definitions.
    /// </summary>
    public ICollection<MCOptionDefinition> OptionsDefinition { get; }

    /// <summary>
    /// The collection of correct options.
    /// </summary>
    public ICollection<MCOptionDefinition> CorrectOptions 
        => (ICollection<MCOptionDefinition>)OptionsDefinition.Where(def => def.IsCorrect);

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
}