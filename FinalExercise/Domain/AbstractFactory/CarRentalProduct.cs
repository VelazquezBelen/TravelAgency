using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public class CarRentalProduct : IProduct
    {
        private readonly Product product;
        public CarRentalProduct(Product product)
        {
            this.product = product;
        }
        public double CommissionStrategyCorporate(CommissionRequestDTO commissionRequest)
        {
            return product.Price * commissionRequest.TripDuration;
        }

        public double CommissionStrategyIndividual(CommissionRequestDTO commissionRequest)
        {
            return product.Category * 100.0 + product.Price * 0.01;
        }
    }
}
