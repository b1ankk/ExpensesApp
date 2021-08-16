using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Utility.Sorting;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationOwnerRepository : DbContextImplRepositoryBase<OperationOwner>, IOperationOwnerRepository
    {
        public OperationOwnerRepository(DbContext dbContext) : base(dbContext) { }
        
        public async Task<IReadOnlyCollection<OperationOwner>> GetOperationOwnersSortedAsync() {
            IReadOnlyCollection<OperationOwner> result = await GetAllAsync(
                SortOrderKey<OperationOwner>.AscForKey(x => x.Owner)
            );
            return result;
        }
    }
}
