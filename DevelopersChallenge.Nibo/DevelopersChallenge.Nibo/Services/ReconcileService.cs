using DevelopersChallenge.Nibo.Repositories.Interfaces;
using DevelopersChallenge.Nibo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Services
{
    public class ReconcileService : IReconcileService
    {
        public IExternalTransactionRepository _externalTransactionRepository;
        public IInternalTransactionRepository _internalTransactionRepository;
        public ReconcileService(IExternalTransactionRepository externalTransactionRepository, IInternalTransactionRepository internalTransactionRepository)
        {
            _externalTransactionRepository = externalTransactionRepository;
            _internalTransactionRepository = internalTransactionRepository;
        }
        public void Reconcile(int externalTransactionId, int internalTransactionId)
        {
            try
            {
                var externalTransaction = _externalTransactionRepository.GetById(externalTransactionId);
                var internalTransaction = _internalTransactionRepository.GetById(internalTransactionId);
                externalTransaction.InternalTransactionDescription = internalTransaction.Description;
                externalTransaction.InternalTransactionId = internalTransaction.Id;

                _externalTransactionRepository.Update(externalTransaction);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
