using System;

namespace ExpensesApp.Shared.Models
{
    public class AccountingPeriod
    {
        public int IdAccountingPeriod { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime StartDateInclusive { get; set; }
        public DateTime EndDateExclusive { get; set; }
    }
}
