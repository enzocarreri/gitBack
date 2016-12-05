using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto1.Models
{
    public class ModCidade
    {
        public int id { get; set; }

        public string nome { get; set; }

        public ModEstado estado { get; set; }

        public ModCidade()
        {
            estado = new ModEstado();
        }
    }
}