using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.Constants;
using ExpensesApp.Shared.Models.DTOs;
using ExpensesApp.Shared.Models.UtilityModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApp.Server.Controllers
{
    [ApiController]
    [Route(Paths.Api.AccountingPeriods)]
    public class AccountingPeriodController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        
        public AccountingPeriodController(IUnitOfWork unitOfWork, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet("{idPeriod:int}/summary")]
        public async Task<IActionResult> GetAccountingPeriodSummary([FromRoute] int idPeriod) {
            AccountingSummary summary = await unitOfWork.AccountPeriods.GetSummaryForPeriodAsync(idPeriod);
            if (summary == null)
                return NotFound();
            
            var summaryDto = mapper.Map<AccountingSummaryDto>(summary);

            return Ok(summaryDto);
        } 
    }
}
