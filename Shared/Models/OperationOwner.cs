using System.Collections.Generic;

namespace ExpensesApp.Shared.Models
{
    public class OperationOwner
    {
        public int IdOperationOwner { get; set; }

        public string Owner { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
