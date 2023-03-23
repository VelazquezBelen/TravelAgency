using System.Collections.Generic;

namespace FinalExercise.DTOs
{
    public class TravelPackageGetByIdDTO
    {
        public int TravelPackageId { get; set; }
        public string Description { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}
