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
    public class Usuarios
    {

        public int Idusuario { get; set; }

        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public string Tipo { get; set; }

        public List<Usuarios> ShowallUsuario { get; set; }

        public List<Usuarios> TipoCollection { get; set; }

        public List<Ciclo> CicloCollection { get; set; }



    }
}