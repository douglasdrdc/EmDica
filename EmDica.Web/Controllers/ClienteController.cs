using EmDica.Web.Helpers;
using EmDica.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace EmDica.Web.Controllers
{
    public class ClienteController : BaseController
    {
        
        public ActionResult Create()
        {
            QuestionarioModel questionario = (QuestionarioModel)TempData["ResultadoAvaliacao"];
            TempData["ResultadoAvaliacao"] = questionario;

            return View();
        }
                
        [HttpPost]
        public ActionResult Create(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    QuestionarioModel questionario = (QuestionarioModel)TempData["ResultadoAvaliacao"];

                    string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                    
                    string dadosCliente = string.Format("{0},{1} {2},{3},{4},{5}   {6},{7}",
                            cliente.Email.Trim(),
                            cliente.Nome.Trim(),
                            cliente.Sobrenome.Trim(),
                            ip,
                            "B2C",
                            Util.ConverteDataHorarioBrasilia(DateTime.Now),
                            cliente.Empresa,
                            cliente.Cargo
                        );
                    
                    loggerAplicacao.Info(dadosCliente);

                    TempData["ResultadoAvaliacao"] = questionario;

                    return RedirectToAction("AvaliationResult", "Questionario");
                }
                else
                    return View(cliente);
            }
            catch
            {
                return View();
            }
        }
        
    }
}
