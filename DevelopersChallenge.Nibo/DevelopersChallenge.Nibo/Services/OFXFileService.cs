using AutoMapper;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using DevelopersChallenge.Nibo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Services
{
    public class OFXFileService : IOFXFileService
    {
        public IExternalTransactionRepository _transactionRepository;
        public OFXFileService(IExternalTransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task ProcessFile(List<IFormFile> files)
        {
            foreach (var formFile in files)
            {
                var lines = await ReadAsStringAsync(formFile);
                var archive = Util.Deserialize(lines);

                _transactionRepository.Create(Mapper.Map<List<ExternalTransaction>>(archive.Transactions));
            }
        }
        

        public async Task<string> ReadAsStringAsync(IFormFile file)
        {
            string[] parentNodes = new string[] { "<BANKTRANLIST>", "</BANKTRANLIST>", "<STMTTRN>", "</STMTTRN>" };
            string[] childNodes = new string[] { "<DTSTART>", "<DTEND>", "<TRNTYPE>", "<DTPOSTED>", "<TRNAMT>", "<MEMO>" };
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var line = await reader.ReadLineAsync();
                    if (parentNodes.Any(x => line.Contains(x)))
                        result.AppendLine(line);
                    else if (childNodes.Any(x => line.Contains(x)))
                        result.AppendLine(line + line.Substring(0, line.LastIndexOf(">") + 1).Replace("<", "</"));
                }
            }
            return result.ToString();
        }
    }
}
