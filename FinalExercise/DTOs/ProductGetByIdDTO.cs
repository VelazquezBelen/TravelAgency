using System.Collections.Generic;

namespace FinalExercise.DTOs
{
    public class ProductGetByIdDTO
    {
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public ICollection<TravelPackageDTO> TravelPackages { get; set; }
    }
}
