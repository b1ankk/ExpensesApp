using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using ExpensesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = ExpensesApp.Server.Data.DbContext;

namespace ExpensesApp.Server.Services
{
    public class DbService : IDbService
    {
        private readonly DbContext _dbContext;

        public DbService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Operation>> GetOperationsAsync()
        {
            var operations = await _dbContext.Operations.ToListAsync();
            return operations;
        }

        public async Task AddOperations(IEnumerable<Operation> operations)
        {
            await _dbContext.AddRangeAsync(operations);
            await _dbContext.SaveChangesAsync();
        }
    }
}