using System.Globalization;

namespace OES;

/// <summary>
/// Represents a definition for a question number box.
/// </summary>
public class QuestionNumberBoxDefinition
{
    /// <summary>
    /// Creates an instance for QuestionNumberBoxDefinition.
    /// </summary>
    public QuestionNumberBoxDefinition(
        int                                   id,
        ImageMargin                           boxImageMargin,
        IEnumerable<int>                      validQuestionsRange,
        IReadOnlyDictionary<int, ImageMargin> questionMargins
        )
    {
        Id                  = id;
        BoxImageMargin      = boxImageMargin;
        ValidQuestionsRange = validQuestionsRange;
        QuestionMargins     = questionMargins;
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
    public IReadOnlyDictionary<int, ImageMargin> QuestionMargins { get; }

    /// <summary>
    /// Gets an object representing a Create QuestionNumberBox Definition request.
    /// </summary>
    public static CreateQuestionNumberBoxDefinition ToCreate(ImageMargin                    boxImageMargin,
                                                             ICollection<int>?              validQuestionsRange,
                                                             IDictionary<int, ImageMargin>? questionMargins) =>
        new(boxImageMargin, validQuestionsRange, questionMargins);

    /// <summary>
    /// Gets an object representing a Delete QuestionNumberBox Definition request.
    /// </summary>
    public DeleteObject ToDelete() 
        => new(Id.ToString(CultureInfo.InvariantCulture));
}