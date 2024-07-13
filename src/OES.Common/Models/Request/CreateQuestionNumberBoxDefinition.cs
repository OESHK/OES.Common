using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A request to create a new QNB definition.
/// </summary>
public class CreateQuestionNumberBoxDefinition
{
    public CreateQuestionNumberBoxDefinition(
        ImageMargin                   boxImageMargin,
        ICollection<int>              validQuestionsRange,
        IDictionary<int, ImageMargin> questionsMargin,
        string                        boxName)
    {
        BoxImageMargin      = boxImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionsMargin     = questionsMargin;
        BoxName             = boxName;
    }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QnbImageMargin"/>
    public ImageMargin BoxImageMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.ValidQuestionsRange"/>
    public IEnumerable<int> ValidQuestionsRange { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QuestionsMargin"/>
    [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
    public IDictionary<int, ImageMargin> QuestionsMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.BoxName"/>
    public string BoxName { get; set; }
}