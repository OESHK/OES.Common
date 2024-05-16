namespace OES;

/// <summary>
/// An annotation that displays a symbol (tick, cross, question mark, etc.).
/// </summary>
public class SymbolAnnotation : IAnnotation
{
    /// <summary>
    /// Creates an instance of a SymbolAnnotation.
    /// </summary>
    /// <param name="annotationType">Must be Tick, Cross, Circle, Box, or QuestionMark.</param>
    public SymbolAnnotation(AnnotationType annotationType, int x, int y, int width, int height)
    {
        if (annotationType is not
            (AnnotationType.Tick or AnnotationType.Cross or AnnotationType.Circle or AnnotationType.Box or AnnotationType.QuestionMark))
            throw new ArgumentException("Invalid AnnotationType for SymbolAnnotation.", nameof(annotationType));
        
        AnnotationType = annotationType;
        LocationX = x;
        LocationY = y;
        Width = width;
        Height = height;
    }
    
    /// <inheritdoc cref="IAnnotation.AnnotationType"/>
    public AnnotationType AnnotationType { get; }
    
    /// <inheritdoc cref="IAnnotation.LocationX"/>
    public int LocationX { get; set; }
    
    /// <inheritdoc cref="IAnnotation.LocationY"/>
    public int LocationY { get; set; }
    
    /// <summary>
    /// The width of the annotation. Expressed as percentage relative to the script image's width.
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// The height of the annotation. Expressed as percentage relative to the script image's height.
    /// </summary>
    public int Height { get; set; }
}