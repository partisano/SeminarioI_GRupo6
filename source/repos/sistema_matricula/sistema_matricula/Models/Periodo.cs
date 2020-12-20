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
    public class Periodo
    {
        public int Idperiodo { get; set; }

        [Required]
        public string Nomperiodo { get; set; }


        [Required]
        public string Finicio { get; set; }


        [Required]
        public string Ffin { get; set; }

        public List<Periodo> ShowallPeriodo { get; set; }

    }



}