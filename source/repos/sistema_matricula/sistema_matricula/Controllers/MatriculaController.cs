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
    public class MatriculaController : Controller
    {

        [HttpGet]
        public ActionResult Listado()
        {
            if (Session["UserName"] != null)
            {
                Matricula objMatricula = new Matricula();
                DataAccessMatricula objDB = new DataAccessMatricula();
                objMatricula.ShowallMatricula = objDB.GetAllMatricula();
                return View(objMatricula);             

            }
            else
            {
                        return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public ActionResult Listar()
        {
            Matricula objMatricula = new Matricula();
            DataAccessMatricula objDB = new DataAccessMatricula();
            objMatricula.ShowallMatricula = objDB.GetAllMatricula();
            return View(objMatricula);
        }



        [HttpGet]
        public ActionResult Mimatricula()
        {
            var Id = (int)Session["Iduser"];
            Matricula objMatricula = new Matricula();
            DataAccessMatricula objDB = new DataAccessMatricula();
            var cd = objDB.ObtenerAlumno(Id);
            objMatricula.ShowallIns = objDB.MisCursos(cd);
            return View(objMatricula);
        }

        [HttpGet]
        public ActionResult CursosAsignados()
        {
            var Id = (int)Session["Iduser"];
            Matricula objMatricula = new Matricula();
            DataAccessMatricula objDB = new DataAccessMatricula();
            var cd = objDB.ObtenerDocente(Id);
            objMatricula.ShowallIns = objDB.MisAlumnos(cd);
            return View(objMatricula);
        }

        //[HttpGet]
        public ActionResult AgregarMatricula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMatricula(Matricula Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessMatricula objDB = new DataAccessMatricula();

                    if (objDB.AgregarMa(Emp))
                    {
                        ModelState.Clear();

                      ViewBag.Message = "Matricula Agregado con exito!";
                    }
                }
                return View();
            }catch{
                return View();

            }
        }


         [HttpGet]
         public ActionResult DeleteMatricula(int cod){
            if (cod == 0){
                return RedirectToAction("Listado");
            } else {
                DataAccessMatricula objDB = new DataAccessMatricula();
                if (objDB.DeleteMatricula(cod) == true) {
                    return RedirectToAction("Listado");
                }else{
                    return RedirectToAction("Listado");
                }
            }
        }

        [HttpGet]
        public ActionResult Aprobar(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                DataAccessMatricula objDB = new DataAccessMatricula();
                if (objDB.Aprobar(cod) == true)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return RedirectToAction("Listar");
                }
            }
        }

        [HttpGet]
        public ActionResult Desaprobar(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                DataAccessMatricula objDB = new DataAccessMatricula();
                if (objDB.Desaprobar(cod) == true)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    return RedirectToAction("Listar");
                }
            }
        }

        [HttpGet]
        public ActionResult Matriculame(int cod)
        {

            if (cod == 0)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                DataAccessMatricula objDB = new DataAccessMatricula();
                    DateTime fecha = DateTime.Now;

                    var Id = (int)Session["Iduser"];
                    var codigoalumno = objDB.ObtenerAlumno(Id);

                var c = objDB.Inscribirme(fecha, codigoalumno, cod, 2);
                    if (c == true)
                    { 
                       ViewBag.Message = "Matricula Agregado con exito!";
                       return RedirectToAction("Listar");
                }
                    else
                    {
                        ViewBag.Message = "Error al matricularme";
                        return RedirectToAction("Listar");
                }
                }
          
            
        }


        public JsonResult ListAlumno()
        {

            DataAccessAlumno objDB = new DataAccessAlumno();
            return Json(objDB.GetAllAlumno(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAsignatura()
        {

            DataAccessAsignatura objDB = new DataAccessAsignatura();
            return Json(objDB.GetAllAsignatura(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Buscar( string a)
        {

            DataAccessMatricula objDB = new DataAccessMatricula();
            return Json(objDB.Buscar(a), JsonRequestBehavior.AllowGet);
        }
















    }
}