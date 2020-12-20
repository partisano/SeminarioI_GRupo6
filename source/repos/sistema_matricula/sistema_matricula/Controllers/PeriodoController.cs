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
    
    public class PeriodoController : Controller
    {
    

        [HttpGet]
        public ActionResult Listado()
        {
            Periodo objPeriodo = new Periodo();
            DataAccessPeriodo objDB = new DataAccessPeriodo();
            objPeriodo.ShowallPeriodo = objDB.GetAllPeriodos();
            return View(objPeriodo);
        }


        public ActionResult AgregarPeriodo()
        {
            return View();
        }
 
        [HttpPost]
        public ActionResult AgregarPeriodo(Periodo Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessPeriodo objDB = new DataAccessPeriodo();
                    if (objDB.AgregarPeriodos(Emp))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Periodo Agregado con exito!";
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
        public ActionResult EditarPeriodo(Periodo Emp)
        {
           try
            {
                if (ModelState.IsValid)
                {

                    DataAccessPeriodo objDB = new DataAccessPeriodo();

                    if (objDB.EditarPeriodos(Emp))
                    {
                        ViewBag.Message = "Periodo Editado con exito!";
                    }
               }

                return View();
                } catch {
               return View();

            }
        }


        [HttpGet]
        public ActionResult EditarPeriodo(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            } else {
                DataAccessPeriodo objDB = new DataAccessPeriodo();
                return View(objDB.ObtenerPeriodos(cod));
            }

        }

        [HttpGet]
        public ActionResult DeletePeriodo(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessPeriodo objDB = new DataAccessPeriodo();
                if (objDB.DeletePeriodos(cod)==true){
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