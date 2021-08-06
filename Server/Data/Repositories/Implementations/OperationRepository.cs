﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class OperationRepository : DbContextImplRepositoryBase<Operation>, IOperationRepository
    {
        public OperationRepository(DbContextImpl dbContext)
            : base(dbContext) { }
        
        
        public async Task<IReadOnlyCollection<Operation>> GetExpendituresAsync()
        {
            var result = await DbContextImpl
                               .Operations
                               .Where(x => x.Amount < 0)
                               .ToListAsync();
            return result;
        }
        
        public async Task<IReadOnlyCollection<Operation>> GetIncomesAsync()
        {
            var result = await DbContextImpl
                               .Operations
                               .Where(x => x.Amount > 0)
                               .ToListAsync();
            return result;
        }
    }
}