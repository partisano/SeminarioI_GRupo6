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
    
    public class CicloController : Controller
    {
        // GET: Ciclo
        //private Ciclo ciclos = new Ciclo();

        [HttpGet]
        public ActionResult Listado()
        {
            Ciclo objCiclo = new Ciclo();
            DataAccessCiclo objDB = new DataAccessCiclo();
            objCiclo.ShowallCiclo = objDB.GetAllCiclos();
            return View(objCiclo);
        }

        //[HttpGet]
        public ActionResult Agregarciclo()
        {
            return View();
        }


        // POST: Ciclo/Add    
        [HttpPost]
        public ActionResult Agregarciclo(Ciclo Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    DataAccessCiclo objDB = new DataAccessCiclo();

                    if (objDB.AgregarCiclos(Emp))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Ciclo Agregado con exito!";
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
        public ActionResult EditarCiclo(Ciclo Emp)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    
                    DataAccessCiclo objDB = new DataAccessCiclo();

                    if (objDB.EditarCiclos(Emp))
                    {
                        ViewBag.Message = "Ciclo Editado con exito!";
                    }
               }

                return View();
                } catch {
               return View();

            }
        }


        [HttpGet]
        public ActionResult EditarCiclo(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessCiclo objDB = new DataAccessCiclo();
                //Ciclo objciclo = new Ciclo();
                return View(objDB.ObtenerCiclos(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteCiclo(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                            DataAccessCiclo objDB = new DataAccessCiclo();
                            //Ciclo objciclo = new Ciclo();
                            if (objDB.DeleteCiclos(cod)==true){

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