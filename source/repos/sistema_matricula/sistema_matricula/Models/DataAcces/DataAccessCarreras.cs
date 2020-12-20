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
    public class DataAccessCarreras
    {

        public List<Carreras> GetCarreras()
        {
            int Id = 1; ;
            List<Carreras> Carreras = new List<Carreras>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarCarreras", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Carreras art = new Carreras
                {
                    Idcarrera = int.Parse(registros["Idcarrera"].ToString()),
                    Nombrecarrera = registros["Nombrecarrera"].ToString(),
                    Nummeses = int.Parse(registros["Nummeses"].ToString()),
                    Idfacultad = int.Parse(registros["Idfacultad"].ToString()),
                };
                Carreras.Add(art);
            }
            con.Close();
            return Carreras;
        }

        public List<Carreras> GetAllCarreras()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Carreras> CarrerasList = new List<Carreras>();
            SqlCommand com = new SqlCommand("AllCarreras", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            CarrerasList = (from DataRow dr in dt.Rows
                         select new Carreras()
                         {
                             Idcarrera = Convert.ToInt32(dr["Idcarrera"]),
                             Nombrecarrera = Convert.ToString(dr["Nombrecarrera"]),
                             Nummeses = Convert.ToInt32(dr["Nummeses"]),
                             Nomfacultad = Convert.ToString(dr["Nomfacultad"]),

                         }).ToList();
            return CarrerasList;
        }

        //AGREGAR CARRERAS
        public bool AgregarCarreras(Carreras obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddCarreras", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nombrecarrera", obj.Nombrecarrera);
            com.Parameters.AddWithValue("@Nummeses", obj.Nummeses);
            com.Parameters.AddWithValue("@Idfacultad", obj.Idfacultad);
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
        //EDITAR CARRERAS
        public bool EditarCarreras(Carreras obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditCarreras", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idcarrera);
            com.Parameters.AddWithValue("@Nombrecarrera", obj.Nombrecarrera);
            com.Parameters.AddWithValue("@Nummeses", obj.Nummeses);
            com.Parameters.AddWithValue("@Idfacultad", obj.Idfacultad);
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

        public Carreras ObtenerCarreras(int cod)
        {

            Carreras Carreras = new Carreras();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getCarreras", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Carreras.Idcarrera = int.Parse(registros["Idcarrera"].ToString());
                Carreras.Nombrecarrera = registros["Nombrecarrera"].ToString();
                Carreras.Nummeses = int.Parse(registros["Nummeses"].ToString());
                Carreras.Idfacultad = int.Parse(registros["Idfacultad"].ToString());
            }
            con.Close();
            return Carreras;
        }

        public bool DeleteCarreras(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarCarreras", con);
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
                lst.Add(new Facultad
                {
                    Idfacultad = int.Parse(registros["Idfacultad"].ToString()),
                    Nomfacultad = registros["Nomfacultad"].ToString(),
                });
            }
            con.Close();
            return lst;

        }


    }
}