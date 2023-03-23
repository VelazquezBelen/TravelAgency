using Microsoft.EntityFrameworkCore;
using FinalExercise.Domain.Models;

namespace FinalExercise.Data
{
    public class FinalExerciseContext : DbContext
    {
        public FinalExerciseContext (DbContextOptions<FinalExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<TravelPackage> TravelPackage { get; set; }

        public DbSet<Commission> Commission { get; set; }
    }
}
