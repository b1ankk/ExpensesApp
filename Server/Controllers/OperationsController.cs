using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Services;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route("/api/operations")]
    public class OperationsController : ControllerBase
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;
        
        public OperationsController(IDbService dbService, IMapper mapper)
        {
            _dbService = dbService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperations()
        {
            var operations = await _dbService.GetOperationsAsync();
            var operationDtos = operations.Select(_mapper.Map<OperationDto>);
            
            return Ok(operationDtos);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<OperationDto> operationDtos)
        {
            var operations = operationDtos.Select(_mapper.Map<Operation>);
            await _dbService.AddOperations(operations);
            
            return Ok();
        }
        
    }
}