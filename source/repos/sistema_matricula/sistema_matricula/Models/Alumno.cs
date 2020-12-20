using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;
using System.ComponentModel.DataAnnotations;
namespace sistema_matricula.Models
{
    public class Alumno
    {
        public int Idalumno { get; set; }

        [Required] 
        public string Apellidos { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public int DNI { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public int Telefono { get; set; }

       
        public string Usuario { get; set; }

      
        public string Clave { get; set; }



        public List<Alumno> ShowallAlumno{ get; set; }

    }
}