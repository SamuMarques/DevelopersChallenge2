using DevelopersChallenge.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Repositories.Interfaces
{
    public interface IExternalTransactionRepository
    {
        void Create(List<ExternalTransaction> transactions);
        List<ExternalTransaction> List(DateTime startDate, DateTime finalDate, string type);
        void Delete(ExternalTransaction internalTransaction);
        ExternalTransaction GetById(int id);
        void Update(ExternalTransaction externalTransaction);
    }
}
