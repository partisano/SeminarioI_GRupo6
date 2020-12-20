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
    public class Matricula
    {

        public int Idmatricula { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int Idalumno { get; set; }

        [Required]
        public int Idasignatura { get; set; }

        [Required]
        public int Idperiodo { get; set; }

        public string Periodo { get; set; }

        public int Estado { get; set; }

        public string Alumno { get; set; }

        public string Asignatura { get; set; }

        public string Periodos { get; set; }

        public string Estados { get; set; }

        public List<Matricula> ShowallMatricula { get; set; }

        public List<Matricula> ShowallIns { get; set; }



        public int id { get; set; }
        public string value { get; set; }

    }
}