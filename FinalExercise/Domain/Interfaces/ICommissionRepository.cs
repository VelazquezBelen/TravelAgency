using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.Interfaces
{
    public interface ICommissionRepository : IGenericRepository<Commission>
    {
        public Task<IEnumerable<Commission>> GetAll();
    }
}
