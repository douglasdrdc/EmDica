using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmDica.Web.Models;

namespace EmDica.Web.Domain
{
    public class QuestionarioDomain
    {
        public static List<QuestionarioModel> ObtemQuestionarios()
        {
            List<QuestionarioModel> questionarios = new List<QuestionarioModel>();
            questionarios.Add(new QuestionarioModel()
            {
                QuestionarioId = 1,                
                TipoQuestionario = TipoQuestionarioModel.AvaliacaoMarketingAtualEmpresa,
                Nome = "De qual década é o seu marketing?",
                Descricao = @"Será que você aplica os conceitos de marketing moderno na sua empresa e de fato sabe usufruir dessa novidade? Faça este teste rápido e veja se você está na década de 90, 2000 ou 2020.",
                Perguntas = PerguntaDomain.ObtemPerguntas(1)
            });

            return questionarios;
        }

        public static QuestionarioModel ObtemQuestionario(TipoQuestionarioModel tipo)
        {
            return ObtemQuestionarios().Where(x => x.TipoQuestionario == tipo).FirstOrDefault();
        }

        public static string AvaliarQuestionario(QuestionarioModel questionario)
        {
            string resultadoAvaliacao = string.Empty;

            int acertos = 0;

            foreach (var pergunta in questionario.Perguntas)
            {
                if (pergunta.AlternativaCorreta == pergunta.AlternativaSelecionada)
                    acertos++;
            }

            if (acertos >= 3)
                resultadoAvaliacao = "Parabéns! Você entendeu o que é o marketing moderno e está levando esta transformação para a sua empresa. Provavelmente você já deve ter colhido diversos benefícios desta prática. Fique de olho no EmDica para atualizar os seus conhecimentos sobre marketing moderno.";
            else if (acertos == 2)
                resultadoAvaliacao = "Quase lá! A sua empresa já adota algumas práticas de marketing moderno, mas ainda possui pontos de melhoria! Acesse este e - book com dicas para o marketing moderno e fique de olho no blog EmDica para receber dicas de como modernizar o seu negócio.";
            else
                resultadoAvaliacao = "Onde a sua empresa esteve todo esse tempo? Você pode ter mantido os seus negócios à moda tradicional, mas fique esperto, pois o mercado muda com velocidade. Acesse este e-book com dicas para o marketing moderno e fique de olho no blog EmDica para receber dicas de como modernizar o seu negócio.";

            return resultadoAvaliacao;
        }
        
    }
}