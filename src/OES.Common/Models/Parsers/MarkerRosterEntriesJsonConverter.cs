using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OES.Internal;

internal class MarkerRosterEntriesJsonConverter : JsonConverter<ICollection<MarkerRosterEntry>>
{
    public override void WriteJson(JsonWriter writer, ICollection<MarkerRosterEntry>? value, JsonSerializer serializer)
    {
        var jo = new JObject
        {
            {
                "supervisors", new JArray(
                    value is null
                        ? Array.Empty<string>()
                        : value.Where(marker => marker.MarkerRole == MarkerRole.Supervisor)
                               .Select(marker => marker.MarkerId)
                )
            },
            {
                "markers", new JArray(
                    value is null
                        ? Array.Empty<string>()
                        : value.Where(marker => marker.MarkerRole == MarkerRole.Marker)
                               .Select(marker => marker.MarkerId)
                )
            }
        };
        jo.WriteTo(writer);
    }

    public override ICollection<MarkerRosterEntry>? ReadJson(JsonReader     reader, Type objectType, ICollection<MarkerRosterEntry>? existingValue, bool hasExistingValue,
                                                             JsonSerializer serializer)
    {
        var jo = JObject.Load(reader);
        var supervisors = jo["supervisors"]?.ToObject<List<string>>();
        var markers = jo["markers"]?.ToObject<List<string>>();

        var returnValue = new List<MarkerRosterEntry>();
        
        if (supervisors is not null) 
            returnValue.AddRange(supervisors.Select(supervisorId => new MarkerRosterEntry(supervisorId, MarkerRole.Supervisor)));
        if (markers is not null)
            returnValue.AddRange(markers.Select(markerId => new MarkerRosterEntry(markerId, MarkerRole.Marker)));

        return returnValue;
    }
}