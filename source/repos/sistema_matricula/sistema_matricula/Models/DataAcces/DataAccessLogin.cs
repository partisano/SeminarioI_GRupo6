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
    public class DataAccessLogin
    {

        public Usuarios Acceso(Login user)
        {

            Usuarios users = new Usuarios();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("loginusuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Usuario", user.Usuario));
            cmd.Parameters.Add(new SqlParameter("@Clave", user.Clave));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                users.Idusuario = int.Parse(registros["Idusuario"].ToString());
                users.Usuario = registros["Usuario"].ToString();
                users.Tipo = registros["Tipo"].ToString();
            }
            con.Close();
            return users;
        }

       

    }
}