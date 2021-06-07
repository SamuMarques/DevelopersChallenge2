using DevelopersChallenge.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Models
{
    public class ReconcileViewModel
    {
        public ExternalTransaction ExternalTransaction { get; set; }
        public List<InternalTransaction> InternalTransactions { get; set; }
        public int SelectedRow { get; set; }
    }
}
