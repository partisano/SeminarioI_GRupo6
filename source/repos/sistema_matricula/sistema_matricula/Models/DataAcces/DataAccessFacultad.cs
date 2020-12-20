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
    public class DataAccessFacultad
    {

        public List<Facultad> GetFacultad()
        {
            int Id = 1; ;
            List<Facultad> Facultads = new List<Facultad>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarFacultad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Facultad art = new Facultad
                {
                    Idfacultad = int.Parse(registros["Idfacultad"].ToString()),
                    Nomfacultad = registros["Nomfacultad"].ToString()
                };
                Facultads.Add(art);
            }
            con.Close();
            return Facultads;
        }

        public List<Facultad> GetAllFacultad()
        {
                SqlConnection con = new SqlConnection(Conexion_global.strConexion);
                List<Facultad> FacultadList = new List<Facultad>();
                SqlCommand com = new SqlCommand("AllFacultad", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            FacultadList = (from DataRow dr in dt.Rows
                         select new Facultad()
                         {
                             Idfacultad = Convert.ToInt32(dr["Idfacultad"]),
                             Nomfacultad = Convert.ToString(dr["Nomfacultad"])
                         }).ToList();
            return FacultadList;
        }

        //To Add Facultad
        public bool AgregarFacultad(Facultad obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddFacultad", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nomfacultad", obj.Nomfacultad);
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
        //To Edit Facultad
        public bool EditarFacultad(Facultad obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditFacultad", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idfacultad);
            com.Parameters.AddWithValue("@Nomfacultad", obj.Nomfacultad);
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


        public Facultad ObtenerFacultad(int cod)
        {

            Facultad Facultads = new Facultad();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getFacultad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Facultads.Idfacultad = int.Parse(registros["Idfacultad"].ToString());
                Facultads.Nomfacultad = registros["Nomfacultad"].ToString();
            }
            con.Close();
            return Facultads;
        }

        public bool DeleteFacultad(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand comf = new SqlCommand("BorrarFacultad", con);
            comf.CommandType = CommandType.StoredProcedure;
            comf.Parameters.AddWithValue("@Cod", Cod);
            con.Open();
            int i = comf.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }else{
                return false;
            }
        }





        public List<Facultad> LisFacultad()
        {
            List<Facultad> lst = new List<Facultad>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ComboFacultad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                //    Facultad art = new Facultad
                //    {
                //        Idfacultad = int.Parse(registros["Idfacultad"].ToString()),
                //        Nomfacultad = registros["Nomfacultad"].ToString()
                //    };
                //    lst.Add(art);
                lst.Add(new Facultad { 
                    Idfacultad= int.Parse(registros["Idfacultad"].ToString()), 
                    Nomfacultad= registros["Nomfacultad"].ToString()
                });
           }
            con.Close();
            return lst;

        }








    }
}