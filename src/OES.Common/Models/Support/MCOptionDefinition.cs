namespace OES;

/// <summary>
/// Defines an MCQ option.
/// </summary>
public struct MCOptionDefinition
{
    public MCOptionDefinition(string optionName, ImageMargin optionMargin, bool isCorrect)
    {
        OptionName = optionName;
        OptionMargin = optionMargin;
        IsCorrect = isCorrect;
    }
    
    /// <summary>
    /// The name of the option. The name is usually one-alphabet long.
    /// </summary>
    public string OptionName { get; }
    
    /// <summary>
    /// The image margins of that option.
    /// </summary>
    public ImageMargin OptionMargin { get; }
    
    /// <summary>
    /// Whether the option is correct.
    /// </summary>
    public bool IsCorrect { get; }
}