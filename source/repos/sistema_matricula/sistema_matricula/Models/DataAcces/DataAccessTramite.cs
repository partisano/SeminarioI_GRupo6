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
    public class DataAccessTramite
    {

        public List<Tramite> GetTramites()
        {
            int Id = 1; ;
            List<Tramite> Tramites = new List<Tramite>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarTramite", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Tramite art = new Tramite
                {
                    Idtramite = int.Parse(registros["Idtramite"].ToString()),
                    Tramites = registros["Tramite"].ToString(),
                    Costo = decimal.Parse(registros["Costo"].ToString()),
                };
                Tramites.Add(art);
            }
            con.Close();
            return Tramites;
        }

        public List<Tramite> GetAllTramite()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Tramite> TramiteList = new List<Tramite>();
            SqlCommand com = new SqlCommand("AllTramite", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            TramiteList = (from DataRow dr in dt.Rows
                         select new Tramite()
                         {
                             Idtramite = Convert.ToInt32(dr["Idtramite"]),
                             Tramites = Convert.ToString(dr["Tramites"]),
                             Costo = Convert.ToDecimal(dr["Costo"]),
                         }).ToList();
            return TramiteList;
        }

 
        public bool AgregarTramite(Tramite obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddTramite", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Tramites", obj.Tramites);
            com.Parameters.AddWithValue("@Costo", obj.Costo);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }else{
                return false;
            }
        }

        public bool EditarTramite(Tramite obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditTramite", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idtramite);
            com.Parameters.AddWithValue("@Tramites", obj.Tramites);
            com.Parameters.AddWithValue("@Costo", obj.Costo);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            } else {
                return false;
            }

        }


        public Tramite ObtenerTramite(int cod)
        {

            Tramite Tramites = new Tramite();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getTramite", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Tramites.Idtramite = int.Parse(registros["Idtramite"].ToString());
                Tramites.Tramites = registros["Tramites"].ToString();
                Tramites.Costo = decimal.Parse(registros["Costo"].ToString());
            }
            con.Close();
            return Tramites;
        }

        public bool DeleteTramite(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarTramite", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", Cod);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            } else{
                return false;
            }
        }



    }
}