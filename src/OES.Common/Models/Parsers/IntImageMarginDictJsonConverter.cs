using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OES.Internal;

public class IntImageMarginDictJsonConverter : JsonConverter<IDictionary<int, ImageMargin>>
{
    public override void WriteJson(JsonWriter writer, IDictionary<int, ImageMargin>? value, JsonSerializer serializer)
    {
        Ensure.ArgumentNotNull(value, nameof(value));
        
        writer.WriteStartObject();
        foreach (var (pageNum, imageMargin) in value!)
        {
            writer.WritePropertyName(pageNum.ToString());
            writer.WriteValue(imageMargin.ToString());
        }
        writer.WriteEndObject();
    }

    public override IDictionary<int, ImageMargin>? ReadJson(JsonReader     reader, Type objectType, IDictionary<int, ImageMargin>? existingValue, bool hasExistingValue,
                                                            JsonSerializer serializer)
    {
        var jo = JObject.Load(reader);
        var dict = new Dictionary<int, ImageMargin>();
        foreach (var (key, val) in jo)
        {
            Ensure.ArgumentNotNull(val, nameof(val));
            
            if (!int.TryParse(key, out var intKey))
                throw new ArgumentException(
                    "The page number is invalid. It must be a string that is parsable to an integer. " +
                    $"Current value: {key}");
            dict.Add(intKey, new ImageMargin(val!.ToString()));
        }

        return dict;
    }
}