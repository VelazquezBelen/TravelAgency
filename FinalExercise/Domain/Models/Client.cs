using System.ComponentModel.DataAnnotations;

namespace FinalExercise.Domain.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [RegularExpression("Corporate|Individual", ErrorMessage = "The client type must be Corporate or Individual")]
        public string Description { get; set; }
    }
}
