using System.Collections.Generic;
using System.Threading.Tasks;
using ExpensesApp.Server.Services;
using ExpensesApp.Shared.Models;
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
            return Ok(operations);
        }

        [HttpPost]
        public async Task<IActionResult> PostOperations([FromBody] IEnumerable<Operation> operations)
        {
            await _dbService.AddOperations(operations);
            return Ok();
        }
        
    }
}