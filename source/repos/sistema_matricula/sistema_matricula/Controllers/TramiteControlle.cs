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
    
    public class TramiteController : Controller
    {
 
        [HttpGet]
        public ActionResult Listado()
        {
            Tramite objTramite= new Tramite();
            DataAccessTramite objDB = new DataAccessTramite();
            objTramite.ShowallTramite= objDB.GetAllTramite();
            return View(objTramite);
        }

        [HttpGet]
        public ActionResult AgregarTramite()
        {
            return View();
        }

        // POST: Tramite/Add    
        [HttpPost]
        public ActionResult AgregarTramite(Tramite Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessTramite objDB = new DataAccessTramite();

                    if (objDB.AgregarTramite(Emp))
                    {
                        ModelState.Clear();
                        ViewBag.Message = "Tramite Agregado con exito!";
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
        public ActionResult EditarTramite(Tramite Emp)
        {
           try
            {
                if (ModelState.IsValid)
                {

                    DataAccessTramite objDB = new DataAccessTramite();

                    if (objDB.EditarTramite(Emp))
                    {
                        ViewBag.Message = "Tramite Editado con exito!";
                    }
               }

                return View();
                } catch {
               return View();

            }
        }


        [HttpGet]
        public ActionResult EditarTramite(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessTramite objDB = new DataAccessTramite();
                //Tramite objciclo = new Tramite();
                return View(objDB.ObtenerTramite(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteTramite(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessTramite objDB = new DataAccessTramite();
                            
                            if (objDB.DeleteTramite(cod)==true){

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