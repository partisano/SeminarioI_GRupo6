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
    public class Pago
    {

        public int Idpago { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }

        [Required]
        public string Observacion { get; set; }

        [Required]
        public int Idmatricula { get; set; }

        [Required]
        public int Idtramite { get; set; }

        public int Idalumno { get; set; }

        public int Alumno { get; set; }

        public string  CTramite { get; set; }

        public string CAlumno { get; set; }

        public List<Pago> ShowallPago { get; set; }


        public List<Pago> AllPagos { get; set; }
    }
}