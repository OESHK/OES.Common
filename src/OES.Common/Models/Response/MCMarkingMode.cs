namespace OES;

/// <summary>
/// Determines how the MCQ is marked.
/// </summary>
public enum MCMarkingMode
{
    /// <summary>
    /// Marks are first given to the chosen correct options.
    /// Then, for each chosen incorrect option and/or not chosen correct option, marks are deducted
    /// until the total mark equals to 0.
    /// </summary>
    PenaltyOnIncorrect = 0,
    
    /// <summary>
    /// Marks are only given when all correct options are chosen and all incorrect options are not chosen.
    /// When using this mode, the <see cref="MCOptionDefinition.MarkPerOption"/> will be used
    /// as the total mark of the question.
    /// </summary>
    GiveOnAllCorrect = 1
}