using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Implementations;
using ExpensesApp.Server.Data.Repositories.Interfaces;

namespace ExpensesApp.Server.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextImpl dbContext;

        public IOperationRepository Operations { get; }
        public IOperationTypeRepository OperationTypes { get; }
        public IOperationOwnerRepository OperationOwners { get; }
        public IAccountPeriodRepository AccountPeriods { get; }

        public UnitOfWork(DbContextImpl dbContext) {
            this.dbContext = dbContext;
            Operations = new OperationRepository(dbContext);
            OperationTypes = new OperationTypeRepository(dbContext);
            OperationOwners = new OperationOwnerRepository(dbContext);
            AccountPeriods = new AccountingPeriodRepository(dbContext);
        }


        public async Task<int> CompleteAsync() {
            return await dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync() {
            await dbContext.DisposeAsync();
        }
    }
}
