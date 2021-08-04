using ExpensesApp.Server.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories
{
    public abstract class DbContextImplRepositoryBase<T> : RepositoryBase<T> where T : class
    {
        protected DbContextImpl DbContextImpl => DbContext as DbContextImpl;
        
        protected DbContextImplRepositoryBase(DbContext dbContext) : base(dbContext) { }
    }
}
