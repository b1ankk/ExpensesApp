using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Interfaces;

namespace ExpensesApp.Server.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextImpl _dbContext;
        
        public IOperationRepository Operations { get; private set; }
        
        public UnitOfWork(DbContextImpl dbContext, IOperationRepository operations)
        {
            _dbContext = dbContext;
            Operations = operations;
        }
        
        
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        
        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
