using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to create a new marking panel.
/// </summary>
public class CreateMarkingPanel
{
    public CreateMarkingPanel(
        int examinationId, 
        string panelCode, 
        string? panelDescription, 
        bool doubleMarking, 
        int markDifferenceTolerance, 
        bool isMcPanel, 
        MarkingPanelStatus markingPanelStatus,
        ICollection<MarkerRosterEntry>? markers,
        ICollection<MarkingPanelQuestion>? questions)
    {
        ExaminationId           = examinationId;
        PanelCode               = panelCode;
        PanelDescription        = panelDescription;
        DoubleMarking           = doubleMarking;
        MarkDifferenceTolerance = markDifferenceTolerance;
        IsMCPanel               = isMcPanel;
        MarkingPanelStatus      = markingPanelStatus;
        Markers                 = markers;
        Questions               = questions;
    }
    
    /// <inheritdoc cref="MarkingPanel.ExaminationId"/>
    public int ExaminationId { get; }
    
    /// <inheritdoc cref="MarkingPanel.PanelCode"/>
    public string PanelCode { get; }
    
    /// <inheritdoc cref="MarkingPanel.PanelDescription"/>
    public string? PanelDescription { get; }
    
    /// <inheritdoc cref="MarkingPanel.DoubleMarking"/>
    public bool DoubleMarking { get; }
    
    /// <inheritdoc cref="MarkingPanel.MarkDifferenceTolerance"/>
    [JsonProperty("mark_diff_tolerance")]
    public int MarkDifferenceTolerance { get; }
    
    /// <inheritdoc cref="MarkingPanel.IsMCPanel"/>
    [JsonProperty("is_mc_panel")]
    public bool IsMCPanel { get; }
    
    /// <inheritdoc cref="MarkingPanel.MarkingPanelStatus"/>
    public MarkingPanelStatus MarkingPanelStatus { get; }

    /// <inheritdoc cref="MarkingPanel.Markers"/>
    [JsonIgnore]
    public ICollection<MarkerRosterEntry>? Markers { get; private set; }
    
    /// <inheritdoc cref="MarkingPanel.Questions"/>
    [JsonIgnore]
    public ICollection<MarkingPanelQuestion>? Questions { get; private set; }

    /// <summary>
    /// Roster a marker to this marking panel.
    /// </summary>
    /// <param name="markerId">The ID of the marker to be rostered.</param>
    /// <param name="role">The role of the marker in the marking panel.</param>
    public void RosterMarker(string markerId, MarkerRole role)
    {
        Markers ??= new List<MarkerRosterEntry>();
        if (HasMarker(markerId)) RemoveMarker(markerId);
        Markers.Add(new MarkerRosterEntry(markerId, role));
    }

    /// <summary>
    /// Remove a rostered marker from the marking panel if exists.
    /// </summary>
    /// <param name="markerId">The ID of the marker to be removed.</param>
    public void RemoveMarker(string markerId)
    {
        if (Markers is null)
        {
            Markers = new List<MarkerRosterEntry>();
            return;
        }

        if (HasMarker(markerId))
            Markers = Markers.Where(x => x.MarkerId != markerId).ToList();
    }

    /// <summary>
    /// Remove all markers rostered in the marking panel.
    /// </summary>
    public void ClearMarkers() => Markers = null;

    private bool HasMarker(string markerId) => Markers?.Any(x => x.MarkerId == markerId) ?? false;

    /// <summary>
    /// Links a question to the marking panel and the question's script definition.
    /// </summary>
    /// <param name="scriptDefinitionId">The ID of the script definition.</param>
    /// <param name="questionNumber">The number of the question to be linked.</param>
    public void AddQuestion(int scriptDefinitionId, int questionNumber)
    {
        AddQuestion(new MarkingPanelQuestion(scriptDefinitionId, questionNumber));
    }

    /// <summary>
    /// Links a question to the marking panel.
    /// </summary>
    /// <param name="question">The question to be linked.</param>
    public void AddQuestion(MarkingPanelQuestion question)
    {
        Questions ??= new List<MarkingPanelQuestion>();
        if (HasQuestion(question)) RemoveQuestion(question);
        Questions.Add(question);
    }

    /// <summary>
    /// Removes a question from the marking panel if it exists.
    /// </summary>
    /// <param name="question">The number to be removed.</param>
    public void RemoveQuestion(MarkingPanelQuestion question)
    {
        if (Questions is null)
        {
            Questions = new List<MarkingPanelQuestion>();
            return;
        }

        if (HasQuestion(question)) 
            Questions = Questions.Where(x => x != question).ToList();
    }

    /// <summary>
    /// Clears all questions from the marking panel.
    /// </summary>
    public void ClearQuestions() => Questions = null;

    private bool HasQuestion(MarkingPanelQuestion question) => Questions?.Any(x => x == question) ?? false;
}