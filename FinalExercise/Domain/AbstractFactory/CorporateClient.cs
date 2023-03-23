using System.Collections.Generic;
using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public class CorporateClient : IClientType
    {
        private readonly ProductFactory productFactory;

        public CorporateClient(ProductFactory productFactory)
        {
            this.productFactory = productFactory;
        }
        public double CommissionStrategy(List<TravelPackage> travelPackages, CommissionRequestDTO commissionRequest)
        {
            double commission = 0;
            foreach (TravelPackage tp in travelPackages)
            {
                foreach (Product product in tp.Products)
                {
                    var productFactory = this.productFactory.GenerateProduct(product);
                    commission += productFactory.CommissionStrategyCorporate(commissionRequest);
                }
            }
            return commission * commissionRequest.PassengersAmmount * 0.1;
        }
    }
}
