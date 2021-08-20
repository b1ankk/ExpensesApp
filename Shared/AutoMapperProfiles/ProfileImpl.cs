using AutoMapper;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;
using ExpensesApp.Shared.Models.UtilityModels;

namespace ExpensesApp.Shared.AutoMapperProfiles
{
    public class ProfileImpl : Profile
    {
        public ProfileImpl() {
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<OperationType, OperationTypeDto>().ReverseMap();
            CreateMap<OperationOwner, OperationOwnerDto>().ReverseMap();
            CreateMap<Operation, VerboseOperationDto>();

            CreateMap<AccountingPeriod, AccountingPeriodDto>().ReverseMap();
            CreateMap<AccountingSummary, AccountingSummaryDto>().ReverseMap();
            CreateMap<AccountingSummary.Row, AccountingSummaryDto.Row>().ReverseMap();
        }
    }
}
