using System;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Interfaces;

namespace ExpensesApp.Server.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IOperationRepository Operations { get; }
        IOperationTypeRepository OperationTypes { get; }
        IOperationOwnerRepository OperationOwners { get; }
        IAccountPeriodRepository AccountPeriods { get; }
        
        public Task<int> CompleteAsync();
    }
}
