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
    public class DataAccessAsignatura
    {

        public List<Asignatura> GetAsignaturas()
        {
            int Id = 1; ;
            List<Asignatura> Asignaturas = new List<Asignatura>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmd = new SqlCommand("ListarAsignatura", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                con.Open();
                var registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Asignatura art = new Asignatura
                    {
                        Idasignatura = int.Parse(registros["Idasignatura"].ToString()),
                        Asignaturas = registros["Asignatura"].ToString(),
                        Idcarrera = int.Parse(registros["Idcarrera"].ToString()),
                        Idciclo = int.Parse(registros["Idciclo"].ToString()),
                        Iddocente = int.Parse(registros["Iddocente"].ToString()),
                        Creditos = int.Parse(registros["Creditos"].ToString()),
                        Costo = decimal.Parse(registros["Costo"].ToString()),
                        Numvacante = int.Parse(registros["Numvacante"].ToString()),

                    };
                    Asignaturas.Add(art);
                }
            }
            con.Close();
            return Asignaturas;
        }

        public List<Asignatura> GetAllAsignatura()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Asignatura> AsignaturaList = new List<Asignatura>();
            SqlCommand com = new SqlCommand("AllAsignatura", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            AsignaturaList = (from DataRow dr in dt.Rows
                         select new Asignatura()
                         {
                             Idasignatura = Convert.ToInt32(dr["Idasignatura"]),
                             Asignaturas = Convert.ToString(dr["Asignatura"]),
                             Carrera = Convert.ToString(dr["nombrecarrera"]),
                             Ciclo = Convert.ToString(dr["Nomciclo"]),
                             Docente = Convert.ToString(dr["docente"]),
                             Creditos=Convert.ToInt32(dr["Creditos"]),
                             Costo = Convert.ToDecimal(dr["Costo"]),
                             Numvacante = Convert.ToInt32(dr["Numvacante"])
                         }).ToList();
            return AsignaturaList;
        }




        //To Add Asignatura
        public bool AgregarAsignatura(Asignatura obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("AddAsignatura", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Asignatura", obj.Asignaturas);
                com.Parameters.AddWithValue("@Idcarrera", obj.Idcarrera);
                com.Parameters.AddWithValue("@Idciclo", obj.Idciclo);
                com.Parameters.AddWithValue("@Iddocente", obj.Iddocente);
                com.Parameters.AddWithValue("@Creditos", obj.Creditos);
                com.Parameters.AddWithValue("@Costo", obj.Costo);
                com.Parameters.AddWithValue("@Numvacante", obj.Numvacante);

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
        //To Edit Asignatura
        public bool Editar(Asignatura obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditAsignatura", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idasignatura);
            com.Parameters.AddWithValue("@Asignatura", obj.Asignaturas);
            com.Parameters.AddWithValue("@Idcarrera", obj.Idcarrera);
            com.Parameters.AddWithValue("@Idciclo", obj.Idciclo);
            com.Parameters.AddWithValue("@Iddocente", obj.Iddocente);
            com.Parameters.AddWithValue("@Creditos", obj.Creditos);
            com.Parameters.AddWithValue("@Costo", obj.Costo);
            com.Parameters.AddWithValue("@Numvacante", obj.Numvacante);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            } else  {
                return false;
            }

        }


        public Asignatura ObtenerAsignatura(int cod)
        {
            Asignatura Asignaturas = new Asignatura();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getAsignatura", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Asignaturas.Idasignatura = int.Parse(registros["Idasignatura"].ToString());
                Asignaturas.Asignaturas =registros["Asignaturas"].ToString();
                Asignaturas.Idcarrera = int.Parse(registros["Idcarrera"].ToString());
                Asignaturas.Idciclo = int.Parse(registros["Idciclo"].ToString());
                Asignaturas.Iddocente = int.Parse(registros["Iddocente"].ToString());
                Asignaturas.Creditos = int.Parse(registros["Creditos"].ToString());
                Asignaturas.Costo = int.Parse(registros["Costo"].ToString());
                Asignaturas.Numvacante = int.Parse(registros["Numvacante"].ToString());

            }
            con.Close();
            return Asignaturas;
        }

        public bool DeleteAsignatura(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarAsignatura", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", Cod);
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

        public List<Asignatura> MisAsignaturas(int Iddocente)
        {
            List<Asignatura> Asignaturas = new List<Asignatura>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("MisAsignaturas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Iddocente", Iddocente));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Asignatura art = new Asignatura
                {
                    Idasignatura = int.Parse(registros["Idasignatura"].ToString()),
                    Asignaturas = registros["Asignatura"].ToString(),
                    Numvacante = int.Parse(registros["Numvacante"].ToString()),
                    Creditos = int.Parse(registros["Creditos"].ToString()),
                    Carrera= registros["nombrecarrera"].ToString(),
                    Ciclo = registros["nomciclo"].ToString(),

                };
                Asignaturas.Add(art);
            }
            con.Close();
            return Asignaturas;
        }



        public List<Asignatura> ListarCursoAlumno(int Idalumno)
        {
      
            List<Asignatura> Asignaturas = new List<Asignatura>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmd = new SqlCommand("AllAsignatura2", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Idalumno", Idalumno));
                con.Open();
                var registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Asignatura art = new Asignatura
                    {
                        Idasignatura = int.Parse(registros["Idasignatura"].ToString()),
                        Asignaturas = registros["Asignatura"].ToString(),
                        Carrera = registros["nombrecarrera"].ToString(),
                        Creditos = int.Parse(registros["Creditos"].ToString()),
                        Costo = decimal.Parse(registros["Costo"].ToString()),
                        Numvacante = int.Parse(registros["Numvacante"].ToString()),
                        Ciclo = registros["Nomciclo"].ToString(),
                        Docente = registros["docente"].ToString(),
                    };
                    Asignaturas.Add(art);
                }
            }
            con.Close();
            return Asignaturas;
        }





    }
}