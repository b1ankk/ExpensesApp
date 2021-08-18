using System.Collections.Generic;

namespace ExpensesApp.Shared.Models.DTOs
{
    public class AccountingSummaryDto
    {
        public ICollection<Row> Rows { get; set; }


        public class Row
        {
            public OperationTypeDto Type { get; set; }
            public OperationOwnerDto Owner { get; set; }

            public decimal Sum { get; set; }
            public IEnumerable<OperationDto> Operations { get; set; } = new List<OperationDto>();
        }
    }
}
