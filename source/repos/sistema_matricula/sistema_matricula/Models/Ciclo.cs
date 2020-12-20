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
    public class Ciclo
    {
        public int Idciclo { get; set; }

        [Required]
        public string Nomciclo { get; set; }

        public List<Ciclo> ShowallCiclo { get; set; }

    }



}