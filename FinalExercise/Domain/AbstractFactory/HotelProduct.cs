using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public class HotelProduct : IProduct
    {
        private readonly Product product;
        public HotelProduct(Product product)
        {
            this.product = product;
        }
        public double CommissionStrategyCorporate(CommissionRequestDTO commissionRequest)
        {
            return product.Price * commissionRequest.TripDuration;
        }

        public double CommissionStrategyIndividual(CommissionRequestDTO commissionRequest)
        {
            if (commissionRequest.TripDuration < 6)
                return product.Price * 0.5;
            else
                return product.Price * (int)(commissionRequest.TripDuration / 6);
        }
    }
}
