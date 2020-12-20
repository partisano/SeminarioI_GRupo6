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
    public class Tramite
    {

        public int Idtramite { get; set; }

        [Required]
        public string Tramites { get; set; }
        [Required]
        public decimal Costo { get; set; }


        public List<Tramite> ShowallTramite { get; set; }

    }
}