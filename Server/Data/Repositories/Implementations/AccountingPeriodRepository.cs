using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Server.Data.Repositories.Base.Implementation;
using ExpensesApp.Server.Data.Repositories.Interfaces;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.UtilityModels;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Implementations
{
    public class AccountingPeriodRepository : DbContextImplRepositoryBase<AccountingPeriod>, IAccountPeriodRepository
    {
        public AccountingPeriodRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<AccountingSummary> GetSummaryForPeriodAsync(int idAccountingPeriod) {
            AccountingPeriod period = await DbContextImpl.AccountingPeriods.FirstOrDefaultAsync(
                x => x.IdAccountingPeriod == idAccountingPeriod
            );
            if (period == null)
                return null;

            var summaryBuilder = new SummaryBuilder(DbContextImpl, period);
            AccountingSummary summary = await summaryBuilder.BuildAsync();

            return summary;
        }


        private class SummaryBuilder
        {
            private readonly DbContextImpl dbContextImpl;
            private readonly AccountingPeriod period;
            
            public SummaryBuilder(DbContextImpl dbContextImpl, AccountingPeriod accountingPeriod) {
                this.dbContextImpl = dbContextImpl;
                this.period = accountingPeriod;
            }

            
            public async Task<AccountingSummary> BuildAsync() {
                List<AccountingSummary.Row> summaryRows = await QuerySummaryRows().ToListAsync();

                foreach (AccountingSummary.Row row in summaryRows)
                    row.Operations = await QuerySummaryRowOperations(row).ToListAsync();

                var summary = new AccountingSummary(summaryRows);
                return summary;
            }

            private IQueryable<AccountingSummary.Row> QuerySummaryRows() {
                IOrderedQueryable<AccountingSummary.Row> summaryRows =
                    dbContextImpl
                        .Operations
                        .Where(
                            x => x.OperationDate >= period.StartDateInclusive &&
                                 x.OperationDate < period.EndDateExclusive
                        )
                        .Where(x => x.IdOperationOwner != null && x.IdOperationType != null)
                        .GroupBy(
                            x => new { x.IdOperationOwner, x.IdOperationType },
                            x => x.Amount,
                            (key, values) => new {
                                key.IdOperationOwner,
                                key.IdOperationType,
                                Sum = values.Sum(),
                            }
                        )
                        .Select(
                            x => new AccountingSummary.Row() {
                                Owner = dbContextImpl
                                        .OperationOwners
                                        .FirstOrDefault(oo => x.IdOperationOwner == oo.IdOperationOwner),
                                Type = dbContextImpl
                                       .OperationTypes
                                       .FirstOrDefault(oo => x.IdOperationType == oo.IdOperationType),
                                Sum = x.Sum,
                            }
                        )
                        .OrderBy(x => x.Owner.Owner)
                        .ThenBy(x => x.Type.Type);
                return summaryRows;
            }

            private IQueryable<Operation> QuerySummaryRowOperations(AccountingSummary.Row row) {
                return dbContextImpl
                       .Operations
                       .Where(
                           x => x.OperationDate >= period.StartDateInclusive &&
                                x.OperationDate < period.EndDateExclusive
                       )
                       .Where(
                           x => x.IdOperationOwner == row.Owner.IdOperationOwner &&
                                x.IdOperationType == row.Type.IdOperationType
                       );
            }
        }
    }
}
