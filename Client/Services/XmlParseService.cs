using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExpensesApp.Shared.Models.DTOs;

namespace ExpensesApp.Client.Services
{
    public class XmlParseService : IXmlParseService
    {
        public async Task<IReadOnlyCollection<OperationDto>> ParseOperationDtosFromStreamAsync(Stream stream) {
            using var reader = new StreamReader(stream);
            string xmlString = await reader.ReadToEndAsync();

            XDocument xml = XDocument.Parse(xmlString);

            List<OperationDto> operations =
                xml.Element("account-history")
                   .Element("operations")
                   .Elements("operation")
                   .Select(
                       element => new OperationDto {
                           OperationDate = DateTime.Parse(element.Element("exec-date").Value),
                           TransactionDate = DateTime.Parse(element.Element("order-date").Value),
                           TransactionType = element.Element("type").Value,
                           Amount = decimal.Parse(
                               element.Element("amount").Value.Replace("+", ""), NumberFormatInfo.InvariantInfo),
                           Currency = element.Element("amount").Attribute("curr").Value,
                           AfterOperationBalance = decimal.Parse(
                               element.Element("ending-balance").Value.Replace("+", ""), NumberFormatInfo.InvariantInfo),
                           Description = element.Element("description").Value
                       }
                   )
                   .ToList();

            return operations;
        }
    }
}
