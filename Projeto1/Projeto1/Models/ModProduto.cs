using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModProduto
    {
        public int codigoProduto { get; set; }

        public string nomeProduto { get; set; }

        public ModTipoProduto tipoProduto { get; set; }

        public ModProduto()
        {
            tipoProduto = new ModTipoProduto();
        }
    }
}