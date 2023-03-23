using System.Collections.Generic;
using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public interface IClientType
    {
        public double CommissionStrategy(List<TravelPackage> travelPackages, CommissionRequestDTO commissionRequest);
    }
}
