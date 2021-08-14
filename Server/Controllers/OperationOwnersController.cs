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
    [Route(Paths.Api.OperationOwners)]
    public class OperationOwnersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public OperationOwnersController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetOperationOwners() {
            var owners = await unitOfWork.OperationOwners.GetAllAsync();
            var ownersDtos = mapper.MapAll<OperationOwnerDto>(owners);
            
            return Ok(ownersDtos);
        }
    }
}
