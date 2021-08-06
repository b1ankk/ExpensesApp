using ExpensesApp.Server.Data.Repositories.Base;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationOwnerRepository : DbContextImplRepositoryBase<OperationOwner>, IOperationOwnerRepository
    {
        public OperationOwnerRepository(DbContext dbContext) : base(dbContext) { }
    }
}
