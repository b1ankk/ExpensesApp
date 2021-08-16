using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationTypeRepository : DbContextImplRepositoryBase<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(DbContext dbContext) : base(dbContext) { }
    }
}
