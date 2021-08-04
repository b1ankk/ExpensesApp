using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.IMapperExtensions;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route("/api/operations")]
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
            if (operations.IsNullOrEmpty())
                return NotFound();
            
            var operationDtos = _mapper.MapAll<OperationDto>(operations);
            
            return Ok(operationDtos);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<OperationDto> operationDtos)
        {
            var operations = _mapper.MapAll<Operation>(operationDtos);
            await _unitOfWork.Operations.AddRangeAsync(operations);
            await _unitOfWork.CompleteAsync();
            
            return Ok();
        }
        
    }
}
