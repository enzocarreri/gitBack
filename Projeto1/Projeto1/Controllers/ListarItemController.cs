﻿using Projeto1.Models;
using Projeto1.Models.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto1.Controllers
{
    public class ListarItemController : Controller
    {
        // GET: ListarItem
        public ActionResult ListarItem()
        {
            
            //if(1==1)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            string email = Request.QueryString["email"];
            string senha = Request.QueryString["senha"];
            string codigoEmpresa = Request.QueryString["item"];
            ViewBag.Nome = codigoEmpresa;

            
            ItensDAO dao = new ItensDAO();

            List<ModCliente> cliente = dao.LoginCliente(email,senha);
            ViewBag.CodigoCliente = cliente;
            if (cliente.Count == 0)
            {
                return RedirectToAction("FalhaLogar1", "Login");
            }
            return View(cliente);

        }

        public ActionResult ListarPrincipal(string codigoEmpresa)
        {
            
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarPrincipal(codigoEmpresa);



            return PartialView(empresa);


        }

        public ActionResult ListarMistura(string codigoEmpresa)
        {
            ModOfereceProduto oferece = new ModOfereceProduto();
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarMistura(codigoEmpresa);



            return PartialView(empresa);

        }

        public ActionResult ListarGuarnicao(string codigoEmpresa)
        {
            
            ModOfereceProduto oferece = new ModOfereceProduto();
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarGuarnicao(codigoEmpresa);



            return PartialView(empresa);

        }
        public ActionResult ListarBebida(string codigoEmpresa)
        {
            ViewBag.Nome = codigoEmpresa;
            ModOfereceProduto oferece = new ModOfereceProduto();
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarBebida(codigoEmpresa);



            return PartialView(empresa);

        }
        public ActionResult ListarSobremesa(string codigoEmpresa)
        {
            ViewBag.Nome = codigoEmpresa;
            ModOfereceProduto oferece = new ModOfereceProduto();
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarSobremesa(codigoEmpresa);



            return PartialView(empresa);

        }
        public ActionResult ListarPrato(string codigoEmpresa)
        {
            ViewBag.Nome = codigoEmpresa;
            ModOfereceProduto oferece = new ModOfereceProduto();
            ItensDAO dao = new ItensDAO();

            List<ModOfereceProduto> empresa = dao.ListarPrato(codigoEmpresa);



            return PartialView(empresa);

        }


    }
}