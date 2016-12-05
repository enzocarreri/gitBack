using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult CadastroFinalizado()
        {
            string nome = Request.QueryString["nome"];
            string email = Request.QueryString["email"];
            string senha = Request.QueryString["senha"];
            string endereco = Request.QueryString["endereco"];
            string numero = Request.QueryString["numero"];
            string telefone = Request.QueryString["telefone"];


            CadastroDAO dao = new CadastroDAO();

            string resposta = dao.Cadastrar(nome, email, endereco, numero, telefone, senha);



            ViewBag.bb = resposta;
            return View();
        }
    }
}