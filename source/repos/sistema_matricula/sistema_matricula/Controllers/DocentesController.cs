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
    public class DocentesController : Controller
    {

       

        private Docente docentes = new Docente();

        [HttpGet]
        public ActionResult Listado()
        {
            Docente objCiclo = new Docente();
            DataAccessDocentes objDB = new DataAccessDocentes();
            objCiclo.ShowallDocente = objDB.GetAllDocente();
            return View(objCiclo);
        }



        //[HttpGet]
        public ActionResult Agregardocente()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Agregardocente(Docente Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessDocentes objDB = new DataAccessDocentes();

                    if (objDB.AgregarDocente(Emp))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Registro agregado con exito!";
                    }
                }

                return View();

            }
            catch
            {
                return View();

            }
        }

        [HttpPost]
        public ActionResult Editardocente(Docente al)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessDocentes objDB = new DataAccessDocentes();
                    if (objDB.EditarDocente(al))
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
        public ActionResult EditarDocente(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessDocentes objDB = new DataAccessDocentes();
                Docente objdocente = new Docente();
                return View(objDB.ObtenerDocente(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteDocente(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessDocentes objDB = new DataAccessDocentes();
                if (objDB.DeleteDocente(cod) == true)
                {

                    return RedirectToAction("Listado");
                }
                else
                {
                    return RedirectToAction("Listado");
                }
            }



        }




    }
}