using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sistema_matricula.Models;

namespace sistema_matricula.Models.DataAcces
{
    public class DataAccessCiclo
    {

        public List<Ciclo> GetCiclos()
        {
            int Id = 1; ;
            List<Ciclo> ciclos = new List<Ciclo>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmdc = new SqlCommand("ListadoCiclo", con);
            cmdc.CommandType = CommandType.StoredProcedure;
            cmdc.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmdc.ExecuteReader();
            while (registros.Read())
            {
                Ciclo art = new Ciclo
                {
                    Idciclo = int.Parse(registros["Idciclo"].ToString()),
                    Nomciclo = registros["NomCiclo"].ToString()
                };
                ciclos.Add(art);
            }
            con.Close();
            return ciclos;
        }

        public List<Ciclo> GetAllCiclos()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Ciclo> CicloList = new List<Ciclo>();
            SqlCommand com = new SqlCommand("AllCiclo", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            CicloList = (from DataRow dr in dt.Rows
                         select new Ciclo()
                         {
                             Idciclo = Convert.ToInt32(dr["Idciclo"]),
                             Nomciclo = Convert.ToString(dr["Nomciclo"])
                         }).ToList();
            return CicloList;
        }

        //To Add Ciclo
        public bool AgregarCiclos(Ciclo obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddCiclo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nomciclo", obj.Nomciclo);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To Edit Ciclo
        public bool EditarCiclos(Ciclo obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditCiclo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idciclo);
            com.Parameters.AddWithValue("@Nomciclo", obj.Nomciclo);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public Ciclo ObtenerCiclos(int cod)
        {

            Ciclo ciclos = new Ciclo();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getCiclo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                ciclos.Idciclo = int.Parse(registros["Idciclo"].ToString());
                ciclos.Nomciclo = registros["NomCiclo"].ToString();
            }
            con.Close();
            return ciclos;
        }

        public bool DeleteCiclos(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarCiclo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", Cod);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}