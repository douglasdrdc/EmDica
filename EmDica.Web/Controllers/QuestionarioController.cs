using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmDica.Web.Domain;
using EmDica.Web.Models;

namespace EmDica.Web.Controllers
{
    public class QuestionarioController : Controller
    {
                
        public ActionResult Create(int tipoQuestionario = 1)
        {
            QuestionarioModel questionario = QuestionarioDomain.ObtemQuestionario((TipoQuestionarioModel)tipoQuestionario);
            return View(questionario);
        }
                
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (collection["tipoQuest"] == null)
                {
                    ViewBag.MensagemValidacao = "Favor preencher todas as questões do formulário.";
                    return View();
                }                

                int tipoQuestionario = Convert.ToInt32(collection["tipoQuest"]);
                QuestionarioModel questionario = QuestionarioDomain.ObtemQuestionario((TipoQuestionarioModel)tipoQuestionario);

                foreach (var pergunta in questionario.Perguntas)
                {
                    if (collection[string.Format("pergunta{0}", pergunta.PerguntaId.ToString())] == null)
                    {
                        ViewBag.MensagemValidacao = "Favor preencher todas as questões do formulário.";
                        return View(questionario);
                    }

                    string alternativaSelecionada = collection[string.Format("pergunta{0}", pergunta.PerguntaId.ToString())];
                    alternativaSelecionada = alternativaSelecionada.Replace("{ id = ", "").Replace("}", "").Trim();
                    pergunta.AlternativaSelecionada = Convert.ToInt32(alternativaSelecionada);
                }

                questionario.ResultadoAvaliacao = QuestionarioDomain.AvaliarQuestionario(questionario);

                TempData["ResultadoAvaliacao"] = questionario;

                return RedirectToAction("AvaliationResult");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult AvaliationResult()
        {
            try
            {
                if (TempData["ResultadoAvaliacao"] != null)
                {
                    QuestionarioModel questionario = (QuestionarioModel)TempData["ResultadoAvaliacao"];
                    if (questionario != null)
                        return View(questionario);
                    else
                        return RedirectToAction("Create", new { tipoQuestionario = 1 });
                }
                else
                    return RedirectToAction("Create", new { tipoQuestionario = 1 });                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", new { tipoQuestionario = 1 });
            }
        }


    }
}
