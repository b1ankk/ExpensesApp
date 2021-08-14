using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Client.Services
{
    public class CsvParseService : ICsvParseService
    {
        public async Task<IEnumerable<OperationDto>> ParseOperationDtosFromStreamAsync(Stream fs) {
            var operations = new List<OperationDto>();
            using var reader = new StreamReader(fs);

            await reader.ReadLineAsync(); // skip headers

            string line;
            while ((line = await reader.ReadLineAsync()) != null) {
                string[] parts = line.Split("\",\"");
                parts = parts.Select(p => p.Trim().Replace("\"", "")).ToArray();

                var operation = new OperationDto {
                    OperationDate = DateTime.Parse(parts[0]),
                    TransactionDate = DateTime.Parse(parts[1]),
                    TransactionType = parts[2],
                    Amount = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                    Currency = parts[4],
                    AfterOperationBalance = decimal.Parse(parts[5], CultureInfo.InvariantCulture),
                    Description = string.Join('\n', parts[6..11])
                };
                operations.Add(operation);
            }

            return operations;
        }
    }
}
