using System;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Shared.Models.Factories
{
    public static class OperationFactory
    {
        public static Operation CreateFromOperationDto(OperationDto operationDto)
        {
            return new Operation {
                IdOperation = operationDto.IdOperation.GetValueOrDefault(),
                OperationDate = operationDto.OperationDate.GetValueOrDefault(),
                TransactionDate = operationDto.TransactionDate.GetValueOrDefault(),
                TransactionType = operationDto.TransactionType,
                Currency = operationDto.Currency,
                Amount = operationDto.Amount.GetValueOrDefault(),
                AfterOperationBalance = operationDto.AfterOperationBalance.GetValueOrDefault(),
                Description = operationDto.Description
            };
        }
    }
}