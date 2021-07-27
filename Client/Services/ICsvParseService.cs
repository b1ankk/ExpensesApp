using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ExpensesApp.Shared.Models;

namespace ExpensesApp.Client.Services
{
    public interface ICsvParseService
    {
        public Task<IEnumerable<Operation>> ParseOperationsFromStreamAsync(Stream stream);
    }
}