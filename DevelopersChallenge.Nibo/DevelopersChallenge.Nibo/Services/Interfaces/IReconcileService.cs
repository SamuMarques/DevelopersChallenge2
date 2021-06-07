using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopersChallenge.Nibo.Services.Interfaces
{
    public interface IReconcileService
    {
        void Reconcile(int externalTransaction, int selectedRow);
    }
}
