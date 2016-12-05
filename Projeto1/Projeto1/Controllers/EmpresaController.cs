using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult ListarEmpresa()
        {
            string nomeCidade = Request.QueryString["cidade"];

            
            EmpresaDAO dao = new EmpresaDAO();

            List<ModEmpresa> empresa = dao.ListarRestaurante(nomeCidade);

            

            return View(empresa);
        }

        public ActionResult ListarEmpresaNome()
        {
            string nomeEmpresa = Request.QueryString["empresa"];


            EmpresaDAO dao = new EmpresaDAO();

            List<ModEmpresa> empresa = dao.ListarEmpresaNome(nomeEmpresa);

            ViewBag.nome = nomeEmpresa;

            return View(empresa);
        }
    }
}