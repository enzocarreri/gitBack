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
            string login = Request.QueryString["login"];
            string senha = Request.QueryString["senha"];
            string selecionado = Request.QueryString["item"];
            if(String.IsNullOrEmpty(selecionado))
            {
                return RedirectToAction("logadoCliente", "Login", new { loginP = login, senhaP = senha});
            }
            else
            {
                return RedirectToAction("logadoEmpresa", "Login", new { loginP = login, senhaP = senha});
            }
            return View();
        }
        public ActionResult LogadoCliente(string loginP,string senhaP)
        {
            //string login = Request.QueryString["login"];
            //string senha = Request.QueryString["senha"];
            LoginDAO dao = new LoginDAO();
            ViewBag.login = loginP;
            ViewBag.senha = senhaP;
            List<ModItensPedidos> ped = dao.ListarPedidosCliente(loginP, senhaP);
            return View(ped);
        }

        public ActionResult LogadoEmpresa(string loginP, string senhaP)
        {
            //string login = Request.QueryString["login"];
            //string senha = Request.QueryString["senha"];
            LoginDAO dao = new LoginDAO();
            ViewBag.login = loginP;
            ViewBag.senha = senhaP;
            List<ModItensPedidos> ped = dao.ListarPedidosEmpresa(loginP,senhaP);
           return View(ped);


        }
       
    }
}