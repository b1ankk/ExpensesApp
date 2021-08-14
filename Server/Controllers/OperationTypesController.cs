using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.AutoMapperExtensions;
using ExpensesApp.Shared.Constants;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route(Paths.Api.OperationTypes)]
    public class OperationTypesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OperationTypesController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetOperationTypes() {
            IReadOnlyCollection<OperationType> operationTypes = await unitOfWork.OperationTypes.GetAllAsync();

            ICollection<OperationTypeDto> operationTypeDtos = mapper.MapAll<OperationTypeDto>(operationTypes);

            return Ok(operationTypeDtos);
        }
    }
}
