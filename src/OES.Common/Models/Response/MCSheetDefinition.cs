namespace OES;

/// <summary>
/// Represents a definition for an MCQ OMR sheet.
/// </summary>
public class MCSheetDefinition
{
    /// <summary>
    /// Creates an instance for an MCQ OMR sheet definition.
    /// </summary>
    public MCSheetDefinition(int id, int panelId, ICollection<MCQuestionDefinition> questionDefinitions)
    {
        DefinitionId = id;
        PanelId = panelId;
        QuestionDefinitions = questionDefinitions;
    }

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The ID of the marking panel responsible for marking this sheet. Must be an MC Panel.
    /// </summary>
    public int PanelId { get; }
    
    /// <summary>
    /// The collection of questions to be marked.
    /// </summary>
    public ICollection<MCQuestionDefinition> QuestionDefinitions { get; }
}