using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Base.QueryableExtensions;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Utility.Sorting;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationRepository : DbContextImplRepositoryBase<Operation>, IOperationRepository
    {
        public OperationRepository(DbContextImpl dbContext)
            : base(dbContext) { }


        public async Task<IReadOnlyCollection<Operation>> GetExpendituresAsync() {
            IReadOnlyCollection<Operation> result = await QueryOperationsToListWhereAsync(x => x.Amount < 0);
            return result;
        }

        public async Task<IReadOnlyCollection<Operation>> GetIncomesAsync() {
            IReadOnlyCollection<Operation> result = await QueryOperationsToListWhereAsync(x => x.Amount > 0);
            return result;
        }

        private async Task<IReadOnlyCollection<Operation>> QueryOperationsToListWhereAsync(
            Expression<Func<Operation, bool>> predicate
        ) {
            List<Operation> result = await DbContextImpl
                                           .Operations
                                           .Where(predicate)
                                           .ToListAsync();
            return result;
        }


        public async Task<Operation> GetOperationWithTypeAndOwner(int id) {
            Operation result = await QueryOperationsWithTypeAndOwner()
                                     .Where(x => x.IdOperation == id)
                                     .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IReadOnlyCollection<Operation>> GetOperationsWithTypeAndOwner() {
            List<Operation> result = await QueryOperationsWithTypeAndOwner().ToListAsync();
            return result;
        }

        private IQueryable<Operation> QueryOperationsWithTypeAndOwner() {
            return DbContextImpl
                   .Operations
                   .Include(x => x.OperationType)
                   .Include(x => x.OperationOwner)
                   .OrderBy(
                       SortOrderKey<Operation>.DescForKey(x => x.OperationDate),
                       SortOrderKey<Operation>.DescForKey(x => x.TransactionDate),
                       SortOrderKey<Operation>.DescForKey(x => x.IdOperation)
                   );
        }
    }
}
