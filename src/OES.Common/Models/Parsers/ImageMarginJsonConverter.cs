using Newtonsoft.Json;

namespace OES.Internal;

internal class ImageMarginJsonConverter : JsonConverter<ImageMargin>
{
    public override void WriteJson(JsonWriter writer, ImageMargin value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }

    public override ImageMargin ReadJson(JsonReader     reader, Type objectType, ImageMargin existingValue, bool hasExistingValue,
                                         JsonSerializer serializer)
    {
        Ensure.ArgumentNotNullOrEmpty((string?) reader.Value, nameof(reader.Value));
        
        var s = (string) reader.Value!;
        return new ImageMargin(s);
    }
}