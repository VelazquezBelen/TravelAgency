using Newtonsoft.Json;

namespace FinalExercise.Domain.Models
{
    public class Configuration
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "counter")]
        public int Counter { get; set; }
    }
}
