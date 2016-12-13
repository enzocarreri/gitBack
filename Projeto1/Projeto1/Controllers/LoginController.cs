using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginEscolher()
        {
            return View();
        }
       
        public ActionResult LoginCliente()
        {
            return View();
        }
        public ActionResult AdmLogin()
        {
            string email = Request.QueryString["email"];
            string senha = Request.QueryString["senha"];
            string selecionado = Request.QueryString["item"];
            if(String.IsNullOrEmpty(selecionado))
            {
                return RedirectToAction("logadoCliente", "Login", new { loginP = email, senhaP = senha});
            }
            else
            {
                return RedirectToAction("logadoEmpresa", "Login", new { loginP = email, senhaP = senha});
            }
            return View();
        }
        public ActionResult LogadoCliente(string loginP,string senhaP)
        {
            
            LoginDAO dao = new LoginDAO();
            ViewBag.login = loginP;
            ViewBag.senha = senhaP;
            List<ModItensPedidos> ped = dao.ListarPedidosCliente(loginP, senhaP);
            if (ped.Count == 0)
            {
                return RedirectToAction("FalhaLogar1", "Login", new { loginP = loginP, senhaP = senhaP });
            }
            return View(ped);
        }

        public ActionResult LogadoEmpresa(string loginP, string senhaP)
        {
            
            LoginDAO dao = new LoginDAO();
            ViewBag.login = loginP;
            ViewBag.senha = senhaP;
            List<ModItensPedidos> ped = dao.ListarPedidosEmpresa(loginP,senhaP);
           
            
            if (ped.Count == 0)
            {
                return RedirectToAction("FalhaLogar1", "Login", new { loginP = loginP, senhaP = senhaP });
            }
            return View(ped);


        }
        public ActionResult FalhaLogar1(string loginP, string senhaP)
        {

            
            return View();


        }
        public ActionResult FalhaLogar2(string loginP, string senhaP)
        {

            
            return View();


        }
        public ActionResult ListarPedidoEmpresa(string codigoPedido)
        {
            
            LoginDAO dao = new LoginDAO();
            
            List<ModItensPedidos> ped = dao.ListarPedidoItemEmpresa(codigoPedido);
            ViewBag.lala = codigoPedido;
            return PartialView(ped);
        }
        public ActionResult DetalhesPedidoEmpresa(string codigoPedido)
        {
            
            LoginDAO dao = new LoginDAO();

            List<ModItensPedidos> pede = dao.ListarDetalhesPedidosEmpresa(codigoPedido);
            ViewBag.lala = codigoPedido;
            return PartialView(pede);
        }
        //public ActionResult CarregarStatus(String codigoPedido)
        //{
        //    StatusDAO dao = new StatusDAO();

        //    List<ModPedido> ped = dao.ListarPedidoItemEmpresa(codigoPedido);

        //    return PartialView(ped);
        //}
        //public ActionResult AlterarStatus()
        //{
        //    string status = Request.QueryString["status"];
        //    string codigoPedido = Request.QueryString["codigoPedido"];
        //    StatusDAO dao = new StatusDAO();

        //    string ped = dao.NovoStatus(status, codigoPedido);
        //    ViewBag.lala = ped;
        //    return View();
        //}


    }
}