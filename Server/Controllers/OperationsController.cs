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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public OperationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOperations()
        {
            var operations = await _unitOfWork.Operations.GetAllAsync();
            if (operations == null)
                return NoContent();
            
            var operationDtos = _mapper.MapAll<OperationDto>(operations);
            
            return Ok(operationDtos);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOperation(int id) {
            var operation = await _unitOfWork.Operations.GetAsync(id);
            if (operation == null)
                return NotFound();
            
            var operationDto = _mapper.Map<OperationDto>(operation);
            return Ok(operationDto);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<OperationDto> operationDtos)
        {
            var operations = _mapper.MapAll<Operation>(operationDtos);
            await _unitOfWork.Operations.AddRangeAsync(operations);
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
        
        
        [HttpPut]
        public async Task<IActionResult> PutOperation([FromBody] OperationDto operationDto) {
            var operation = await _unitOfWork.Operations.GetAsync(operationDto.IdOperation);
            if (operation == null)
                return NotFound();
            
            operation.SetProperties(operationDto);
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
    }
}
