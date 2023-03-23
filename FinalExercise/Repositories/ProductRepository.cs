using FinalExercise.Domain.Interfaces;
using FinalExercise.Domain.Models;
using FinalExercise.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FinalExercise.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(FinalExerciseContext context) : base(context)
        {

        }

        public bool Any(int id)
        {
            return _context.Set<Product>().Any(product=> product.ProductId == id);
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Set<Product>().Include(x => x.TravelPackages).FirstOrDefaultAsync(x => x.ProductId == id);
        }

    }
}
