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
using Newtonsoft.Json;

namespace sistema_matricula.Controllers
{
    public class AsignaturaController : Controller
    {
  

        [HttpGet]
        public ActionResult Listado()
        {
            Asignatura objAsignatura = new Asignatura();
            DataAccessAsignatura objDBCa = new DataAccessAsignatura();
            objAsignatura.ShowallAsignatura = objDBCa.GetAllAsignatura();
            return View(objAsignatura);
        }
        
        [HttpGet]
        public ActionResult Listar()
        {
            Asignatura objAsignatura = new Asignatura();
            DataAccessAsignatura objDBCa = new DataAccessAsignatura();
            objAsignatura.ShowallAsignatura = objDBCa.GetAllAsignatura();
            return View(objAsignatura);
        }


        [HttpGet]
        public ActionResult ListarAlumno()
        {
            Asignatura objAsignatura = new Asignatura();
            DataAccessAsignatura objDBCa = new DataAccessAsignatura();
            objAsignatura.ShowallAsignatura = objDBCa.GetAllAsignatura();
            return View(objAsignatura);
        }


        [HttpGet]
        public ActionResult MisAsignaturas()
        {
            var Id = (int)Session["Iduser"];
            Asignatura objMatricula = new Asignatura();
            DataAccessMatricula objDB = new DataAccessMatricula();
            DataAccessAsignatura objDBA = new DataAccessAsignatura();

            var cd = objDB.ObtenerDocente(Id);
            objMatricula.MisAsignaturas = objDBA.MisAsignaturas(cd);
            return View(objMatricula);
        }

        //[HttpGet]
        public ActionResult AgregarAsignatura()
        {
            return View();
        }
   
        [HttpPost]
        public ActionResult AgregarAsignatura(Asignatura Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessAsignatura objDB = new DataAccessAsignatura();
                    if (objDB.AgregarAsignatura(Emp))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Registrar Agregado con exito!";
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
        public ActionResult EditarAsignatura(Asignatura Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessAsignatura objDB = new DataAccessAsignatura();
                    if (objDB.Editar(Emp))
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
        public ActionResult EditarAsignatura(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessAsignatura objDB = new DataAccessAsignatura();
                return View(objDB.ObtenerAsignatura(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteAsignatura(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessAsignatura objDB = new DataAccessAsignatura();

                if (objDB.DeleteAsignatura(cod) == true)
                {

                    return RedirectToAction("Listado");
                }
                else
                {
                    return RedirectToAction("Listado");
                }
            }
        }


        public JsonResult GetCar()
        {
            DataAccessFacultad objDB = new DataAccessFacultad();
            var lis = objDB.LisFacultad();
            var json = JsonConvert.SerializeObject(lis);
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListAsignatura()
        {
            DataAccessAsignatura objDB = new DataAccessAsignatura();
            return Json(objDB.GetAllAsignatura(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListCarrera()
        {
            DataAccessCarreras objDB = new DataAccessCarreras();
            return Json(objDB.GetAllCarreras(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListPeriodo()
        {
            DataAccessPeriodo objDB = new DataAccessPeriodo();
            return Json(objDB.GetAllPeriodos(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ListCiclo()
        {
            DataAccessCiclo objDB = new DataAccessCiclo();
            return Json(objDB.GetAllCiclos(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListDocente()
        {
            DataAccessDocentes objDB = new DataAccessDocentes();
            return Json(objDB.GetAllDocente(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Matriculame(int cod)
        {

            if (cod == 0)
            {
                return RedirectToAction("ListarC");
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
                         return RedirectToAction("ListarC");
                  }else 
                { 
              
                        ViewBag.Message = "Error al matricularme";
                   
                     return RedirectToAction("ListarC");
                   }
                  //  return RedirectToAction("ListarC");
            }
          
            
        }



        [HttpGet]
        public ActionResult ListarC ()
        {
            var Id = (int)Session["Iduser"];
            Asignatura objMatricula = new Asignatura();
            DataAccessMatricula objDB = new DataAccessMatricula();
            DataAccessAsignatura objDBA = new DataAccessAsignatura();
            var cd = objDB.ObtenerAlumno(Id);
            objMatricula.MisAsignaturas = objDBA.ListarCursoAlumno(cd);
            return View(objMatricula);
        }


    }
}