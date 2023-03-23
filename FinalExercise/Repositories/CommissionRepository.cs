using FinalExercise.Domain.Interfaces;
using FinalExercise.Domain.Models;
using FinalExercise.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalExercise.Repositories
{
    public class CommissionRepository : GenericRepository<Commission>, ICommissionRepository
    {
        public CommissionRepository(FinalExerciseContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Commission>> GetAll()
        {
            return await _context.Set<Commission>().Include(commission => commission.TravelPackages).ToListAsync();
        }
    }
}
