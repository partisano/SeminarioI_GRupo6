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
    public class Asignatura
    {

        public int Idasignatura { get; set; }

        [Required]
        public string Asignaturas { get; set; }

        [Required]
        public int Idcarrera { get; set; }

        [Required]
        public int Idciclo { get; set; }

        [Required]
        public int Iddocente { get; set; }

        [Required]
        public int Idperiodo { get; set; }

        [Required]
        public int Creditos { get; set; }

        public string Docente { get; set; }
        public string Carrera { get; set; }
        public string Ciclo { get; set; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        public int Numvacante { get; set; }




        public List<Asignatura> ShowallAsignatura { get; set; }
        public List<Asignatura> MisAsignaturas { get; set; }
    }
}