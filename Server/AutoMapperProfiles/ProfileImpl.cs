using AutoMapper;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Server.AutoMapperProfiles
{
    public class ProfileImpl : Profile
    {
        public ProfileImpl()
        {
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<OperationType, OperationTypeDto>().ReverseMap();
            CreateMap<OperationOwner, OperationOwnerDto>().ReverseMap();
            CreateMap<Operation, VerboseOperationDto>();
        }
    }
}