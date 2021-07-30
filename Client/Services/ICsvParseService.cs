using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Client.Services
{
    public interface ICsvParseService
    {
        public Task<IEnumerable<OperationDto>> ParseOperationDtosFromStreamAsync(Stream stream);
    }
}