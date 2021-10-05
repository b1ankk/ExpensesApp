using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.AutoMapperExtensions;
using ExpensesApp.Shared.Constants;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;
using ExpensesApp.Shared.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route(Paths.Api.Operations)]
    public class OperationsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OperationsController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperations() {
            IReadOnlyCollection<Operation> operations = await unitOfWork.Operations.GetAllAsync();
            if (operations == null)
                return NoContent();

            ICollection<OperationDto> operationDtos = mapper.MapAll<OperationDto>(operations);

            return Ok(operationDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOperation(int id) {
            Operation operation = await unitOfWork.Operations.GetAsync(id);
            if (operation == null)
                return NotFound();

            var operationDto = mapper.Map<OperationDto>(operation);
            return Ok(operationDto);
        }


        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<OperationDto> operationDtos) {
            ICollection<Operation> operations = mapper.MapAll<Operation>(operationDtos);
            await unitOfWork.Operations.AddRangeAsync(operations);
            await unitOfWork.CompleteAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> PutOperation([FromBody] OperationDto operationDto) {
            Operation operation = await unitOfWork.Operations.GetAsync(operationDto.IdOperation);
            if (operation == null)
                return NotFound();

            operation.SetProperties(operationDto);
            await unitOfWork.CompleteAsync();

            return Ok();
        }


        [HttpDelete("{idOperation:int}")]
        public async Task<IActionResult> DeleteOperation([FromRoute] int idOperation) {
            Operation operation = await unitOfWork.Operations.GetAsync(idOperation);

            if (operation == null)
                return NotFound();

            unitOfWork.Operations.Remove(operation);
            await unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
