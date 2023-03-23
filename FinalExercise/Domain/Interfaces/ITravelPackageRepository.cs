using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.Interfaces
{
    public interface ITravelPackageRepository : IGenericRepository<TravelPackage>
    {
        bool Any(int id);

        public Task<IEnumerable<TravelPackage>> GetTravelPackagesByDescription(string description);

        public Task<TravelPackage> Get(int id);

        public Task<IEnumerable<TravelPackage>> GetAllPackagesById(ICollection<int> TravelPackageIds);
    }
}
