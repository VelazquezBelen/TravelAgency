using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.Interfaces
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        bool Any(int id);
                     
        //public IEnumerable<string> GetAllClientTypes();
    }

    
}
