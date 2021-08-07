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
    [Route(Paths.Api.OperationTypes)]
    public class OperationTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public OperationTypesController(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetOperationTypes() {
            var operationTypes = await _unitOfWork.OperationTypes.GetAllAsync();
            
            var operationTypeDtos = _mapper.MapAll<OperationTypeDto>(operationTypes);
            
            return Ok(operationTypeDtos);
        }
        
    }
}
