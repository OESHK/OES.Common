namespace OES;

/// <summary>
/// Defines the margins for cutting an image. All four values are relative (percentages).
/// </summary>
public struct ImageMargin
{
    public ImageMargin(int left, int top, int right, int bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }
    
    public int Left { get; }
    
    public int Top { get; }
    
    public int Right { get; }
    
    public int Bottom { get; }
}