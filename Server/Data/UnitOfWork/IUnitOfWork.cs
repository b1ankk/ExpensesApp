using System;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories;

namespace ExpensesApp.Server.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IOperationRepository Operations { get; }
        
        public Task<int> CompleteAsync();
    }
}
