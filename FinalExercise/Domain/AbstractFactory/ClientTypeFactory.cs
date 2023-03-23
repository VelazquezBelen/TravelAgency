using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.AbstractFactory
{
    public class ClientTypeFactory
    {
        public IClientType GenerateClientType(Client clientRecord)
        {
            if (clientRecord.Description.Equals("Individual"))
                return new IndividualClient(new ProductFactory());
            else
                return new CorporateClient(new ProductFactory());
        } 
    }
}
