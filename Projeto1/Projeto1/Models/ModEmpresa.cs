using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModEmpresa
    {
        public int codigoEmpresa { get; set; }

        public string nomeEmpresa { get; set; }

        public string nomeApresentacao { get; set; }

        public string cnpj { get; set; }

        public string endereco { get; set; }

        public string login { get; set; }

        public string senha { get; set; }

        public string telefone1 { get; set; }

        public int ativada { get; set; }

        public ModCidade cidade { get; set; }

        public ModEmpresa()
        {
            cidade = new ModCidade();
        }
    }
}