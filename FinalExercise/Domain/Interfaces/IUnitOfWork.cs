using System;

namespace FinalExercise.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Client { get;  }
        IProductRepository Product { get; }
        ITravelPackageRepository TravelPackage { get; }

        ICommissionRepository Commission { get; }

        int Complete();
    }
}
