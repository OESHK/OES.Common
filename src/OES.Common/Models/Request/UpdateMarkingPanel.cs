using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace OES;

public class UpdateMarkingPanel
{
    internal UpdateMarkingPanel(MarkingPanel markingPanel)
    {
        PanelId           = markingPanel.PanelId;
        OriginalMarkers   = markingPanel.Markers ?? Array.Empty<MarkerRosterEntry>();
        Markers           = OriginalMarkers.ToList();
        OriginalQuestions = markingPanel.Questions ?? Array.Empty<MarkingPanelQuestion>();
        Questions         = OriginalQuestions.ToList();
    }
    
    /// <inheritdoc cref="MarkingPanel.PanelId"/>
    [JsonIgnore]
    public int PanelId { get; }
    
    /// <inheritdoc cref="MarkingPanel.PanelCode"/>
    public string? PanelCode { get; set; }
    
    /// <inheritdoc cref="MarkingPanel.PanelDescription"/>
    public string? PanelDescription { get; set; }

    /// <inheritdoc cref="MarkingPanel.Markers"/>
    // for generating diff, two markers lists should not be nullable
    [JsonIgnore]
    public ICollection<MarkerRosterEntry> Markers { get; private set; }
    
    // used to generate diff between original and modified marker lists
    [JsonIgnore]
    internal IReadOnlyCollection<MarkerRosterEntry> OriginalMarkers { get; }
    
    /// <inheritdoc cref="MarkingPanel.Questions"/>
    [JsonIgnore]
    public ICollection<MarkingPanelQuestion> Questions { get; private set; }
    
    [JsonIgnore]
    public IReadOnlyCollection<MarkingPanelQuestion> OriginalQuestions { get; }

    private bool HasMarker(string markerId) => Markers.Any(x => x.MarkerId == markerId);

    /// <inheritdoc cref="CreateMarkingPanel.RosterMarker"/>
    public void RosterMarker(string markerId, MarkerRole markerRole)
    {
        if (HasMarker(markerId)) RemoveMarker(markerId);
        Markers.Add(new MarkerRosterEntry(markerId, PanelId, markerRole));
    }

    /// <inheritdoc cref="CreateMarkingPanel.RemoveMarker"/>
    public void RemoveMarker(string markerId)
    {
        if (!HasMarker(markerId)) return;
        Markers = Markers.Where(x => x.MarkerId != markerId).ToList();
    }

    /// <inheritdoc cref="CreateMarkingPanel.ClearMarkers"/>
    public void ClearMarkers() => Markers = new List<MarkerRosterEntry>();

    /// <summary>
    /// Gets a list of modified (new/role change) markers.
    /// </summary>
    internal IReadOnlyCollection<MarkerRosterEntry> GetModifiedMarkerRosterEntries()
        => new ReadOnlyCollection<MarkerRosterEntry>(Markers.Except(OriginalMarkers).ToArray());

    /// <summary>
    /// Gets a list of removed markers.
    /// </summary>
    internal IReadOnlyCollection<MarkerRosterEntry> GetRemovedMarkerRosterEntries()
        => new ReadOnlyCollection<MarkerRosterEntry>(OriginalMarkers
            .Where(old => Markers.All(@new => @new.MarkerId != old.MarkerId)).ToList());

    /// <summary>
    /// Whether the markers in this marking panel have been modified (added/changed/removed).
    /// </summary>
    internal bool MarkersModified => OriginalMarkers.Except(Markers).ToArray().Length != 0;

    private bool HasQuestion(MarkingPanelQuestion question) => Questions?.Any(x => x == question) ?? false;
    
    /// <inheritdoc cref="CreateMarkingPanel.AddQuestion(int,int)"/>
    public void AddQuestion(int scriptDefinitionId, int questionNumber)
    {
        AddQuestion(new MarkingPanelQuestion(scriptDefinitionId, questionNumber));
    }

    /// <inheritdoc cref="CreateMarkingPanel.AddQuestion(MarkingPanelQuestion)"/>
    public void AddQuestion(MarkingPanelQuestion question)
    {
        Questions ??= new List<MarkingPanelQuestion>();
        if (HasQuestion(question)) RemoveQuestion(question);
        Questions.Add(question);
    }

    /// <inheritdoc cref="CreateMarkingPanel.RemoveQuestion"/>
    public void RemoveQuestion(MarkingPanelQuestion question)
    {
        if (!HasQuestion(question)) return;
        Questions = Questions.Where(x => x != question).ToList();
    }

    /// <inheritdoc cref="CreateMarkingPanel.ClearQuestions"/>
    public void ClearQuestions() => Questions = new List<MarkingPanelQuestion>();
}