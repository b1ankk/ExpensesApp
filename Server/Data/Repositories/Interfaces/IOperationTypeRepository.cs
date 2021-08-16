using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base;
using ExpensesApp.Shared.Models;

namespace ExpensesApp.Server.Data.Repositories.Interfaces
{
    public interface IOperationTypeRepository : IRepository<OperationType>
    {
        public Task<IReadOnlyCollection<OperationType>> GetOperationTypesSortedAsync();
    }
}
