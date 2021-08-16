using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Utility.Sorting;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationTypeRepository : DbContextImplRepositoryBase<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyCollection<OperationType>> GetOperationTypesSortedAsync() {
            IReadOnlyCollection<OperationType> result = await GetAllAsync(
                SortOrderKey<OperationType>.AscForKey(x => x.Type)
            );
            return result;
        }
    }
}
