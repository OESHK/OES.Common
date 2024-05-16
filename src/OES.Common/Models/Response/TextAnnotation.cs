namespace OES;

/// <summary>
/// An annotation that displays texts entered by the marker.
/// </summary>
public class TextAnnotation : IAnnotation
{
    /// <summary>
    /// Creates an instance of a TextAnnotation.
    /// </summary>
    public TextAnnotation(int x, int y, int width, int height, string content)
    {
        AnnotationType = AnnotationType.Text;
        LocationX = x;
        LocationY = y;
        Width = width;
        Height = height;
        Content = content;
    }
    
    /// <inheritdoc cref="IAnnotation.AnnotationType"/>
    public AnnotationType AnnotationType { get; }
    
    /// <inheritdoc cref="IAnnotation.LocationX"/>
    public int LocationX { get; set; }
    
    /// <inheritdoc cref="IAnnotation.LocationY"/>
    public int LocationY { get; set; }
    
    /// <summary>
    /// The width of the text annotation.
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// The height of the text annotation.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The content of the text annotation.
    /// </summary>
    public string Content { get; set; }
}