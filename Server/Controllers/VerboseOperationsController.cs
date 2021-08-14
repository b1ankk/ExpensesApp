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
    [Route(Paths.Api.VerboseOperations)]
    public class VerboseOperationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VerboseOperationsController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetVerboseOperations() {
            IReadOnlyCollection<Operation> operations = await unitOfWork.Operations.GetOperationsWithTypeAndOwner();
            if (operations == null)
                return NoContent();

            ICollection<VerboseOperationDto> operationDtos = mapper.MapAll<VerboseOperationDto>(operations);

            return Ok(operationDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVerboseOperation(int id) {
            Operation operation = await unitOfWork.Operations.GetOperationWithTypeAndOwner(id);
            if (operation == null)
                return NotFound();

            var verboseOperationDto = mapper.Map<VerboseOperationDto>(operation);
            return Ok(verboseOperationDto);
        }
    }
}
