using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmDica.Web.Models
{
    public class Cliente
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }        
        
    }
}