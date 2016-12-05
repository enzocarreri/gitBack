using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult ListarCidade()
        {
            
            
            CidadeDAO dao = new CidadeDAO();

            List<ModCidade> cidade = dao.ListarCidade();

            

            return PartialView(cidade);
        }
    }
}