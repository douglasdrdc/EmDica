using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmDica.Web.Models;

namespace EmDica.Web.Domain
{
    public class AlternativaDomain
    {
        public static List<AlternativaModel> ObtemAlternativas(int perguntaId)
        {
            List<AlternativaModel> alternativas = new List<AlternativaModel>();
            switch (perguntaId)
            {
                case 1:
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 1,
                        Descricao = "Identificar os recursos que tenho disponíveis e qual produto ou serviço poderia entregar."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 2,
                        Descricao = "Identificar qual é a necessidade do meu consumidor."
                    });
                    break;
                case 2:
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 1,
                        Descricao = "Com conteúdo institucional sobre o meu produto."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 2,
                        Descricao = "Mix de conteúdos genéricos e conteúdos institucionais do meu produto."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 3,
                        Descricao = "Não tenho uma estratégia de marketing de conteúdo."
                    });
                    break;
                case 3:
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 1,
                        Descricao = "Interajo com meus leads utilizando as áreas de negócios responsáveis."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 2,
                        Descricao = "Utilizo softwares de CRM para integrar todos os pontos de contato com o meu lead."
                    });
                    break;
                case 4:
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 1,
                        Descricao = "O time de vendas não possui visibilidade do trabalho de marketing."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 2,
                        Descricao = "O time de vendas conhece o percurso de cada lead antes de converter em um lead qualificado."
                    });
                    break;
                case 5:
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 1,
                        Descricao = "Enviar e-mails com uma determinada recorrência para os meus prospects ou clientes."
                    });
                    alternativas.Add(new AlternativaModel()
                    {
                        AlternativaId = 2,
                        Descricao = "Construir um régua de conteúdo de acordo com o perfil de cada prospect ou cliente utilizando ações online e/ou off-line para nutrir a régua."
                    });
                    break;
            }

            return alternativas;
        }

        public static AlternativaModel ObtemAlternativa(int perguntaId, int alternativaId)
        {
            return ObtemAlternativas(perguntaId).Where(x => x.AlternativaId == alternativaId).FirstOrDefault();
        }

    }
}