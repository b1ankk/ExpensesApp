using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExpensesApp.Server.Data.UnitOfWork;
using ExpensesApp.Shared.AutoMapperExtensions;
using ExpensesApp.Shared.Constants;
using ExpensesApp.Shared.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetAccountingPeriods() {
            IReadOnlyCollection<AccountingPeriod> periods = await unitOfWork.AccountPeriods.GetAllAsync();
            
            ICollection<AccountingPeriodDto> periodDtos = mapper.MapAll<AccountingPeriodDto>(periods);
            return Ok(periodDtos);
        }
        
        
        [HttpGet("{idPeriod:int}/summary")]
        public async Task<IActionResult> GetAccountingPeriodSummary([FromRoute] int idPeriod) {
            AccountingSummary summary = await unitOfWork.AccountPeriods.GetSummaryForPeriodAsync(idPeriod);
            if (summary == null)
                return NotFound();
            
            var summaryDto = mapper.Map<AccountingSummaryDto>(summary);

            return Ok(summaryDto);
        }


        [HttpPost]
        public async Task<IActionResult> PostAccountingPeriod([FromBody] AccountingPeriodDto periodDto) {
            if (periodDto == null)
                return BadRequest();

            var period = mapper.Map<AccountingPeriod>(periodDto);
            await unitOfWork.AccountPeriods.AddAsync(period);
            await unitOfWork.CompleteAsync();

            return Ok();
        }
        
    }
}
