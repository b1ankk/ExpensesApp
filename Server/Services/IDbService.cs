using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Shared.Models;

namespace ExpensesApp.Server.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<Operation>> GetOperationsAsync();
        
        public Task AddOperations(IEnumerable<Operation> operations);
        
        
    }
}