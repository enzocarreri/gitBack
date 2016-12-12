using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult CarregarStatus(String codigoPedido,string loginP, string senhaP)
        {
            ViewBag.loginP = loginP;
            ViewBag.senhaP = senhaP;
            StatusDAO dao = new StatusDAO();

            List<ModPedido> ped = dao.ListarPedidoItemEmpresa(codigoPedido);
            ViewBag.codigoPedido = codigoPedido;
            return PartialView(ped);
        }
        public ActionResult AlterarStatus(string codigoPedido, string status)
        {
            ViewBag.lala1 = status;
            ViewBag.lala2 = codigoPedido;
            StatusDAO dao = new StatusDAO();

            string ped = dao.NovoStatus(status,codigoPedido);
            ViewBag.lala3 = ped;
            
            return View();
        }
    }
}