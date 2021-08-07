using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.AutoMapperExtensions;
using ExpensesApp.Shared.Constants;
using ExpensesApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route(Paths.Api.VerboseOperations)]
    public class VerboseOperationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public VerboseOperationsController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetVerboseOperations() {
            var operations = await _unitOfWork.Operations.GetOperationsWithTypeAndOwner();
            if (operations == null)
                return NoContent();
            
            var operationDtos = _mapper.MapAll<VerboseOperationDto>(operations);
            
            return Ok(operationDtos);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVerboseOperation(int id) {
            var operation = await _unitOfWork.Operations.GetOperationWithTypeAndOwner(id);
            if (operation == null)
                return NotFound();
            
            var verboseOperationDto = _mapper.Map<VerboseOperationDto>(operation);
            return Ok(verboseOperationDto);
        }
    }
}
