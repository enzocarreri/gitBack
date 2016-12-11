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
        public ActionResult CarregarStatus(String codigoPedido)
        {
            StatusDAO dao = new StatusDAO();

            List<ModPedido> ped = dao.ListarPedidoItemEmpresa(codigoPedido);
            
            return PartialView(ped);
        }
        public ActionResult AlterarStatus()
        {
            string status = Request.QueryString["status"];
            string codigoPedido = Request.QueryString["codigoPedido"];
            StatusDAO dao = new StatusDAO();

            string ped = dao.NovoStatus(status,codigoPedido);
            ViewBag.lala = ped;
            return View();
        }
    }
}