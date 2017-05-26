using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmDica.Web.Models
{
    public class AvaliacaoHipoteseModel
    {
        public string Email { get; set; }

        [DisplayName("Você é empreendedor, gestor ou vendedor?")]        
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.MultilineText)]
        public string TipoPessoa { get; set; }

        [DisplayName("Você já teve algum problema com a gestão dos clientes? Explique")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.MultilineText)]
        public string ProblemasOcorridos { get; set; }

        [DisplayName("Como você lidou ou está lidando com isso?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.MultilineText)]
        public string TratativaProblemasOcorridos { get; set; }

        [DisplayName("Qual seria a solução ideal para resolver isso?")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.MultilineText)]
        public string PropostaMelhoria { get; set; }
    }
}