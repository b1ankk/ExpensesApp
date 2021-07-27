using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Shared.Models;

namespace ExpensesApp.Client.Services
{
    public class CsvParseService : ICsvParseService
    {
        public async Task<IEnumerable<Operation>> ParseOperationsFromStreamAsync(Stream fs) {
            var operations = new List<Operation>();
            using var reader = new StreamReader(fs);
            
            await reader.ReadLineAsync(); // skip headers
            
            string line;
            while ((line = await reader.ReadLineAsync()) != null) {
                var parts = line.Split("\",\"");
                parts = parts.Select(p => p.Trim().Replace("\"", "")).ToArray();
                
                var operation = new Operation {
                    OperationDate = DateTime.Parse(parts[0]),
                    TransactionDate = DateTime.Parse(parts[1]),
                    TransactionType = parts[2],
                    Amount = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                    Currency = parts[4],
                    AfterOperationBalance = decimal.Parse(parts[5], CultureInfo.InvariantCulture),
                    Description = parts[6] + '\n' + parts[7] + '\n' + parts[8] + '\n' + parts[9] + '\n' + parts[10]
                };
                operations.Add(operation);
            }
            
            return operations;
        }
    }
}