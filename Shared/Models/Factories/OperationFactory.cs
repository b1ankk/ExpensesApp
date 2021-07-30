using System;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Shared.Models.Factories
{
    public static class OperationFactory
    {
        public static Operation CreateFromOperationDto(OperationDto operationDto)
        {
            return new Operation {
                IdOperation = operationDto.IdOperation ?? throw new NullReferenceException(),
                OperationDate = operationDto.OperationDate ?? throw new NullReferenceException(),
                TransactionDate = operationDto.TransactionDate ?? throw new NullReferenceException(),
                TransactionType = operationDto.TransactionType,
                Currency = operationDto.Currency,
                Amount = operationDto.Amount ?? throw new NullReferenceException(),
                AfterOperationBalance = operationDto.AfterOperationBalance ?? throw new NullReferenceException(),
                Description = operationDto.Description
            };
        }
    }
}