using System.Collections.Generic;
using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.CommissionStrategy
{
    public class ClientTypeStrategy : ICommissionStrategy
    {
        private CommissionRequestDTO _commissionRequest;
        private string _clientType; 
        private List<TravelPackage> _travelPackages;
        private ICommissionStrategy _ClientTypeStrategy;

        public ClientTypeStrategy(CommissionRequestDTO commissionRequest, List<TravelPackage> travelPackages, string clientType)
        {
            _commissionRequest = commissionRequest;
            _travelPackages = travelPackages;
            _clientType = clientType;
        }

        public double CalculateCommission()
        {
            if (_clientType.Equals("Individual"))
                _ClientTypeStrategy = new IndividualStrategy(_travelPackages, _commissionRequest.TripDuration, _commissionRequest.PassengersAmmount);

            else if (_clientType.Equals("Corporate"))
                _ClientTypeStrategy = new CorporateStrategy(_travelPackages, _commissionRequest.TripDuration, _commissionRequest.PassengersAmmount);

            return _ClientTypeStrategy.CalculateCommission();
        }
    }
}
