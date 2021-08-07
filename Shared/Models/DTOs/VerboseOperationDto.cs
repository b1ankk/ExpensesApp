namespace ExpensesApp.Shared.Models.DTOs
{
    public class VerboseOperationDto : OperationDto
    {
        public OperationTypeDto OperationType { get; set; }
        public OperationOwnerDto OperationOwner { get; set; }
    }
}
