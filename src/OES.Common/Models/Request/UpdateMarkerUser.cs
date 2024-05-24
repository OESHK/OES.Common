using Newtonsoft.Json;

namespace OES;

/// <summary>
/// A request to update an existing marker's information.
/// </summary>
public class UpdateMarkerUser
{
    internal UpdateMarkerUser(MarkerUser markerUser)
    {
        MarkerId = markerUser.MarkerId;
        EnglishFirstName = markerUser.EnglishFirstName;
        EnglishLastName = markerUser.EnglishLastName;
        ChineseFullName = markerUser.ChineseFullName;
    }
    
    /// <summary>
    /// The ID of the marker whose information is to be updated.
    /// </summary>
    public string MarkerId { get; }
    
    [JsonProperty("first_name_eng")]
    public string EnglishFirstName { get; set; }
    
    [JsonProperty("last_mame_eng")]
    public string EnglishLastName { get; set; }
    
    [JsonProperty("name_chinese")]
    public string? ChineseFullName { get; set; }
    
    /*
     * For password update/reset, see UpdateAdminUser.cs.
     */
}