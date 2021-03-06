﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmDica.Web.Domain;
using EmDica.Web.Models;
using System.Text;

namespace EmDica.Web.Controllers
{
    public class QuestionarioController : BaseController
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

                return RedirectToAction("Create", "Cliente");
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
                        return RedirectToAction("Create", "Cliente");
                }
                else
                    return RedirectToAction("Create", "Cliente");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", "Cliente");
            }
        }

        public ActionResult RelacionamentoCliente(string email)
        {
            AvaliacaoHipoteseModel model = new AvaliacaoHipoteseModel();
            model.Email = email;
            return View(model);
        }

        [HttpPost]
        public ActionResult RelacionamentoCliente(AvaliacaoHipoteseModel avaliacao)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    StringBuilder texto = new StringBuilder();
                    texto.Append(string.Format("E-mail: {0}. ", avaliacao.Email));
                    texto.Append(string.Format("Tipo Pessoa: {0}. ", avaliacao.TipoPessoa));
                    texto.Append(string.Format("Problemas: {0}. ", avaliacao.ProblemasOcorridos));
                    texto.Append(string.Format("Tratativa: {0}. ", avaliacao.TratativaProblemasOcorridos));
                    texto.Append(string.Format("Melhoria: {0}.", avaliacao.PropostaMelhoria));
                    loggerAplicacao.Info(texto.ToString());

                    ViewBag.MensagemSucesso = "Obrigado pela sua resposta!";                    
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
