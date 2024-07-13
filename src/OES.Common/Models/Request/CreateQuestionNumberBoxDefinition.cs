using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A request to create a new QNB definition.
/// </summary>
public class CreateQuestionNumberBoxDefinition
{
    public CreateQuestionNumberBoxDefinition(
        ImageMargin                   qnbImageMargin,
        ICollection<int>              validQuestionsRange,
        IDictionary<int, ImageMargin> questionsMargin,
        string                        boxName)
    {
        QnbImageMargin      = qnbImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionsMargin     = questionsMargin;
        BoxName             = boxName;
    }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QnbImageMargin"/>
    public ImageMargin QnbImageMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.ValidQuestionsRange"/>
    public ICollection<int> ValidQuestionsRange { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QuestionsMargin"/>
    [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
    public IDictionary<int, ImageMargin> QuestionsMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.BoxName"/>
    public string BoxName { get; set; }

    /// <summary>
    /// Checks if every question in <see cref="CreateQuestionNumberBoxDefinition.ValidQuestionsRange"/> has a matching
    /// image margin set in <see cref="CreateQuestionNumberBoxDefinition.QuestionsMargin"/>.
    /// </summary>
    public bool IsValid() =>
        ValidQuestionsRange.Count == QuestionsMargin.Count 
        && ValidQuestionsRange.All(question => QuestionsMargin.TryGetValue(question, out _));
}