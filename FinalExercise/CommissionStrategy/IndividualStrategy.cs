using System.Collections.Generic;
using FinalExercise.Domain.Models;

namespace FinalExercise.CommissionStrategy
{
    public class IndividualStrategy : ICommissionStrategy
    {
        private List<TravelPackage> _travelPackages;
        private int _tripDuration;
        private int _passengerAmount;

        public IndividualStrategy(List<TravelPackage> travelPackages, int tripDuration, int passengerAmount)
        {
            _travelPackages = travelPackages;
            _tripDuration = tripDuration;
            _passengerAmount = passengerAmount;
        }

        public double CalculateCommission()
        {
            double commission = 0;
            foreach (TravelPackage tp in _travelPackages)
            {
                foreach (Product product in tp.Products)
                {
                    if (product.ProductType == "Hotel")
                    {
                        if (_tripDuration < 6)
                            commission += product.Price * 0.5;
                        else
                            commission += product.Price * (int)(_tripDuration / 6);

                    }
                    else if (product.ProductType == "Car Rental")
                        commission += product.Category * 100.0 + product.Price * 0.01;

                    else if (product.ProductType == "Airplane Tickets")
                        commission += product.Price * 0.1;
                }
            }
         
            return commission * _passengerAmount;
        }
    }
}
