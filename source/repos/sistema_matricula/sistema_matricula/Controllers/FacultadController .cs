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
    
    public class FacultadController : Controller
    {
        // GET: Facultad
        //private Facultad facultad = new Facultad();

        [HttpGet]
        public ActionResult Listado()
        {
            Facultad objFacultad = new Facultad();
            DataAccessFacultad objDBF = new DataAccessFacultad();
            objFacultad.ShowallFacultad = objDBF.GetAllFacultad();
            return View(objFacultad);
        }

        //[HttpGet]
        public ActionResult Agregarfacultad()
        {
            return View();
        }


        // POST: Facultad/Add    
        [HttpPost]
        public ActionResult Agregarfacultad(Facultad Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    DataAccessFacultad objDBf = new DataAccessFacultad();

                    if (objDBf.AgregarFacultad(Emp))
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
        public ActionResult EditarFacultad(Facultad Emp)
        {
           try
            {
                if (ModelState.IsValid)
                {

                    DataAccessFacultad objDBf = new DataAccessFacultad();

                    if (objDBf.EditarFacultad(Emp))
                    {
                        ViewBag.Message = "Registro Editado con exito!";
                    }
               }

                return View();
                } catch {
               return View();

            }
        }


        [HttpGet]
        public ActionResult EditarFacultad(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessFacultad objDB = new DataAccessFacultad();
                //Facultad objfacultad = new Facultad();
                return View(objDB.ObtenerFacultad(cod));
            }

        }

        [HttpGet]
        public ActionResult DeleteFacultad(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessFacultad objDB = new DataAccessFacultad();
                //Facultad objciclo = new Facultad();
                            if (objDB.DeleteFacultad(cod)==true){

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