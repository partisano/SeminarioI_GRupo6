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
    public class Carreras
    {
        public int Idcarrera { get; set; }

        [Required]
        public string Nombrecarrera { get; set; }

        [Required]
        public int Nummeses { get; set; }

        [Required]
        public int Idfacultad { get; set; }

        public string Nomfacultad { get; set; }


        public List<Carreras> ShowallCarreras { get; set; }

        public List<Carreras> Llenar { get; set; }


    }



}