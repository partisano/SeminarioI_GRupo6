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
    public class DataAccessMatricula
    {

        public List<Matricula> GetMatriculas()
        {
            int Id = 1; ;
            List<Matricula> Matriculas = new List<Matricula>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarMatricula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Matricula art = new Matricula
                {
                    Idmatricula = int.Parse(registros["Idmatricula"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    Alumno = registros["Apellidos"].ToString(),
                    Asignatura =registros["Asignaturas"].ToString(),
                };
                Matriculas.Add(art);
            }
            con.Close();
            return Matriculas;
        }

        public List<Matricula> GetAllMatricula()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Matricula> MatriculaList = new List<Matricula>();
            SqlCommand com = new SqlCommand("AllMatricula", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            MatriculaList = (from DataRow dr in dt.Rows
                         select new Matricula()
                         {
                             Idmatricula = Convert.ToInt32(dr["Idmatricula"]),
                             Fecha = Convert.ToDateTime(dr["Fecha"]),
                             Alumno = Convert.ToString(dr["Apellidos"] + "," + dr["Nombres"]),
                             Asignatura = Convert.ToString(dr["Asignatura"]),
                             Periodo = Convert.ToString(dr["Periodo"]),
                             Estados = Convert.ToString(dr["Estado"]),

                         }).ToList();
            return MatriculaList;
        }

        //To Add Matricula
        public bool AgregarMa(Matricula obj)
        {


            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddMatricula2", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Fecha", obj.Fecha);
            com.Parameters.AddWithValue("@Idalumno", obj.Idalumno);
            com.Parameters.AddWithValue("@Idasignatura", obj.Idasignatura);
            com.Parameters.AddWithValue("@Idperiodo", obj.Idperiodo);
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




        //To Edit Matricula
        public bool Editar(Matricula obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("EditMatricula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", obj.Idmatricula);
            com.Parameters.AddWithValue("@Fecha", obj.Fecha);
            com.Parameters.AddWithValue("@Idalumno", obj.Idalumno);
            com.Parameters.AddWithValue("@Idasignatura", obj.Idasignatura);
            com.Parameters.AddWithValue("@Idperiodo", obj.Idperiodo);
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

        public Matricula ObtenerMatricula(int cod)
        {
            Matricula Matriculas = new Matricula();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getMatricula", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Matriculas.Idmatricula = int.Parse(registros["Idmatricula"].ToString());
                Matriculas.Fecha = DateTime.Parse(registros["Fecha"].ToString());
                Matriculas.Idalumno = int.Parse(registros["Idalumno"].ToString());
                Matriculas.Idasignatura = int.Parse(registros["Idasignatura"].ToString());
                Matriculas.Idperiodo = int.Parse(registros["Idperiodo"].ToString());
            }
            con.Close();
            return Matriculas;
        }

        public bool DeleteMatricula(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarMatricula", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Cod", Cod);
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

        public bool Aprobar(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AprobarMatricula", con);
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
        public bool Desaprobar(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("DesaprobarMatricula", con);
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
        public List<Matricula> MisCursos(int Idalumno)
        {
            List<Matricula> Matriculas = new List<Matricula>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("Miscursos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Idalumno", Idalumno));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Matricula art = new Matricula
                {
                    Idmatricula = int.Parse(registros["Idmatricula"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    Alumno = registros["Apellidos"].ToString(),
                    Asignatura = registros["Asignatura"].ToString(),
                    Periodo = registros["Periodo"].ToString(),
                    Estados = registros["Estado"].ToString(),
                    
                };
                Matriculas.Add(art);
            }
            con.Close();
            return Matriculas;
        }

        public List<Matricula> MisAlumnos(int Iddocente)
        {
            List<Matricula> Matriculas = new List<Matricula>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("MisAlumnos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Iddocente", Iddocente));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Matricula art = new Matricula
                {
                    Idmatricula = int.Parse(registros["Idmatricula"].ToString()),
                    Fecha = DateTime.Parse(registros["Fecha"].ToString()),
                    Alumno = registros["Apellidos"].ToString() + " , " + registros["Nombres"].ToString(),
                    Asignatura = registros["Asignatura"].ToString(),
                    Periodo = registros["Periodo"].ToString(),
                    Estados = registros["Estado"].ToString(),

                };
                Matriculas.Add(art);
            }
            con.Close();
            return Matriculas;
        }

        public int ObtenerAlumno(int cod)
        {
            
            var codigo=0;
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("obteneridalumno", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Idusuario", cod));
            con.Open();
            SqlDataReader registros = cmd.ExecuteReader();
            while (registros.Read())
              {

                codigo = registros.GetInt32(0);
            }
            con.Close();


           return codigo;
        }

        public int ObtenerDocente(int cod)
        {

            var codigo = 0;
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("obteneriddocente", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Idusuario", cod));
            con.Open();
            SqlDataReader registros = cmd.ExecuteReader();
            while (registros.Read())
            {

                codigo = registros.GetInt32(0);
            }
            con.Close();


            return codigo;
        }


        public bool Inscribirme(DateTime fecha,int Idalumno,int Idasignatura,int Idperiodo)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("AddMatricula2", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Fecha", fecha);
                com.Parameters.AddWithValue("@Idalumno", Idalumno);
                com.Parameters.AddWithValue("@Idasignatura", Idasignatura);
                com.Parameters.AddWithValue("@Idperiodo", Idperiodo);
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




        public bool comprueba(int Idalumno, int Idasignatura)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("comprueba", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Idalumno", Idalumno);
                com.Parameters.AddWithValue("@Idasignatura", Idasignatura);
                //com.Parameters.AddWithValue("@Idperiodo", Idperiodo);
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




   


        public List<Matricula> Buscar(string texto)
        {
            List<Matricula> Matriculas = new List<Matricula>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("Buscar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@texto", texto));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Matricula art = new Matricula
                {
                    id = int.Parse(registros["Idalumno"].ToString()),
                    value = registros["Apellidos"].ToString(),

                };
                Matriculas.Add(art);
            }
            con.Close();
            return Matriculas;
        }








    }
}