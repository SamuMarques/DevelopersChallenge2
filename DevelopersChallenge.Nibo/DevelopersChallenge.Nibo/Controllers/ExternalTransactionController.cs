using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Models;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersChallenge.Nibo.Controllers
{
    public class ExternalTransactionController : Controller
    {
        public ActionResult Index([FromServices] IExternalTransactionRepository transactionRepository, ExternalTransactionViewModel filter)
        {
            filter.Transactions.AddRange(transactionRepository.List(filter.StartDate, filter.FinalDate, filter.Type));
            return View(filter);
        }

        [HttpPost]
        public ActionResult Delete([FromServices] IExternalTransactionRepository transactionRepository, ExternalTransaction model)
        {
            try
            {
                transactionRepository.Delete(model);
                TempData["message"] = @"Exclu\u00eddo com sucesso";
            }
            catch (Exception)
            {
                TempData["error_message"] = @"Erro ao tentar excluir a transa\u00e7\u00e3o.";
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
