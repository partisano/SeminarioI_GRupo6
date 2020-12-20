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
    public class PagoController : Controller
    {
        public object HttpContextAccessor { get; private set; }

        [HttpGet]
        public ActionResult Listado()
        {
            Pago objPa = new Pago();
            DataAccessPago objDB = new DataAccessPago();
            objPa.ShowallPago = objDB.GetAllPago();
            return View(objPa);
        }

        [HttpGet]
        public ActionResult ListadoP()
        {

                Pago objPag = new Pago();
                DataAccessPago objDBpa = new DataAccessPago();
                objPag.AllPagos = objDBpa.GetAllPago();
                
            
            return View(objPag);
        }

        [HttpGet]
        public ActionResult Agregarpago()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AgregarPagoAlumno()
        {
            return View();
        }

        public JsonResult ListTramite()
        {
            DataAccessTramite objDB = new DataAccessTramite();
            return Json(objDB.GetAllTramite(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarPago(Pago Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessPago objDB = new DataAccessPago();
                    if (objDB.AgregarPago(Emp))
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
        public ActionResult AgregarPagoAlumno(Pago Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataAccessPago objDB = new DataAccessPago();
                    DataAccessMatricula objDBA = new DataAccessMatricula();

                    var Id = (int)Session["Iduser"];

                    var codigoalumno = objDBA.ObtenerAlumno(Id);


                    Emp.Idalumno = codigoalumno;

                    if (objDB.AgregarPagoAumno(Emp))
                    {
                         ViewBag.Message = "Registrar Agregado con exito!";
                    }
                    else
                    {
                        ViewBag.Message = "Error al registrar pago!";
                    }                 
                }
                return View();
            } catch{
                return View();
            }
        }



        public JsonResult ListAlumno()
        {
            DataAccessAlumno objDB = new DataAccessAlumno();
            return Json(objDB.GetAllAlumno(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            Pago objPa = new Pago();
            DataAccessPago objDB = new DataAccessPago();
            objPa.ShowallPago = objDB.GetAllPago();
            return View(objPa);
        }

        [HttpGet]
        public ActionResult DeletePago(int cod)
        {
            if (cod == 0)
            {
                return RedirectToAction("Listado");
            }
            else
            {
                DataAccessPago objDB = new DataAccessPago();
                if (objDB.DeletePago(cod) == true){
                    return RedirectToAction("Listado");
                }else{
                    return RedirectToAction("Listado");
                }
            }
        }





    }
}