using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// Defines the margins for cutting an image. All four values are relative (percentages).
/// </summary>
[JsonConverter(typeof(ImageMarginJsonConverter))]
public struct ImageMargin
{
    public ImageMargin(float left, float top, float right, float bottom)
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
            parseSuccess = float.TryParse(split[0], out var left);
            Left         = left;
            parseSuccess = float.TryParse(split[1], out var top) && parseSuccess;
            Top          = top;
            parseSuccess = float.TryParse(split[2], out var right) && parseSuccess;
            Right        = right;
            parseSuccess = float.TryParse(split[3], out var bottom) && parseSuccess;
            Bottom       = bottom;
        }
        catch (Exception e)
        {
            parseSuccess   = false;
            innerException = e;
        }

        if (!parseSuccess) throw new ArgumentException("Provided ImageMargin value is invalid.", nameof(@params), innerException);
    }
    
    public float Left
    {
        get => _left;
        set => _left = (float) Math.Round(value, 2);
    }
    private float _left;

    public float Top
    {
        get => _top;
        set => _top = (float) Math.Round(value, 2);
    }
    private float _top;

    public float Right
    {
        readonly get => _right;
        set => _right = (float) Math.Round(value, 2);
    }
    private float _right;

    public float Bottom
    {
        readonly get => _bottom;
        set => _bottom = (float) Math.Round(value, 2);
    }
    private float _bottom;

    public override string ToString() => $"{Left},{Top},{Right},{Bottom}";
}