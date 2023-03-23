using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalExercise.DTOs
{
    public class CommissionRequestDTO
    {
        public int ClientTypeId { get; set; }
        [Range(1, 10, ErrorMessage = "Passenger ammount must be between 1 to 10")]
        public int PassengersAmmount { get; set; }
        [Range(1, 60, ErrorMessage = "Trip duration must be between 1 to 60")]
        public int TripDuration { get; set; }
        public ICollection<int> TravelPackages { get; set; }
    }
}
