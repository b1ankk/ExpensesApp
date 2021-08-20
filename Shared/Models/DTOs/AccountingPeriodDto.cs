using System;

namespace ExpensesApp.Shared.Models.DTOs
{
    public class AccountingPeriodDto
    {
        public int IdAccountingPeriod { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDateInclusive { get; set; }
        public DateTime EndDateExclusive { get; set; }
    }
}
