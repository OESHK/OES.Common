using System.Globalization;
using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Represents a definition for a question number box.
/// </summary>
public class QuestionNumberBoxDefinition
{
    /// <summary>
    /// Creates an instance for QuestionNumberBoxDefinition.
    /// </summary>
    [JsonConstructor]
    internal QuestionNumberBoxDefinition(
        int                                   qnbDefinitionId,
        [JsonConverter(typeof(ImageMarginJsonConverter))]
        ImageMargin                           qnbImageMargin,
        IReadOnlyCollection<int>              validQuestionsRange,
        [JsonConverter(typeof(IntImageMarginDictJsonConverter))]
        IReadOnlyDictionary<int, ImageMargin> questionsMargin,
        string                                boxName)
    {
        QnbDefinitionId                  = qnbDefinitionId;
        QnbImageMargin      = qnbImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionsMargin     = questionsMargin;
        BoxName             = boxName;
    }

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    public int QnbDefinitionId { get; }
    
    /// <summary>
    /// The range of the image of the whole question number box.
    /// </summary>
    public ImageMargin QnbImageMargin { get; }
    
    /// <summary>
    /// The valid range of questions that candidates may choose from.
    /// </summary>
    public IReadOnlyCollection<int> ValidQuestionsRange { get; }
    
    /// <summary>
    /// The image margins of each question number.
    /// </summary>
    public IReadOnlyDictionary<int, ImageMargin> QuestionsMargin { get; }
    
    /// <summary>
    /// The name of the question number box.
    /// </summary>
    public string BoxName { get; }

    /// <summary>
    /// Gets an object representing a Create QuestionNumberBox Definition request.
    /// </summary>
    public static CreateQuestionNumberBoxDefinition ToCreate(ImageMargin                    boxImageMargin,
                                                             ICollection<int>               validQuestionsRange,
                                                             IDictionary<int, ImageMargin>  questionMargins,
                                                             string                         boxName = "") =>
        new(boxImageMargin, validQuestionsRange, questionMargins, boxName);
}