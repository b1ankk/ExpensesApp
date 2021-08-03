﻿namespace ExpensesApp.Shared.Models.DTOs
{
    public class ExtendedOperationDto : OperationDto
    {
        public int? IdOperationType { get; set; }
        public int? IdOperationOwner { get; set; }
        
        public OperationTypeDto OperationType { get; set; }
        public OperationOwnerDto OperationOwner { get; set; }
    }
}