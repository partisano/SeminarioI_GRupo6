using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace sistema_matricula.Models
{

    public class ManCiclo
    {
        private SqlConnection con;
        public List<Ciclo> ListarCiclos()
        {
            List<Ciclo> ciclos = new List<Ciclo>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("select * from ciclo", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read()) {
                Ciclo pro = new Ciclo
                {
                    codigo = int.Parse(registros["Idciclo"].ToString())
                };
                ciclos.Add(pro); 
            }
            con.Close();
            return ciclos;
         }


    }


}