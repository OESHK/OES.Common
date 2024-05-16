namespace OES;

/// <summary>
/// An annotation made by a marker on a script.
/// </summary>
public interface IAnnotation
{
    /// <summary>
    /// The type of the annotation.
    /// </summary>
    public AnnotationType AnnotationType { get; }
    
    /// <summary>
    /// The horizontal location of the annotation. Expressed in percentage, ranging from 0 to 100.
    /// </summary>
    public int LocationX { get; set; }
    
    /// <summary>
    /// The vertical location of the annotation. Expressed in percentage, ranging from 0 to 100.
    /// </summary>
    public int LocationY { get; set; }
}