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
    public class DataAccessAlumno
    {


       

        public List<Alumno> GetAlumnos()
        {
            int Id = 1; ;
            List<Alumno> Alumnos = new List<Alumno>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmd = new SqlCommand("ListarAlumno", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                con.Open();
                var registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Alumno art = new Alumno
                    {
                        Idalumno = int.Parse(registros["IdAlumno"].ToString()),
                        Apellidos = registros["Apellidos"].ToString(),
                        Nombres = registros["Nombres"].ToString(),
                        DNI = int.Parse(registros["DNI"].ToString()),
                        Direccion = registros["Direccion"].ToString(),
                        Telefono = int.Parse(registros["Telefono"].ToString())
                    };
                    Alumnos.Add(art);
                }
            }
            con.Close();
            return Alumnos;
        }

        public List<Alumno> GetAllAlumno()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Alumno> AlumnoList = new List<Alumno>();
            using (SqlCommand com = new SqlCommand("AllAlumno", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                AlumnoList = (from DataRow dr in dt.Rows
                              select new Alumno()
                              {
                                  Idalumno = Convert.ToInt32(dr["Idalumno"]),
                                  Apellidos = Convert.ToString(dr["Apellidos"]),
                                  Nombres = Convert.ToString(dr["Nombres"]),
                                  DNI = Convert.ToInt32(dr["DNI"]),
                                  Direccion = Convert.ToString(dr["Direccion"]),
                                  Telefono = Convert.ToInt32(dr["Telefono"]),
                              }).ToList();
            }
            return AlumnoList;
        }

        //To Add Alumno
        public bool AgregarAlumno(Alumno obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("AddAlumno", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                com.Parameters.AddWithValue("@Nombres", obj.Nombres);
                com.Parameters.AddWithValue("@DNI", obj.DNI);
                com.Parameters.AddWithValue("@Direccion", obj.Direccion);
                com.Parameters.AddWithValue("@Telefono", obj.Telefono);
                com.Parameters.AddWithValue("@Usuario", obj.Usuario);
                com.Parameters.AddWithValue("@Clave", obj.Clave);

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
        //To Edit Alumno

        

        public bool EditarAl(Alumno obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("EditAlumno", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Apellidos", obj.Apellidos);
                com.Parameters.AddWithValue("@Nombres", obj.Nombres);
                com.Parameters.AddWithValue("@DNI", obj.DNI);
                com.Parameters.AddWithValue("@Direccion", obj.Direccion);
                com.Parameters.AddWithValue("@Telefono", obj.Telefono);
                com.Parameters.AddWithValue("@Idalumno", obj.Idalumno);

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





        public Alumno ObtenerAlumno(int cod)
        {
            Alumno Alumnos = new Alumno();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmd = new SqlCommand("getAlumno", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@cod", cod));
                con.Open();
                var registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Alumnos.Idalumno = int.Parse(registros["Idalumno"].ToString());
                    Alumnos.Apellidos = registros["Apellidos"].ToString();
                    Alumnos.Nombres = registros["Nombres"].ToString();
                    Alumnos.DNI = int.Parse(registros["DNI"].ToString());
                    Alumnos.Direccion = registros["Direccion"].ToString();
                    Alumnos.Telefono = int.Parse(registros["Telefono"].ToString());
                }
            }
            con.Close();
            return Alumnos;
        }

        public bool DeleteAlumno(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("BorrarAlumno", con))
            {
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
}