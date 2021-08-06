using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Implementations;
using ExpensesApp.Server.Data.Repositories.Interfaces;

namespace ExpensesApp.Server.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextImpl _dbContext;
        
        public IOperationRepository Operations { get; }
        public IOperationTypeRepository OperationTypes { get; }
        public IOperationOwnerRepository OperationOwners { get; }
        public IAccountPeriodRepository AccountPeriods { get; }
        
        public UnitOfWork(DbContextImpl dbContext)
        {
            _dbContext = dbContext;
            Operations = new OperationRepository(dbContext);
            OperationTypes = new OperationTypeRepository(dbContext);
            OperationOwners = new OperationOwnerRepository(dbContext);
            AccountPeriods = new AccountingPeriodRepository(dbContext);
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
