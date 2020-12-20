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
using System.Web.Security;

namespace sistema_matricula.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login us)
        {
            if (ModelState.IsValid)
            {
                DataAccessLogin db = new DataAccessLogin();
                var obj = db.Acceso(us);             
                
               if (obj.Idusuario != 0)
                {
                    ViewBag.Message = "USTED SE HA LOGUEADO";

                    //ViewBag.Message = obj.Idusuario;
                    Session["Iduser"] = obj.Idusuario;
                    Session["TipoUser"] = obj.Tipo.ToString();
                    Session["UserName"] = obj.Usuario.ToString();
                
                    return RedirectToAction("index", "Home");

                }
                else
                {
                    ViewBag.Message = "Acceso INCORRECTO";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }






    }
}