using System.Collections.Generic;
using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public class IndividualClient : IClientType
    {
        private readonly ProductFactory productFactory;

        public IndividualClient(ProductFactory productFactory)
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
                    commission += productFactory.CommissionStrategyIndividual(commissionRequest);
                }
            }
            return commission * commissionRequest.PassengersAmmount;
        }
    }
}
