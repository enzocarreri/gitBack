using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModOfereceProduto
    {
        public int codigoOferece { get; set; }

        public double? valor { get; set; }

        public double? valorTotal { get; set; }

        public ModEmpresa empresa { get; set; }

        public ModProduto produto { get; set; }

        public int dia { get; set; }

        public int oferece { get; set; }

        public ModOfereceProduto()
        {
            empresa = new ModEmpresa();
            produto = new ModProduto();

        }
              
    }
}