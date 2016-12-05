using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModItensPedidos
    {
        public int codigoItens { get; set; }

        public int qtd { get; set; }

        public decimal valorUni { get; set; }

        public ModPedido pedido { get; set; }

        public ModProduto produto { get; set; }

        public ModOfereceProduto oferece { get; set; }

        public int contagemVenda { get; set; }

        public ModItensPedidos()
        {
            pedido = new ModPedido();
            produto = new ModProduto();
            oferece = new ModOfereceProduto();
        }
    }
}