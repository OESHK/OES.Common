using Newtonsoft.Json;
using OES.Internal;

namespace OES;

/// <summary>
/// A request to create a new marker.
/// </summary>
public class CreateMarkerUser
{
   public CreateMarkerUser(string id, string engFirstName, string engLastName, string? chiName, string password)
   {
      MarkerId = id;
      EnglishFirstName = engFirstName;
      EnglishLastName = engLastName;
      ChineseFullName = chiName;
      LoginSalt = PasswordHash.GetSalt();
      _password = password;
      PasswordHashed = PasswordHash.Hash(_password, LoginSalt);
   }
   
   /// <summary>
   /// The login ID of the marker.
   /// </summary>
   public string MarkerId { get; set; }
   
   /// <summary>
   /// The marker's first name in English.
   /// </summary>
   [JsonProperty("first_name_eng")]
   public string EnglishFirstName { get; set; }
    
   /// <summary>
   /// The marker's last name in English.
   /// </summary>
   [JsonProperty("last_mame_eng")]
   public string EnglishLastName { get; set; }
    
   /// <summary>
   /// The marker's Chinese full name.
   /// </summary>
   [JsonProperty("name_chinese")]
   public string? ChineseFullName { get; set; }
   
   /// <summary>
   /// The marker's password.
   /// </summary>
   [JsonIgnore]
   public string Password
   {
      get => _password;
      set
      {
         _password = value;
         PasswordHashed = PasswordHash.Hash(value, LoginSalt);
      }
      
   }
   private string _password;
   
   /// <summary>
   /// The marker's hashed password. Automatically generated upon assignment of <see cref="Password"/>.
   /// </summary>
   [JsonProperty("login_hash")]
   public string PasswordHashed { get; internal set; }
   
   /// <summary>
   /// The marker's salt. Automatically generated upon creation of this object.
   /// </summary>
   public string LoginSalt { get; }
}