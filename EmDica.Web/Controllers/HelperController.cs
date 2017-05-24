using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmDica.Web.Controllers
{
    public class HelperController : Controller
    {
        public ActionResult Leads()
        {
            List<string> logLines = new List<string>();
            string pathFile = string.Format(@"C:\{0}-Server.log", DateTime.Now.ToString("yyyy-MM-dd"));
            if (!System.IO.File.Exists(pathFile))
            {
                ViewBag.LogLines = new List<string>();
                return View();
            }

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    string line = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        logLines.Add(line);
                    }
                }

                ViewBag.LogLines = logLines;
            }
            catch (Exception ex)
            {                
                throw new Exception("Ocorreu um erro na leitura do arquivo de log.", ex);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Leads(FormCollection formPesquisa)
        {
            try
            {
                DateTime dataGeracao = DateTime.Now;
                if (formPesquisa["DataGeracao"] != null)
                {
                    if (!DateTime.TryParse(formPesquisa["DataGeracao"], out dataGeracao))
                    {
                        ViewBag.MensagemValidacao = "A Data de Geração informada é inválida.";
                        return View();
                    }
                }

                List<string> logLines = new List<string>();
                //string pathFile = string.Format(@"C:\{0}-Server.log", dataGeracao.ToString("yyyy-MM-dd")); //Local
                string pathFile = string.Format(@"D:\home\site\wwwroot\LogFiles\{0}-Server.log", dataGeracao.ToString("yyyy-MM-dd"));

                if (!System.IO.File.Exists(pathFile))
                {
                    ViewBag.MensagemValidacao = "Não foi encontrado arquivo para a Data de Geração informada.";
                    return View();
                }

                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(pathFile))
                    {
                        string line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            logLines.Add(line);
                        }
                    }

                    if (logLines.Count > 0)
                        ViewBag.LogLines = logLines;
                    else
                        ViewBag.MensagemValidacao = "O arquivo encontrado não possui informações.";

                    return View();
                }
                catch (Exception ex)
                {                    
                    throw new Exception("Erro na leitura do arquivo de log.", ex);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }



    }
}