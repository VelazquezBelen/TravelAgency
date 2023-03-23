using FinalExercise.Domain.Models;

namespace FinalExercise.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        bool Any(int id);
    }
}
