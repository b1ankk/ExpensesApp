using System.Collections.Generic;

namespace ExpensesApp.Shared.Models
{
    public class OperationType
    {
        public int IdOperationType { get; set; }
        
        public string Type { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}