using System.Diagnostics.CodeAnalysis;

namespace OES;

/// <summary>
/// Represents a marking panel.
/// </summary>
public class MarkingPanel
{
    /// <summary>
    /// Creates an instance for MarkingPanel.
    /// </summary>
    public MarkingPanel(
        int id, 
        int examinationId, 
        string panelCode, 
        string panelDescription, 
        bool doubleMarking, 
        int markDifferenceTolerance, 
        bool isMcPanel, 
        MarkingPanelStatus markingPanelStatus
        )
    {
        Id = id;
        ExaminationId = examinationId;
        PanelCode = panelCode;
        PanelDescription = panelDescription;
        DoubleMarking = doubleMarking;
        MarkDifferenceTolerance = markDifferenceTolerance;
        IsMCPanel = isMcPanel;
        MarkingPanelStatus = markingPanelStatus;
    }

    /// <summary>
    /// The ID of the marking panel.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// The ID of the examination to which this panel belongs.
    /// </summary>
    public int ExaminationId { get; }
    
    /// <summary>
    /// The short name of the marking panel. Generally, the code should tell you some information about the panel.
    /// For example, code "3A1" represents the first marking panel assigned for Paper 3 Part A.
    /// A panel code ending with a sharp (#) will mean that this is a Multiple-choice Panel.
    /// However, the rules above are not forced.
    /// </summary>
    public string PanelCode { get; }
    
    /// <summary>
    /// Description of the marking panel.
    /// </summary>
    public string PanelDescription { get; }
    
    /// <summary>
    /// Whether the marking panel enforces double marking policy.
    /// </summary>
    public bool DoubleMarking { get; }
    
    /// <summary>
    /// The acceptable difference of marks by two markers on the same script.
    /// When the difference of marks between the marks given by two markers exceeds this value,
    /// the script will be marked by the subject supervisor.
    /// This value is useless when <see cref="DoubleMarking"/> is false.
    /// </summary>
    public int MarkDifferenceTolerance { get; }
    
    /// <summary>
    /// Whether the scripts assigned to this panel are multiple-choice questions.
    /// When set tu true, questions will be automatically marked.
    /// </summary>
    public bool IsMCPanel { get; }
    
    /// <summary>
    /// The status of the marking panel.
    /// </summary>
    public MarkingPanelStatus MarkingPanelStatus { get; }
}