using System.ComponentModel.DataAnnotations;

namespace FinalExercise.DTOs
{
    public class ClientPostDTO
    {
        [RegularExpression("Corporate|Individual", ErrorMessage = "The client type must be Corporate or Individual")]
        public string Description { get; set; }
    }
}
