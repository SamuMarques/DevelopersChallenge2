using System;
using AutoMapper;
using DevelopersChallenge.Nibo.Domain;
using DevelopersChallenge.Nibo.Models;
using DevelopersChallenge.Nibo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersChallenge.Nibo.Controllers
{
    public class InternalTransactionController : Controller
    {
        public ActionResult Index([FromServices] IInternalTransactionRepository internalTransactionRepository, InternalTransactionViewModel filter)
        {
            filter.Transactions.AddRange(internalTransactionRepository.List(filter.StartDate, filter.FinalDate, filter.Type));
            return View(filter);
        }

        [HttpGet]
        [Route("CreateInternalTransaction")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateInternalTransaction")]
        public ActionResult Create([FromServices] IInternalTransactionRepository internalTransactionRepository, InternalTransactionCrudViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                internalTransactionRepository.Create(Mapper.Map<InternalTransaction>(model));
                TempData["message"] = @"Movimenta\u00e7\u00e3o salva com sucesso.";
            }
            catch (Exception)
            {
                TempData["error_message"] = @"Erro ao tentar salvar movimenta\u00e7\u00e3o.";
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("DeleteInternalTransaction")]
        public ActionResult Delete([FromServices] IInternalTransactionRepository internalTransactionRepository, InternalTransactionCrudViewModel model)
        {
            try
            {
                internalTransactionRepository.Delete(Mapper.Map<InternalTransaction>(model));
                TempData["message"] = @"Movimenta\u00e7\u00e3o exclu\u00edda com sucesso.";
            }
            catch (Exception)
            {
                TempData["error_message"] = @"Erro ao tentar excluir a movimenta\u00e7\u00e3o.";
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("EditInternalTransaction/{id}")]
        public ActionResult Edit([FromServices] IInternalTransactionRepository internalTransactionRepository, int id)
        {
            return View(Mapper.Map<InternalTransactionCrudViewModel>(internalTransactionRepository.GetById(id)));
        }

        [HttpPost]
        [Route("EditInternalTransaction")]
        public ActionResult Update([FromServices] IInternalTransactionRepository internalTransactionRepository, InternalTransactionCrudViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                internalTransactionRepository.Update(Mapper.Map<InternalTransaction>(model));
                TempData["message"] = @"Movimenta\u00e7\u00e3o atualizada com sucesso.";
            }
            catch (Exception)
            {
                TempData["error_message"] = @"Erro ao tentar atualizada a movimenta\u00e7\u00e3o.";
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
