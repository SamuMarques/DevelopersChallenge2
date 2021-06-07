using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevelopersChallenge.Nibo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevelopersChallenge.Nibo.Controllers
{
    public class OFXFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromServices] IOFXFileService OFXFileService, List<IFormFile> files)
        {
            if (files.Any(x => Path.GetExtension(x.FileName).ToLower() != ".ofx"))
            {
                TempData["error_message"] = @"Arquivo n\u00e3o suportado.";
                return RedirectToAction("Index", "OFXFile");
            }
            try
            {
                await OFXFileService.ProcessFile(files);
                TempData["message"] = "Arquivo importado com sucesso.";
                return RedirectToAction("Index", "ExternalTransaction");
            }
            catch (Exception)
            {
                TempData["error_message"] = "Erro ao tentar importar o arquivo.";
                return RedirectToAction("Index", "OFXFile");
            }
        }
    }
}
