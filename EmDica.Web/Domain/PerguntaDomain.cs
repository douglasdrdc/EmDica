using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmDica.Web.Models;

namespace EmDica.Web.Domain
{
    public class PerguntaDomain
    {
        public static List<PerguntaModel> ObtemPerguntas(int questionarioId)
        {
            List<PerguntaModel> perguntas = new List<PerguntaModel>();

            switch (questionarioId)
            {
                case 1:
                    perguntas.Add(new PerguntaModel()
                    {
                        PerguntaId = 1,
                        Enunciado = "Quando você decide criar um novo produto, qual é a sua primeira ação?",
                        Alternativas = AlternativaDomain.ObtemAlternativas(1),
                        AlternativaCorreta = 2
                    });
                    perguntas.Add(new PerguntaModel()
                    {
                        PerguntaId = 2,
                        Enunciado = "Você tem uma estratégia de marketing de conteúdo? Se sim, como ela é feita?",
                        Alternativas = AlternativaDomain.ObtemAlternativas(2),
                        AlternativaCorreta = 2
                    });
                    perguntas.Add(new PerguntaModel()
                    {
                        PerguntaId = 3,
                        Enunciado = "Como você controla os seus leads?",
                        Alternativas = AlternativaDomain.ObtemAlternativas(3),
                        AlternativaCorreta = 2
                    });
                    perguntas.Add(new PerguntaModel()
                    {
                        PerguntaId = 4,
                        Enunciado = "Como é o relacionamento entre as equipes de marketing e vendas do seu negócio?",
                        Alternativas = AlternativaDomain.ObtemAlternativas(4),
                        AlternativaCorreta = 2
                    });
                    perguntas.Add(new PerguntaModel()
                    {
                        PerguntaId = 5,
                        Enunciado = "Para você, uma base de e-mail marketing serve para:",
                        Alternativas = AlternativaDomain.ObtemAlternativas(5),
                        AlternativaCorreta = 2
                    });                    
                    break;
            }

            return perguntas;
        }

    }
}