namespace OES;

/// <summary>
/// Represents a definition for a question number box.
/// </summary>
public class QuestionNumberBoxDefinition
{
    /// <summary>
    /// Creates an instance for QuestionNumberBoxDefinition.
    /// </summary>
    public QuestionNumberBoxDefinition(int id, ImageMargin boxImageMargin, IEnumerable<int> validQuestionsRange, ICollection<ImageMargin> questionMargins)
    {
        Id = id;
        BoxImageMargin = boxImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionMargins = questionMargins;
    }

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// The range of the image of the whole question number box.
    /// </summary>
    public ImageMargin BoxImageMargin { get; }
    
    /// <summary>
    /// The valid range of questions that candidates may choose from.
    /// </summary>
    public IEnumerable<int> ValidQuestionsRange { get; }
    
    /// <summary>
    /// The image margins of each question number.
    /// </summary>
    public ICollection<ImageMargin> QuestionMargins { get; }
}