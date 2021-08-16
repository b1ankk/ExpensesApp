using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class AccountingPeriodRepository : DbContextImplRepositoryBase<AccountingPeriod>, IAccountPeriodRepository
    {
        public AccountingPeriodRepository(DbContext dbContext) : base(dbContext) { }
    }
}
