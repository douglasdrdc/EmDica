using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmDica.Web.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Campo e-mail informado não é valido")]
        [Required(ErrorMessage = "Campo E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome é obrigatório")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo Empresa é obrigatório")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Campo Cargo é obrigatório")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Cargo { get; set; }


    }
}