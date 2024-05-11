namespace OES;

/// <summary>
/// Represents a definition of one script slice. It instructs the system how to slice the scanned script images
/// and which marking panel to assign the sliced script.
/// </summary>
public class ScriptSlicingDefinition
{
    /// <summary>
    /// Creates an instance for script slicing definition.
    /// </summary>
    public ScriptSlicingDefinition(
        int id,
        int page,
        ImageMargin range,
        int? panelId,
        int? orderInPanel,
        int? linkedSliceId,
        int? orderInLinkage,
        int? linkedQuestionNumberBoxId
    )
    {
        DefinitionId = id;
        Page = page;
        Range = range;
        PanelId = panelId;
        OrderInPanel = orderInPanel;
        LinkedSliceId = linkedSliceId;
        OrderInLinkage = orderInLinkage;
        LinkedQuestionNumberBoxId = linkedQuestionNumberBoxId;
    }
    
    /// <summary>
    /// The ID of the definition.
    /// </summary>
    public int DefinitionId { get; }
    
    /// <summary>
    /// The page on which the slice is.
    /// </summary>
    public int Page { get; }
    
    /// <summary>
    /// The margins of the slice.
    /// </summary>
    public ImageMargin Range { get; }
    
    /// <summary>
    /// The panel which is responsible for marking the slice.
    /// When the slice is linked to another slice, or to a question number box, the value will be null.
    /// </summary>
    public int? PanelId { get; }
    
    /// <summary>
    /// Controls the order of all slices within the same panel. Has no effect (and likely to be null)
    /// when <see cref="PanelId"/> is null.
    /// </summary>
    public int? OrderInPanel { get; }
    
    /// <summary>
    /// Indicates to which slice is the slice linked.
    /// When the slice is assigned to a marking panel, or is linked to a question number box, the value will be null.
    /// </summary>
    public int? LinkedSliceId { get; }
    
    /// <summary>
    /// Controls the order of all slices which are linked to the same slice. Has no effect (and likely to be null)
    /// when <see cref="LinkedSliceId"/> is null.
    /// </summary>
    public int? OrderInLinkage { get; }
    
    /// <summary>
    /// Indicates to which question number box is the slice linked.
    /// When the slice is assigned to a marking panel, or is linked to another slice, the value will be null.
    /// </summary>
    public int? LinkedQuestionNumberBoxId { get; }
}