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
    public class CarrerasController : Controller
    {
  

        [HttpGet]
        public ActionResult Listado()
        {
            Carreras objCarrera = new Carreras();
            DataAccessCarreras objDBCa = new DataAccessCarreras();
            objCarrera.ShowallCarreras = objDBCa.GetAllCarreras();
            return View(objCarrera);
        }


        //[HttpGet]
        public ActionResult AgregarCarreras()
        {

  
            return View();
        }

   
        [HttpPost]
        public ActionResult AgregarCarreras(Carreras Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessCarreras objDB = new DataAccessCarreras();
                    if (objDB.AgregarCarreras(Emp))
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
        public ActionResult EditarCarreras(Carreras Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessCarreras objDB = new DataAccessCarreras();
                    if (objDB.EditarCarreras(Emp))
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
        public ActionResult EditarCarreras(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessCarreras objDB = new DataAccessCarreras();
                return View(objDB.ObtenerCarreras(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteCarreras(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessCarreras objDB = new DataAccessCarreras();

                if (objDB.DeleteCarreras(cod) == true)
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
            Carreras std = new Carreras()
            {
                Idcarrera = 1,
                Nombrecarrera = "hola"
            };
            //Facultad objCarre = new Facultad();
            DataAccessFacultad objDB = new DataAccessFacultad();
            var lis = objDB.LisFacultad();

            var json = JsonConvert.SerializeObject(lis);
            return Json(json, JsonRequestBehavior.AllowGet);


        }


        public JsonResult List()
        {
            
            DataAccessCarreras objDB = new DataAccessCarreras();
            return Json(objDB.LisFacultad(), JsonRequestBehavior.AllowGet);
        }



    }
}