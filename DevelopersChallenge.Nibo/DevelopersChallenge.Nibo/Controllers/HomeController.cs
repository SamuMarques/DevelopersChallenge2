using DevelopersChallenge.Nibo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevelopersChallenge.Nibo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] IExternalTransactionRepository transactionRepository)
        {
            return View(transactionRepository.List(DateTime.MinValue, DateTime.MinValue, null));
        }
    }
}
