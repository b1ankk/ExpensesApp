using System.Collections.Generic;

namespace ExpensesApp.Shared.Models.UtilityModels
{
    public class AccountingSummary
    {
        public AccountingPeriod AccountingPeriod { get; set; }
        public ICollection<Row> Rows { get; }

        public AccountingSummary(AccountingPeriod accountingPeriod = null, ICollection<Row> rows = null) {
            AccountingPeriod = accountingPeriod;
            Rows = rows ?? new List<Row>();
        }


        public class Row
        {
            public OperationType Type { get; set; }
            public OperationOwner Owner { get; set; }

            public decimal Sum { get; set; }
            public IEnumerable<Operation> Operations { get; set; } = new List<Operation>();
        }
    }
}
