namespace OES;

/// <summary>
/// An annotation that displays line or lines.
/// </summary>
public class UnderlineAnnotation : IAnnotation
{
    public UnderlineAnnotation(int x, int y, UnderlineStyle style, int length)
    {
        AnnotationType = AnnotationType.Underline;
        LocationX = x;
        LocationY = y;
        Style = style;
        Length = length;
    }
    
    /// <inheritdoc cref="IAnnotation.AnnotationType"/>
    public AnnotationType AnnotationType { get; }
    
    /// <inheritdoc cref="IAnnotation.LocationX"/>
    public int LocationX { get; set; }
    
    /// <inheritdoc cref="IAnnotation.LocationY"/>
    public int LocationY { get; set; }
    
    /// <summary>
    /// The style of the underline.
    /// </summary>
    public UnderlineStyle Style { get; set; }
    
    /// <summary>
    /// The length of the line. Express in percentage relative to the script image's width.
    /// </summary>
    public int Length { get; set; }
}