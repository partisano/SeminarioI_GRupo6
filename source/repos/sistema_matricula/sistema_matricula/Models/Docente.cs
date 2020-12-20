using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_matricula.Models
{
    public class Docente
    {

        public int Iddocente { get; set; }

        public string Apellidos { get; set; }


        public string Nombres { get; set; }


        public int DNI { get; set; }

        public string Direccion { get; set; }
        public int Celular { get; set; }


        public string Usuario { get; set; }

        public string Clave { get; set; }


        public List<Docente> ShowallDocente { get; set; }

    }
}