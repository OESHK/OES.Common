using System.Globalization;
using Newtonsoft.Json;
using OES.Internal;

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
    [JsonConstructor]
    public ScriptSlicingDefinition(
        int         sliceDefinitionId,
        int         scriptDefinitionId,
        int         page,
        ImageMargin imageMargin,
        int?        panelId,
        int?        orderInPanel,
        [JsonProperty("link_to_slice")]
        int?        linkedSliceId,
        int?        orderInLinkage,
        [JsonProperty("link_to_qnb")]
        int?        linkedQuestionNumberBoxId
    )
    {
        SliceDefinitionId         = sliceDefinitionId;
        ScriptDefinitionId        = scriptDefinitionId;
        Page                      = page;
        ImageMargin               = imageMargin;
        PanelId                   = panelId;
        OrderInPanel              = orderInPanel;
        LinkedSliceId             = linkedSliceId;
        OrderInLinkage            = orderInLinkage;
        LinkedQuestionNumberBoxId = linkedQuestionNumberBoxId;
    }
    
    /// <summary>
    /// The ID of the <see cref="ScriptSlicingDefinition"/>.
    /// </summary>
    public int SliceDefinitionId { get; }
    
    /// <summary>
    /// The ID of the <see cref="ExaminationScriptDefinition"/> to which the <see cref="ScriptSlicingDefinition"/> is linked.
    /// </summary>
    public int ScriptDefinitionId { get; }
    
    /// <summary>
    /// The page on which the slice is.
    /// </summary>
    public int Page { get; }
    
    /// <summary>
    /// The margins of the slice.
    /// </summary>
    [JsonConverter(typeof(ImageMarginJsonConverter))]
    public ImageMargin ImageMargin { get; }
    
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
    [JsonProperty("link_to_slice")]
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
    [JsonProperty("link_to_qnb")]
    public int? LinkedQuestionNumberBoxId { get; }

    /// <summary>
    /// Gets an object representing a request to create a new <see cref="ScriptSlicingDefinition"/>.
    /// </summary>
    public static CreateScriptSlicingDefinition ToCreate(
        int         page,
        ImageMargin imageMargin,
        int?        panelId,
        int?        orderInPanel,
        int?        linkedSliceId,
        int?        orderInLinkage,
        int?        linkedQuestionNumberBoxId)
        => new(page, imageMargin, panelId, orderInPanel, linkedSliceId, orderInLinkage, linkedQuestionNumberBoxId);

    /// <summary>
    /// Creates a new <see cref="ScriptSlicingDefinition"/> which is linked to a <see cref="MarkingPanel"/>.
    /// </summary>
    /// <returns>An object representing a create <see cref="ScriptSlicingDefinition"/> request.</returns>
    public static CreateScriptSlicingDefinition ToCreate(
        int          page,
        ImageMargin  imageMargin,
        MarkingPanel panel,
        int          orderInPanel)
        => ToCreate(page, imageMargin, panel.PanelId, orderInPanel, null, null, null);

    /// <summary>
    /// Creates a new <see cref="ScriptSlicingDefinition"/> which is linked to another <see cref="ScriptSlicingDefinition"/>.
    /// </summary>
    /// <returns>An object representing a create <see cref="ScriptSlicingDefinition"/> request.</returns>
    public static CreateScriptSlicingDefinition ToCreate(
        int                     page,
        ImageMargin             imageMargin,
        ScriptSlicingDefinition linkedSlice,
        int                     orderInLinkage)
        => ToCreate(page, imageMargin, null, null, linkedSlice.SliceDefinitionId, orderInLinkage, null);

    /// <summary>
    /// Creates a new <see cref="ScriptSlicingDefinition"/> which is linked to a <see cref="QuestionNumberBoxDefinition"/>.
    /// </summary>
    /// <returns>An object representing a create <see cref="ScriptSlicingDefinition"/> request.</returns>
    public static CreateScriptSlicingDefinition ToCreate(
        int                         page,
        ImageMargin                 imageMargin,
        QuestionNumberBoxDefinition linkedQnb)
        => ToCreate(page, imageMargin, null, null, null, null, linkedQnb.QnbDefinitionId);

    /// <summary>
    /// Gets an object representing a delete <see cref="ScriptSlicingDefinition"/> request.
    /// </summary>
    /// <returns></returns>
    public DeleteObject ToDelete()
        => new(SliceDefinitionId.ToString(CultureInfo.InvariantCulture));
}