using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Models;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using DevelopersChallenge.Nibo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersChallenge.Nibo.Controllers
{
    public class ReconcileController : Controller
    {
        public IActionResult Index([FromServices] IInternalTransactionRepository internalTransactionRepository, ExternalTransaction externalTransaction)
        {
            return View(new ReconcileViewModel
            {
                ExternalTransaction = externalTransaction,
                InternalTransactions = internalTransactionRepository.List(externalTransaction.Date, externalTransaction.Date, externalTransaction.Type)
            });
        }

        [HttpPost]
        public ActionResult Update([FromServices] IReconcileService reconcileService, int externalTransaction, int selectedRow)
        {
            if (externalTransaction == 0 || selectedRow == 0)
            {
                TempData["error_message"] = @"Erro ao conciliar, tente novamente.";
                return BadRequest("Erro ao conciliar, tente novamente.");
            }
            try
            {
                reconcileService.Reconcile(externalTransaction, selectedRow);
                TempData["message"] = @"Concilia\u00e7\u00e3o executada com sucesso.";
                return Ok();
            }
            catch (Exception)
            {
                TempData["error_message"] = "Erro ao conciliar, tente novamente.";
                return BadRequest("Erro ao conciliar, tente novamente.");
            }
        }
    }
}
