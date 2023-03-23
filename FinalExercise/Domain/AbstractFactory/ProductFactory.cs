using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.AbstractFactory
{
    public class ProductFactory
    {
        public IProduct GenerateProduct(Product productRecord)
        {
            if (productRecord.ProductType.Equals("Hotel"))
                return new HotelProduct(productRecord);
            if (productRecord.ProductType.Equals("Car Rental"))
                return new CarRentalProduct(productRecord);
            if (productRecord.ProductType.Equals("Airplane Tickets"))
                return new AirplaneTicketsProduct(productRecord);
            return null;
        }
    }
}
