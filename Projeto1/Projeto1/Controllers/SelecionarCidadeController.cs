using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class SelecionarCidadeController : Controller
    {
        // GET: SelecionarCidade
        public ActionResult SelecionarCidade()
        {
            return PartialView();
        }
    }
}