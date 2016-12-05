using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModCliente
    {
        public int codigoCliente { get; set; }

        public string nomeCliente { get; set; }



        public string endereco { get; set; }

        public string numero { get; set; }

        public string email { get; set; }

        public string telefone1 { get; set; }

        public string telefone2 { get; set; }

        public string login { get; set; }

        public string senha { get; set; } 

        public ModCidade cidade { get; set; }

        public ModCliente()
        {
            cidade = new ModCidade();
        }
    }
}
