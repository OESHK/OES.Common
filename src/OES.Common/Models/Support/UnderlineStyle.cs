namespace OES;

/// <summary>
/// The style of an UnderlineAnnotation.
/// </summary>
public enum UnderlineStyle
{
    /// <summary>
    /// One single straight line.
    /// </summary>
    Straight = 1,
    
    /// <summary>
    /// Two parallel straight lines.
    /// </summary>
    StraightStraight = 2,
    
    /// <summary>
    /// One straight line above one curly line.
    /// </summary>
    StraightCurly = 3,
    
    /// <summary>
    /// One single curly line.
    /// </summary>
    Curly = 4,
    
    /// <summary>
    /// Two parallel curly lines.
    /// </summary>
    CurlyCurly = 5,
    
    /// <summary>
    /// One curly line above one straight line.
    /// </summary>
    CurlyStraight = 6
}