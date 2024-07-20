namespace OES;

/// <summary>
/// A request to create a new MCQ definition.
/// </summary>
public class CreateMCQuestionDefinition
{
    public CreateMCQuestionDefinition(
        int                             questionNumber,
        string                          questionName,
        int                             panelId,
        ImageMargin                     questionImageMargin,
        ICollection<MCOptionDefinition> optionsDefinition,
        MCMarkingMode                   markingMode,
        int                             markPerOption
        )
    {
        QuestionNumber      = questionNumber;
        QuestionName        = questionName;
        PanelId             = panelId;
        QuestionImageMargin = questionImageMargin;
        OptionsDefinition   = optionsDefinition;
        MarkingMode         = markingMode;
        MarkPerOption       = markPerOption;
    }
    
    /// <inheritdoc cref="MCQuestionDefinition.QuestionNumber"/>
    public int QuestionNumber { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.QuestionName"/>
    public string QuestionName { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.PanelId"/>
    public int PanelId { get; set; }

    /// <inheritdoc cref="MCQuestionDefinition.QuestionImageMargin"/>
    public ImageMargin QuestionImageMargin { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.OptionsDefinition"/>
    public ICollection<MCOptionDefinition> OptionsDefinition { get; set; }

    /// <inheritdoc cref="MCQuestionDefinition.MarkingMode"/>
    public MCMarkingMode MarkingMode { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.MarksPerOption"/>
    public int MarkPerOption { get; set; }
}