using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.UtilityModels;

namespace ExpensesApp.Server.Data.Repositories.Interfaces
{
    public interface IAccountPeriodRepository : IRepository<AccountingPeriod>
    {
        public Task<AccountingSummary> GetSummaryForPeriodAsync(int periodId);
    }
}
