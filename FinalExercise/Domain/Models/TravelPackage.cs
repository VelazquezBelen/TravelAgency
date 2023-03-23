using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinalExercise.Domain.Models
{
    public class TravelPackage
    {
        [Key]
        public int TravelPackageId { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Commission> Commissions { get; set; }
    }
}
