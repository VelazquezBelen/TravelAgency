using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinalExercise.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public double Price { get; set; }
        public ICollection<TravelPackage> TravelPackages { get; set; }
    }
}
