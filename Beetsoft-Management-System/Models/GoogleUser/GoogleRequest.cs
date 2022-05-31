using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Beetsoft_Management_System.Models.GoogleUser
{
    public class GoogleRequest
    {
        public const string PROVIDER = "google";

        [Required]
        [JsonProperty("idToken")]
        public string IdToken {set;get;}
    }
}