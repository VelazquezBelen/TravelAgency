using FinalExercise.Domain.Interfaces;
using FinalExercise.Domain.Models;
using FinalExercise.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalExercise.Repositories
{
    public class TravelPackageRepository: GenericRepository<TravelPackage>, ITravelPackageRepository
    {
        public TravelPackageRepository(FinalExerciseContext context) : base(context)
        {

        }        
        public bool Any(int id)
        {
            return _context.Set<TravelPackage>().Any(travelPackage => travelPackage.TravelPackageId == id);
        }

        public async Task<IEnumerable<TravelPackage>> GetTravelPackagesByDescription(string description)
        {
            return await _context.Set<TravelPackage>().Where(x => x.Description.StartsWith(description)).ToListAsync();
        }

        public async Task<TravelPackage> Get(int id)
        {
            return await _context.Set<TravelPackage>().Include(x => x.Products).FirstOrDefaultAsync(x => x.TravelPackageId == id);
        }

        public async Task<IEnumerable<TravelPackage>> GetAllPackagesById(ICollection<int> travelPackageIds)
        {
            return await _context.Set<TravelPackage>().Where(x => travelPackageIds.Contains(x.TravelPackageId)).Include(x => x.Products).ToListAsync(); 
        }
    }
}
