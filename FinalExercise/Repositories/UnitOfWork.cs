using FinalExercise.Domain.Interfaces;
using FinalExercise.Data;
using System;

namespace FinalExercise.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinalExerciseContext _context;

        public IClientRepository Client { get; }
        public IProductRepository Product { get; }
        public ITravelPackageRepository TravelPackage { get; }
        public ICommissionRepository Commission { get; }

        public UnitOfWork(FinalExerciseContext finalExercisecontext,
            IClientRepository clientsRepository,
            IProductRepository productsRepository, 
            ITravelPackageRepository travelPackageRepository,
            ICommissionRepository commissionRepository)
        {
            this._context = finalExercisecontext;
            this.Client = clientsRepository;
            this.Product = productsRepository;
            this.TravelPackage = travelPackageRepository;
            this.Commission = commissionRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
