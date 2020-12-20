using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sistema_matricula.Models;
using System.Web.Mvc;

namespace sistema_matricula.Models.DataAcces
{
    public class DataAccessUsuarios
    {

        public List<Usuarios> GetUsuario()
        {
            int Id = 1; ;
            List<Usuarios> usuario = new List<Usuarios>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Usuarios art = new Usuarios
                {
                    Idusuario = int.Parse(registros["Idusuario"].ToString()),
                    Nombres= registros["Nombres"].ToString(),
                    Usuario = registros["Usuario"].ToString(),
                    Clave = registros["Clave"].ToString(),
                    Tipo = registros["Tipo"].ToString()
                };
                usuario.Add(art);
            }
            con.Close();
            return usuario;
        }

        public List<Usuarios> GetAllUsuario()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Usuarios> UsuarioList = new List<Usuarios>();
            SqlCommand com = new SqlCommand("AllUsuario", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            UsuarioList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             Idusuario = Convert.ToInt32(dr["Idusuario"]),
                             Nombres = Convert.ToString(dr["Nombres"]),
                             Usuario = Convert.ToString(dr["Usuario"]),
                             Clave = Convert.ToString(dr["Clave"]),
                             Tipo = Convert.ToString(dr["Tipo"])
                         }).ToList();
            return UsuarioList;
        }

  
        public bool AgregarUsuario(Usuarios obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddUsuario", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Nombres", obj.Nombres);
            com.Parameters.AddWithValue("@Usuario", obj.Usuario);
            com.Parameters.AddWithValue("@Clave", obj.Clave);
            com.Parameters.AddWithValue("@Tipo", obj.Tipo);
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
   

        public bool EditarUsuario(Usuarios obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditUsuario", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod",obj.Idusuario);
            com.Parameters.AddWithValue("@Clave",obj.Clave);
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


        public Usuarios ObtenerUsuario(int cod)
        {

            Usuarios users = new Usuarios();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                users.Idusuario = int.Parse(registros["Idusuario"].ToString());
                users.Nombres = registros["Nombres"].ToString();
                users.Usuario = registros["Usuario"].ToString();
                users.Clave = registros["Clave"].ToString();
                users.Tipo = registros["Tipo"].ToString();
            }
            con.Close();
            return users;
        }

        public bool DeleteUsuario(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarUsuarios", con);
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