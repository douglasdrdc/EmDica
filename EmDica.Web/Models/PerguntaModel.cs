using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmDica.Web.Models
{
    public class PerguntaModel
    {
        public int PerguntaId { get; set; }
        public string Enunciado { get; set; }
        public List<AlternativaModel> Alternativas { get; set; }
        public int AlternativaCorreta { get; set; }
        public int AlternativaSelecionada { get; set; }
    }
}