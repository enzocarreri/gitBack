using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class SugestaoController : Controller
    {
        // GET: Sugestao
        // GET: Sugestao
        public ActionResult Sugestao()
        {
            return View();
        }
        public ActionResult SugestaoFinalizada()
        {
            string nome = Request.QueryString["nome"];
            string email = Request.QueryString["email"];
            string sugestao = Request.QueryString["sugestao"];

            SugestaoDAO dao = new SugestaoDAO();
            string resposta = dao.Sugestao(nome, email, sugestao);



            ViewBag.bb = resposta;
            return View();
        }
    }
}