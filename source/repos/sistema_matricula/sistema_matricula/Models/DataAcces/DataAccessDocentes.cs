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
    public class DataAccessDocentes
    {

        public List<Docente> GetDocentes()
        {
            int Id = 1; ;
            List<Docente> Docentes = new List<Docente>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarDocente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Docente art = new Docente
                {
                    Iddocente = int.Parse(registros["Iddocente"].ToString()),
                    Nombres = registros["Nombres"].ToString(),
                    Apellidos = registros["Apellidos"].ToString(),
                    Direccion = registros["Direccion"].ToString(),
                    Celular = int.Parse(registros["Celular"].ToString())
                };
                Docentes.Add(art);
            }
            con.Close();
            return Docentes;
        }

        public List<Docente> GetAllDocente()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Docente> DocenteList = new List<Docente>();
            SqlCommand com = new SqlCommand("AllDocente", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            DocenteList = (from DataRow dr in dt.Rows
                         select new Docente()
                         {
                             Iddocente = Convert.ToInt32(dr["Iddocente"]),
                             Nombres = Convert.ToString(dr["Nombres"]),
                             Apellidos = Convert.ToString(dr["Apellidos"]),
                             Direccion = Convert.ToString(dr["Direccion"]),
                             Celular = Convert.ToInt32(dr["Celular"]),
                         }).ToList();
            return DocenteList;
        }

        //To Add Docente
        public bool AgregarDocente(Docente obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddDocente", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nombres", obj.Nombres);
            com.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
            com.Parameters.AddWithValue("@Direccion", obj.Direccion);
            com.Parameters.AddWithValue("@Celular", obj.Celular);
            com.Parameters.AddWithValue("@Usuario", obj.Usuario);
            com.Parameters.AddWithValue("@Clave", obj.Clave);
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
        //To Edit Docente
        public bool EditarDocente(Docente obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditDocente", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Iddocente);
            com.Parameters.AddWithValue("@Nombres", obj.Nombres);
            com.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
            com.Parameters.AddWithValue("@Direccion", obj.Direccion);
            com.Parameters.AddWithValue("@Celular", obj.Celular);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }else {
                return false;
            }
        }


        public Docente ObtenerDocente(int cod)
        {

            Docente Docentes = new Docente();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getDocente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Docentes.Iddocente = int.Parse(registros["Iddocente"].ToString());
                Docentes.Nombres = registros["Nombres"].ToString();
                Docentes.Apellidos = registros["Apellidos"].ToString();
                Docentes.Direccion = registros["Direccion"].ToString();
                Docentes.Celular = int.Parse(registros["Celular"].ToString());
            }
            con.Close();
            return Docentes;
        }

        public bool DeleteDocente(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarDocente", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", Cod);
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



    }
}