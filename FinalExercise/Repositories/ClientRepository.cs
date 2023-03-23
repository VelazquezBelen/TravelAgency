using FinalExercise.Domain.Interfaces;
using FinalExercise.Domain.Models;
using FinalExercise.Data;
using System.Linq;

namespace FinalExercise.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(FinalExerciseContext context) : base(context)
        {

        }
        public bool Any(int id)
        {
            return _context.Set<Client>().Any(client => client.ClientId == id);
        }   
    }
}
