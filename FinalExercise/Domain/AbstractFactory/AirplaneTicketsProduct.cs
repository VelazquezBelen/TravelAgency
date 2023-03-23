using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public class AirplaneTicketsProduct : IProduct
    {
        private readonly Product product;
        public AirplaneTicketsProduct(Product product)
        {
            this.product = product;
        }
        public double CommissionStrategyCorporate(CommissionRequestDTO commissionRequest)
        {
            return product.Price * 2;
        }

        public double CommissionStrategyIndividual(CommissionRequestDTO commissionRequest)
        {
            return product.Price * 0.1;
        }
    }
}
