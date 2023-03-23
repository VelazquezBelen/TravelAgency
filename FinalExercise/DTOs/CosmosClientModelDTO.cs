using Newtonsoft.Json;

namespace FinalExercise.DTOs
{
    public class CosmosClientModelDTO
    {
        [JsonProperty(PropertyName = "clientId")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
