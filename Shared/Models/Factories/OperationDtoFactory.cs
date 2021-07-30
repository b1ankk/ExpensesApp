using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Shared.Models.Factories
{
    public static class OperationDtoFactory
    {
        public static OperationDto CreateFromOperation(Operation operation)
        {
            return new OperationDto {
                IdOperation = operation.IdOperation,
                OperationDate = operation.OperationDate,
                TransactionDate = operation.TransactionDate,
                TransactionType = operation.TransactionType,
                Currency = operation.Currency,
                Amount = operation.Amount,
                AfterOperationBalance = operation.AfterOperationBalance,
                Description = operation.Description
            };
        }
    }
}