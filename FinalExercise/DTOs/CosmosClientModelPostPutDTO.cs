using Newtonsoft.Json;

namespace FinalExercise.DTOs
{
    public class CosmosClientModelPostPutDTO
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}