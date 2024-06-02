using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Defines the margins for cutting an image. All four values are relative (percentages).
/// </summary>
[JsonConverter(typeof(ImageMarginJsonConverter))]
public struct ImageMargin
{
    public ImageMargin(int left, int top, int right, int bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public ImageMargin(string @params)
    {
        Ensure.ArgumentNotNullOrEmpty(@params, nameof(@params));

        bool parseSuccess;
        Exception? innerException = null;

        try
        {
            var split = @params.Split(',');
            parseSuccess = int.TryParse(split[0], out _left)
                           && int.TryParse(split[1], out _top)
                           && int.TryParse(split[2], out _right)
                           && int.TryParse(split[3], out _bottom);
        }
        catch (Exception e)
        {
            parseSuccess   = false;
            innerException = e;
        }

        if (!parseSuccess) throw new ArgumentException("Provided ImageMargin value is invalid.", nameof(@params), innerException);
    }
    
    public int Left
    {
        get => _left;
        set => _left = value;
    }
    private int _left;

    public int Top
    {
        get => _top;
        set => _top = value;
    }
    private int _top;

    public int Right
    {
        readonly get => _right;
        set => _right = value;
    }
    private int _right;

    public int Bottom
    {
        readonly get => _bottom;
        set => _bottom = value;
    }
    private int _bottom;

    public override string ToString() => $"{Left},{Top},{Right},{Bottom}";
}