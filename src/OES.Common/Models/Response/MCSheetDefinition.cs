using System.Globalization;
using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Represents a definition for an MCQ OMR sheet.
/// </summary>
public class MCSheetDefinition
{
    /// <summary>
    /// Creates an instance for an MCQ OMR sheet definition.
    /// </summary>
    [JsonConstructor]
    internal MCSheetDefinition(int id, int panelId, IReadOnlyCollection<MCSheetQuestionDefinition> answers)
    {
        ScriptDefinitionId = id;
        PanelId = panelId;
        Answers = answers;
    }

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    public int ScriptDefinitionId { get; }
    
    /// <summary>
    /// The ID of the marking panel responsible for marking this sheet. Must be an MC Panel.
    /// </summary>
    public int PanelId { get; }
    
    /// <summary>
    /// The collection of questions to be marked.
    /// </summary>
    [JsonConverter(typeof(MCSheetAnswerJsonConverter))]
    public IReadOnlyCollection<MCSheetQuestionDefinition> Answers { get; }

    /// <summary>
    /// Gets an object representing a request to create MC sheet definition.
    /// </summary>
    /// <param name="scriptDefinitionId">The ID of the <see cref="ExaminationScriptDefinition"/> to which
    /// the MC sheet definition belongs. Must have <see cref="ExaminationScriptDefinition.ExaminationScriptType"/>
    /// set as <see cref="ExaminationScriptType.MCSheet"/>.</param>
    /// <param name="panelId">The ID of the marking panel which will be responsible for marking the MC sheet.
    /// Panel must be an MC panel.</param>
    /// <param name="answers">The collection of MC sheet answers.</param>
    public static CreateMCSheetDefinition ToCreate(
        int                                     scriptDefinitionId,
        int                                     panelId,
        ICollection<MCSheetQuestionDefinition>? answers = null) =>
        new CreateMCSheetDefinition(scriptDefinitionId, panelId, answers);

    /// <summary>
    /// Gets an object representing a request to delete an existing <see cref="MCSheetDefinition"/>.
    /// </summary>
    public DeleteObject ToDelete() => new DeleteObject(ScriptDefinitionId.ToString(CultureInfo.InvariantCulture));
}