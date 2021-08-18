using System.Collections.Generic;

namespace ExpensesApp.Shared.Models.UtilityModels
{
    public class AccountingSummary
    {
        public ICollection<Row> Rows { get; }

        public AccountingSummary(ICollection<Row> rows = null) {
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
