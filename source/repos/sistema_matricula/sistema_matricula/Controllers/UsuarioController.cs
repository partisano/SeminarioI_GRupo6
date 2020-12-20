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
    public class UsuarioController : Controller
    {
        private Usuarios usuario = new Usuarios();

        [HttpGet]
        public ActionResult Listado()
        {
            Usuarios objUsuario = new Usuarios();
            DataAccessUsuarios objDB = new DataAccessUsuarios();
            objUsuario.ShowallUsuario = objDB.GetAllUsuario();
            return View(objUsuario);
        }

 
        //[HttpGet]
        public ActionResult AgregarUsuario()
        {


            return View();
        }


     
        [HttpPost]
        public ActionResult AgregarUsuario(Usuarios us)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessUsuarios objDB = new DataAccessUsuarios();
                    if (objDB.AgregarUsuario(us))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Registro agregado con exito!";
                    }
                }
                return View();
            } catch {
                return View();

            }
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuarios al)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessUsuarios objDB = new DataAccessUsuarios();

                    if (objDB.EditarUsuario(al))
                    {
                        ViewBag.Message = "Registro Editado con exito!";
                    }
                }

                return View();
            }
            catch
            {
                return View();

            }
        }


        [HttpGet]
        public ActionResult EditarUsuario(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessUsuarios objDBU = new DataAccessUsuarios();
                return View(objDBU.ObtenerUsuario(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteUsuario(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessUsuarios objDB = new DataAccessUsuarios();
                //Usuarios  objusuario = new Usuarios ();
                if (objDB.DeleteUsuario(cod) == true)
                {
                    return RedirectToAction("Listado");
                }    else{
                    return RedirectToAction("Listado");
                }
            }



        }


    }
}