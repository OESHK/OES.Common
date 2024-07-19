using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A request to create a new <see cref="ScriptSlicingDefinition"/>.
/// </summary>
public class CreateScriptSlicingDefinition
{
    public CreateScriptSlicingDefinition(
        int         page,
        [JsonConverter(typeof(ImageMarginJsonConverter))]
        ImageMargin range,
        int?        panelId,
        int?        orderInPanel,
        int?        linkedSliceId,
        [JsonProperty("order_in_linkage")]
        int?        orderInLinkage,
        [JsonProperty("link_to_qnb")]
        int?        linkedQuestionNumberBoxId
        )
    {
        Page                      = page;
        Range                     = range;
        PanelId                   = panelId;
        OrderInPanel              = orderInPanel;
        LinkedSliceId             = linkedSliceId;
        OrderInLinkage            = orderInLinkage;
        LinkedQuestionNumberBoxId = linkedQuestionNumberBoxId;
    }
    
    /// <inheritdoc cref="ScriptSlicingDefinition.Page"/>
    public int Page { get; set; }
    
    /// <inheritdoc cref="ScriptSlicingDefinition.ImageMargin"/>
    public ImageMargin Range { get; set; }

    /// <summary>
    /// The panel which is responsible for marking the slice.
    /// Setting this property will make <see cref="LinkedSliceId"/>, <see cref="OrderInLinkage"/>,
    /// and <see cref="LinkedQuestionNumberBoxId"/> null.
    /// </summary>
    public int? PanelId
    {
        get => _panelId;
        set
        {
            _panelId = value;
            
            if (_panelId is null) return;
            _linkedSliceId  = null;
            _orderInLinkage = null;
            _linkedQnbId    = null;
        }
    }
    private int? _panelId;

    /// <inheritdoc cref="ScriptSlicingDefinition.OrderInPanel"/>
    public int? OrderInPanel
    {
        get => _orderInPanel;
        set
        {
            _orderInPanel = value;

            if (value is null) return;
            _linkedSliceId  = null;
            _orderInLinkage = null;
            _linkedQnbId    = null;
        }
    }

    private int? _orderInPanel;

    /// <summary>
    /// The ID of the slice to which this slice is linked.
    /// Setting this property will make <see cref="PanelId"/>, <see cref="OrderInPanel"/>
    /// and <see cref="LinkedQuestionNumberBoxId"/> null.
    /// </summary>
    [JsonProperty("link_to_slice")]
    public int? LinkedSliceId
    {
        get => _linkedSliceId;
        set
        {
            _linkedSliceId = value;

            if (_linkedSliceId is null) return;
            _panelId      = null;
            _orderInPanel = null;
            _linkedQnbId  = null;
        }
    }
    private int? _linkedSliceId;

    /// <inheritdoc cref="ScriptSlicingDefinition.OrderInLinkage"/>
    [JsonProperty("link_order")]
    public int? OrderInLinkage
    {
        get => _orderInLinkage;
        set
        {
            _orderInLinkage = value;

            if (value is null) return;
            _panelId      = null;
            _orderInPanel = null;
            _linkedQnbId  = null;
        }
    }
    private int? _orderInLinkage;

    /// <summary>
    /// The ID of the Question Number Box that this slice is linked to.
    /// Setting this property will make <see cref="PanelId"/>, <see cref="OrderInPanel"/>,
    /// <see cref="LinkedSliceId"/>, and <see cref="OrderInLinkage"/> null.
    /// </summary>
    [JsonProperty("link_to_qnb")]
    public int? LinkedQuestionNumberBoxId
    {
        get => _linkedQnbId;
        set
        {
            _linkedQnbId = value;

            if (_linkedQnbId is null) return;
            _panelId        = null;
            _orderInPanel   = null;
            _linkedSliceId  = null;
            _orderInLinkage = null;
        }
    }
    private int? _linkedQnbId;
}