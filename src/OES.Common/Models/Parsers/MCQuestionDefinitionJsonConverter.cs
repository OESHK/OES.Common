using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OES.Internal;

internal class MCQuestionDefinitionJsonConverter : JsonConverter<MCQuestionDefinition>
{
    public override void WriteJson(JsonWriter writer, MCQuestionDefinition? value, JsonSerializer serializer)
    {
        Ensure.ArgumentNotNull(value, nameof(value));

        var jToken = JToken.FromObject(value!);
        jToken["options_image_margins"] = JObject.FromObject(value!.OptionsDefinition.ToDictionary(
            x => x.OptionName,
            x => x.OptionMargin.ToString()));
        jToken["correct_options"] =
            JArray.FromObject(value.OptionsDefinition.Select(option => option.OptionName).ToList());
        
        jToken.WriteTo(writer);
    }

    public override MCQuestionDefinition? ReadJson(JsonReader reader,           Type objectType, MCQuestionDefinition? existingValue,
                                                   bool       hasExistingValue, JsonSerializer serializer)
    {
        var jo = JObject.Load(reader);
        var mcqDef = jo.ToObject<MCQuestionDefinition>();

        if (mcqDef is null)
            throw new ArgumentException("The JSON payload for an MCQuestionDefinition is invalid.");

        try
        {
            //var optionsDefs = new List<MCOptionDefinition>();
            var optionsDefs = new Dictionary<string, MCOptionDefinition>();
            foreach (var optionToken in (JObject) jo["options_image_margins"]!)
                optionsDefs.Add(
                    optionToken.Key,
                    new MCOptionDefinition(optionToken.Key, new ImageMargin((string) optionToken.Value!), false));
            foreach (var correctOptionToken in (JArray)jo["correct_options"]!)
            {
                var temp = optionsDefs[correctOptionToken.ToString()];
                temp.IsCorrect                             = true;
                optionsDefs[correctOptionToken.ToString()] = temp;
            }

            mcqDef.OptionsDefinition = new List<MCOptionDefinition>(optionsDefs.Select(kvp => kvp.Value));
        }
        catch (Exception e)
        {
            throw new ArgumentException("Failed when deserialising payload into MCQDefinition. Invalid payload.", e);
        }

        return mcqDef;
    }
}