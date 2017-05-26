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
        
        public ActionResult Create(int tipoRedirecionamento = 0)
        {
            if (tipoRedirecionamento != 0)
            {
                TempData["tipoRedirecionamento"] = tipoRedirecionamento;
                ViewBag.Redirecionamento = true;
            }

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


                    if (TempData["ResultadoAvaliacao"] != null)
                    {
                        QuestionarioModel questionario = (QuestionarioModel)TempData["ResultadoAvaliacao"];
                        TempData["ResultadoAvaliacao"] = questionario;
                        return RedirectToAction("AvaliationResult", "Questionario");
                    }
                    if (TempData["tipoRedirecionamento"] != null)
                    {
                        int tipoRedirecionamento = (int)TempData["tipoRedirecionamento"];
                        switch (tipoRedirecionamento)
                        {
                            case 1:
                                return RedirectToAction("RelacionamentoCliente", "Questionario", new { email = cliente.Email });
                        }
                    }
                    return View(cliente);
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
