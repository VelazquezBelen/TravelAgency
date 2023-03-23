using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalExercise.Data;
using FinalExercise.Domain.Models;

namespace FinalExercise.UnitTesting
{
    class DataDBInitializer
    {
        public DataDBInitializer() { }
        public void Seed(FinalExerciseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Client.AddRange(
                new Client() { Description = "Individual" },
                new Client() { Description = "Corporate" }
            );
            
            Product p1 = new Product() { ProductType = "Hotel", Description = "3 estrellas", Category = 1, Price = 120, TravelPackages = null };
            Product p2 = new Product() { ProductType = "Car Rental", Description = "", Category = 1, Price = 59, TravelPackages = null };
            Product p3 = new Product() { ProductType = "Hotel", Description = "5 estrellas", Category = 1, Price = 200, TravelPackages = null };
            Product p4 = new Product() { ProductType = "Airplane Tickets", Description = "", Category = 1, Price = 322, TravelPackages = null };
            Product p5 = new Product() { ProductType = "Airplane Tickets", Description = "", Category = 1, Price = 520, TravelPackages = null };

            context.TravelPackage.AddRange(
                new TravelPackage()
                {
                    Description = "Bariloche",
                    Products = new List<Product> { p1, p2 },
                    Commissions = null
                },
                new TravelPackage()
                {
                    Description = "Bariloche Premium",
                    Products = new List<Product> { p2, p3, p4 },
                    Commissions = null
                },
                new TravelPackage()
                {
                    Description = "Ushuaia Medium",
                    Products = new List<Product> { p1, p5 },
                    Commissions = null
                }
            );

            context.SaveChanges();
        }
    }
}
