using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// An object representing a request to update an existing <see cref="QuestionNumberBoxDefinition"/>.
/// </summary>
public class UpdateQuestionNumberBoxDefinition
{
    internal UpdateQuestionNumberBoxDefinition(QuestionNumberBoxDefinition qnbDefinition)
    {
        QnbDefinitionId     = qnbDefinition.QnbDefinitionId;
        BoxImageMargin      = qnbDefinition.QnbImageMargin;
        ValidQuestionsRange = new List<int>(qnbDefinition.ValidQuestionsRange);
        QuestionsMargin     = new Dictionary<int, ImageMargin>(qnbDefinition.QuestionsMargin);
        BoxName             = qnbDefinition.BoxName;
    }
    
    [JsonIgnore]
    public int QnbDefinitionId { get; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QnbImageMargin"/>
    public ImageMargin BoxImageMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.ValidQuestionsRange"/>
    public ICollection<int> ValidQuestionsRange { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QuestionsMargin"/>
    [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
    public IDictionary<int, ImageMargin> QuestionsMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.BoxName"/>
    public string BoxName { get; set; }

    /// <summary>
    /// Checks if every question in <see cref="UpdateQuestionNumberBoxDefinition.ValidQuestionsRange"/> has a matching
    /// image margin set in <see cref="UpdateQuestionNumberBoxDefinition.QuestionsMargin"/>.
    /// </summary>
    public bool IsValid() =>
        ValidQuestionsRange.Count == QuestionsMargin.Count 
        && ValidQuestionsRange.All(question => QuestionsMargin.TryGetValue(question, out _));
}