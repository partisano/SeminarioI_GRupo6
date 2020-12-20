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
    public class AlumnoController : Controller
    {


        private Alumno alumnos = new Alumno();

        [HttpGet]
        public ActionResult Listado()
        {
            Alumno objCiclo = new Alumno();
            DataAccessAlumno objDB = new DataAccessAlumno();
            objCiclo.ShowallAlumno = objDB.GetAllAlumno();
            return View(objCiclo);
        }


        [HttpGet]
        public ActionResult Listar()
        {
            Alumno objCiclo = new Alumno();
            DataAccessAlumno objDB = new DataAccessAlumno();
            objCiclo.ShowallAlumno = objDB.GetAllAlumno();
            return View(objCiclo);
        }


        //[HttpGet]
        public ActionResult Agregaralumno()
        {
            return View();
        }


     
        [HttpPost]
        public ActionResult Agregaralumno(Alumno Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessAlumno objDB = new DataAccessAlumno();

                    if (objDB.AgregarAlumno(Emp))
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
        public ActionResult EditarAlumno(Alumno Alu)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessAlumno objDB = new DataAccessAlumno();
                    if (objDB.EditarAl(Alu))
                    {
                        ViewBag.Message = "Registro Editado con exito!";
                    }
                }
                return View();
            }catch
            {
                return View();

            }
        }

        [HttpGet]
        public ActionResult EditarAlumno(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessAlumno objDB = new DataAccessAlumno();
                Alumno objalumno = new Alumno();
                return View(objDB.ObtenerAlumno(cod));
            }

        }


        [HttpGet]
        public ActionResult DeleteAlumno(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessAlumno objDB = new DataAccessAlumno();
                //Alumno  objciclo = new Alumno ();
                if (objDB.DeleteAlumno(cod) == true)
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