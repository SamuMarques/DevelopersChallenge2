using DevelopersChallenge.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Repositories.Interfaces
{
    public interface IInternalTransactionRepository
    {
        List<InternalTransaction> List(DateTime startDate, DateTime finalDate, string type);
        void Create(InternalTransaction internalTransaction);
        void Delete(InternalTransaction internalTransaction);
        InternalTransaction GetById(int id);
        void Update(InternalTransaction internalTransaction);
    }
}
