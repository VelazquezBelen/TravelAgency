using System.Collections.Generic;

namespace FinalExercise.DTOs
{
    public class TravelPackagePostDTO
    {
        public string Description { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}
