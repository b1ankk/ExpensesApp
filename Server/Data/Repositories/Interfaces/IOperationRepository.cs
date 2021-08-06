using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base;
using ExpensesApp.Shared.Models;

namespace ExpensesApp.Server.Data.Repositories.Interfaces
{
    public interface IOperationRepository : IRepository<Operation>
    {
        public Task<IReadOnlyCollection<Operation>> GetExpendituresAsync();
        public Task<IReadOnlyCollection<Operation>> GetIncomesAsync();

        public Task<Operation> GetOperationWithTypeAndOwner(int id);
        public Task<IReadOnlyCollection<Operation>> GetOperationsWithTypeAndOwner();
    }
}
