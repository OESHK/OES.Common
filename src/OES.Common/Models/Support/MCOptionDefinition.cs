using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Defines an MCQ option.
/// </summary>
public struct MCOptionDefinition
{
    [JsonConstructor]
    public MCOptionDefinition(
        string optionName,
        ImageMargin imageMargin,
        bool isCorrect)
    {
        OptionName  = optionName;
        ImageMargin = imageMargin;
        IsCorrect   = isCorrect;
    }
    
    /// <summary>
    /// The name of the option. The name is usually one-alphabet long.
    /// </summary>
    public string OptionName { get; }
    
    /// <summary>
    /// The image margins of that option.
    /// </summary>
    public ImageMargin ImageMargin { get; }
    
    /// <summary>
    /// Whether the option is correct.
    /// </summary>
    public bool IsCorrect { get; internal set; }
}