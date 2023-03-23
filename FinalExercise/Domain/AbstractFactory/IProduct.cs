using FinalExercise.DTOs;

namespace FinalExercise.Domain.AbstractFactory
{
    public interface IProduct 
    {
        public double CommissionStrategyCorporate(CommissionRequestDTO commissionRequest);
        public double CommissionStrategyIndividual(CommissionRequestDTO commissionRequest);
    }
}
