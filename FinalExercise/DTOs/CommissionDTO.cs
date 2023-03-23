using System.Collections.Generic;

namespace FinalExercise.DTOs
{
    public class CommissionDTO
    {
        public int CommissionId { get; set; }
        public int ClientTypeId { get; set; }
        public int PassengersAmmount { get; set; }
        public int TripDuration { get; set; }
        public ICollection<TravelPackageDTO> TravelPackages { get; set; }
        public double CommissionResult { get; set; }
    }
}
