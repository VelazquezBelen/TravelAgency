using System.Collections.Generic;
using FinalExercise.Domain.Models;

namespace FinalExercise.CommissionStrategy
{
    public class CorporateStrategy : ICommissionStrategy
    {
        private List<TravelPackage> _travelPackages;
        private int _tripDuration;
        private int _passengerAmount;
        public CorporateStrategy(List<TravelPackage> travelPackages, int tripDuration, int passengerAmount)
        {
            _travelPackages = travelPackages;
            _tripDuration = tripDuration;
            _passengerAmount = passengerAmount;
        }
        public double CalculateCommission()
        {
            double commission = 0;
            foreach(TravelPackage tp in _travelPackages)
            {
                foreach (Product product in tp.Products)
                    if (product.ProductType == "Hotel" || product.ProductType == "Car Rental")
                        commission += product.Price * _tripDuration;
                    else if (product.ProductType == "Airplane Tickets")
                        commission += product.Price * 2;
            }
            
            return commission * _passengerAmount * 0.1;
        }
    }
}
