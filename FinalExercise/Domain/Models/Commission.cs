using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalExercise.Domain.Models
{
    public class Commission
    {
        [Key]
        public int CommissionId { get; set; }
        public int ClientTypeId { get; set; }
        public int PassengersAmmount { get; set; }
        public int TripDuration { get; set; }
        public ICollection<TravelPackage> TravelPackages { get; set; }
        public double CommissionResult { get; set; }
    }
}
