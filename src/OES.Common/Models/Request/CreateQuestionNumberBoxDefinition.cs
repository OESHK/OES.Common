namespace OES;

/// <summary>
/// A request to create a new QNB definition.
/// </summary>
public class CreateQuestionNumberBoxDefinition
{
    public CreateQuestionNumberBoxDefinition(
        ImageMargin                    boxImageMargin,
        ICollection<int>?              validQuestionsRange,
        IDictionary<int, ImageMargin>? questionMargins)
    {
        BoxImageMargin      = boxImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionMargins     = questionMargins;
    }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.BoxImageMargin"/>
    public ImageMargin BoxImageMargin { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.ValidQuestionsRange"/>
    public IEnumerable<int>? ValidQuestionsRange { get; set; }
    
    /// <inheritdoc cref="QuestionNumberBoxDefinition.QuestionMargins"/>
    public IDictionary<int, ImageMargin>? QuestionMargins { get; set; }
}