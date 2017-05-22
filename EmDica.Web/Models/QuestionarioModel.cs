using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmDica.Web.Models
{
    public class QuestionarioModel
    {
        public int QuestionarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPreenchimento { get; set; }
        public List<PerguntaModel> Perguntas { get; set; }
        public TipoQuestionarioModel TipoQuestionario { get; set; }
        public string ResultadoAvaliacao { get; set; }

    }
}