namespace OES;

/// <summary>
/// A request to create a new MCQ definition.
/// </summary>
public class CreateMCQuestionDefinition
{
    public CreateMCQuestionDefinition(
        int                             scriptDefinitionId,
        int                             questionNumber,
        string                          questionName,
        int                             panelId,
        ImageMargin                     questionRange,
        ICollection<MCOptionDefinition> optionsDefinition,
        MCMarkingMode                   markingMode,
        int                             markPerOption
        )
    {
        ScriptDefinitionId = scriptDefinitionId;
        QuestionNumber     = questionNumber;
        QuestionName       = questionName;
        PanelId            = panelId;
        QuestionRange      = questionRange;
        OptionsDefinition  = optionsDefinition;
        MarkingMode        = markingMode;
        MarkPerOption      = markPerOption;
    }

    /// <inheritdoc cref="MCQuestionDefinition.ScriptDefinitionId"/>
    public int ScriptDefinitionId { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.QuestionNumber"/>
    public int QuestionNumber { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.QuestionName"/>
    public string QuestionName { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.PanelId"/>
    public int PanelId { get; set; }

    /// <inheritdoc cref="MCQuestionDefinition.QuestionRange"/>
    public ImageMargin QuestionRange { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.OptionsDefinition"/>
    public ICollection<MCOptionDefinition> OptionsDefinition { get; set; }

    /// <inheritdoc cref="MCQuestionDefinition.MarkingMode"/>
    public MCMarkingMode MarkingMode { get; set; }
    
    /// <inheritdoc cref="MCQuestionDefinition.MarkPerOption"/>
    public int MarkPerOption { get; set; }
}