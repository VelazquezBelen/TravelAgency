using System.ComponentModel.DataAnnotations;

namespace FinalExercise.DTOs
{
    public class ProductDTO
    {        
        public int ProductId { get; set; }
        [RegularExpression("Hotel|Car Rental|Airplane Tickets", ErrorMessage = "The product type must be Hotel, Car Rental or Airplane Tickets")]
        public string ProductType { get; set; }
        public string Description { get; set; }
        [Range(1, 3, ErrorMessage = "Category must be between 1 to 3")]
        public int Category { get; set; }
        public double Price { get; set; }
    }
}
