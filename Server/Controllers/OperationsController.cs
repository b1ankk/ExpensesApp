using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Server.Services;
using ExpensesApp.Shared.Models.DTOs;
using ExpensesApp.Shared.Models.Factories;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route("/api/operations")]
    public class OperationsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public OperationsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOperations()
        {
            var operations = await _dbService.GetOperationsAsync();
            var operationDtos = operations.Select(OperationDtoFactory.CreateFromOperation);
            
            return Ok(operationDtos);
        }

        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<OperationDto> operationDtos)
        {
            var operations = operationDtos.Select(OperationFactory.CreateFromOperationDto);
            await _dbService.AddOperations(operations);
            return Ok();
        }
        
    }
}