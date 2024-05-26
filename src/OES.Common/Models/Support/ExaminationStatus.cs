namespace OES;

/// <summary>
/// The status of an examination.
/// </summary>
public enum ExaminationStatus
{
    /// <summary>
    /// The examination is at preparation stage. Candidate enrolling & script scanning will not be available.
    /// </summary>
    Setup = 0,
    
    /// <summary>
    /// The examination is now open for candidate's enrollment and script scanning.
    /// Changing an examination into this state is irreversible.
    /// </summary>
    Open = 1,
}