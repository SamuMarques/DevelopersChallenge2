using DevelopersChallenge.Nibo.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace DevelopersChallenge.Nibo.Models
{
    public class InternalTransactionViewModel
    {
        public InternalTransactionViewModel()
        {
            Transactions = new List<InternalTransaction>();
        }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string Type { get; set; }
        public List<InternalTransaction> Transactions { get; set; }

        

        public InternalTransaction Transaction { get; set; }
    }
}
