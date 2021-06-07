using DevelopersChallenge.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Models
{
    public class ExternalTransactionViewModel
    {
        public ExternalTransactionViewModel()
        {
            Transactions = new List<ExternalTransaction>();
        }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Type { get; set; }
        public List<ExternalTransaction> Transactions { get; set; }



        public ExternalTransaction Transaction { get; set; }
    }
}
