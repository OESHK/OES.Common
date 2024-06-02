using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to create a new MCSheet definition.
/// </summary>
public class CreateMCSheetDefinition
{
    public CreateMCSheetDefinition(
        int                                     scriptDefinitionId,
        int                                     panelId,
        ICollection<MCSheetQuestionDefinition>? answers)
    {
        ScriptDefinitionId = scriptDefinitionId;
        PanelId            = panelId;
        
        WriteAnswers(answers ?? new List<MCSheetQuestionDefinition>());
    }
    
    /// <inheritdoc cref="MCSheetDefinition.ScriptDefinitionId"/>
    public int ScriptDefinitionId { get; set; }
    
    /// <inheritdoc cref="MCSheetDefinition.PanelId"/>
    public int PanelId { get; set; }

    /// <inheritdoc cref="MCSheetDefinition.Answers"/>
    [JsonConverter(typeof(MCSheetAnswerJsonConverter))]
    public IReadOnlyCollection<MCSheetQuestionDefinition> Answers
    {
        get => new ReadOnlyCollection<MCSheetQuestionDefinition>(_answers.ToList());
        private set => _answers = value.ToArray();
    }
    private ICollection<MCSheetQuestionDefinition> _answers = new List<MCSheetQuestionDefinition>();

    /// <summary>
    /// Writes the provided list of answers into the sheet definition.
    /// Missing answers will be set as <see cref="MCSheetAnswer.Skip"/> automatically.
    /// Repeated question number will always be overwritten by the last occurence in the list.
    /// </summary>
    public void WriteAnswers(ICollection<MCSheetQuestionDefinition> answers)
    {
        _answers = new List<MCSheetQuestionDefinition>();
        foreach (var answer in answers)
            WriteAnswer(answer);
        FillMissingAnswer();
    }

    /// <summary>
    /// Set the answer of a single question number.
    /// </summary>
    public void WriteAnswer(MCSheetQuestionDefinition answer)
    {
        RemoveAnswerIfExists(answer.QuestionNumber);
        _answers.Add(answer);
    }

    /// <summary>
    /// Set the answer of a single question number.
    /// </summary>
    public void WriteAnswer(int questionNumber, MCSheetAnswer answer)
    {
        WriteAnswer(new MCSheetQuestionDefinition(questionNumber, answer));
    }

    /// <summary>
    /// Set all missing answers as <see cref="MCSheetAnswer.Skip"/>.
    /// </summary>
    private void FillMissingAnswer()
    {
        for (var i = 1; i <= _answers.Count; i++)
        {
            if (_answers.Any(x => x.QuestionNumber == i)) continue;
            WriteAnswer(i, MCSheetAnswer.Skip);
        }
    }

    /// <summary>
    /// Removes an answer from the list if that question number already exists.
    /// </summary>
    private void RemoveAnswerIfExists(int questionNumber)
    {
        if (_answers.Any(x => x.QuestionNumber == questionNumber))
            _answers = _answers.Where(x => x.QuestionNumber != questionNumber).ToList();
    }
}