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
    public class Facultad
    {
        public int Idfacultad { get; set; }

        [Required]
        public string Nomfacultad { get; set; }

        public List<Facultad> ShowallFacultad { get; set; }

        public List<Facultad> allFacultad { get; set; }

    }



}