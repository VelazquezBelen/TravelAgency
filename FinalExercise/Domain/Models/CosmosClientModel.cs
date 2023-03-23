using Newtonsoft.Json;

namespace FinalExercise.Domain.Models
{   
    public class CosmosClientModel
    {
        [JsonProperty(PropertyName = "id")]
        public string ClientGUID { get; set; }

        [JsonProperty(PropertyName = "clientId")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
