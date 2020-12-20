using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using sistema_matricula.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using sistema_matricula.Models.DataAcces;

namespace sistema_matricula.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] ==null)
            {
                return RedirectToAction("Index", "Login");

            }

            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "GRUPO DE TRABAJO";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de Contacto";

            return View();
        }
    }
}