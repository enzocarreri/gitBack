using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModPedido
    {
        public int codigoPedido { get; set; }

        public double? valor { get; set; }

        public int status { get; set; }

        public string enderecoEntrega { get; set; }

        public ModCliente cliente { get; set; }

        public ModEmpresa empresa { get; set; }

        public DateTime? dataVenda { get; set; }

        public ModPedido()
        {
            cliente = new ModCliente();
            empresa = new ModEmpresa();
        }
    }
}