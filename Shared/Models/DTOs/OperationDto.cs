using System;

namespace ExpensesApp.Shared.Models.DTOs
{
    public class OperationDto
    {
        public int IdOperation { get; set; }
        
        public DateTime OperationDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal AfterOperationBalance { get; set; }
        public string Description { get; set; }
        
        public int? IdOperationType { get; set; }
        public int? IdOperationOwner { get; set; }
    }
}
