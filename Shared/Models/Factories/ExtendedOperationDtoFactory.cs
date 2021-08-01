using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Shared.Models.Factories
{
    public class ExtendedOperationDtoFactory
    {
        public static ExtendedOperationDto CreateFromOperation(Operation operation)
        {
            var dto = new ExtendedOperationDto {
                IdOperation = operation.IdOperation,
                OperationDate = operation.OperationDate,
                TransactionDate = operation.TransactionDate,
                TransactionType = operation.TransactionType,
                Currency = operation.Currency,
                Amount = operation.Amount,
                AfterOperationBalance = operation.AfterOperationBalance,
                Description = operation.Description,
                
                IdOperationType = operation.IdOperationType,
                IdOperationOwner = operation.IdOperationOwner,
                
                OperationType = new OperationTypeDto {
                    IdOperationType = operation.OperationType.IdOperationType,
                    Type = operation.OperationType.Type
                },
                OperationOwner = new OperationOwnerDto {
                    IdOperationOwner = operation.OperationOwner.IdOperationOwner,
                    Owner = operation.OperationOwner.Owner
                }
            };
            
            return dto;
        }
    }
}