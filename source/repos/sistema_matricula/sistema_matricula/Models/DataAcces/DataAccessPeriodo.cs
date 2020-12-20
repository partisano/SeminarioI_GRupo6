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
    public class DataAccessPeriodo
    {

        public List<Periodo> GetPeriodos()
        {
            int Id = 1; ;
            List<Periodo> ciclos = new List<Periodo>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmdc = new SqlCommand("ListadoPeriodo", con))
            {
                cmdc.CommandType = CommandType.StoredProcedure;
                cmdc.Parameters.Add(new SqlParameter("@Id", Id));
                con.Open();
                var registros = cmdc.ExecuteReader();
                while (registros.Read())
                {
                    Periodo art = new Periodo
                    {
                        Idperiodo = int.Parse(registros["Idperiodo"].ToString()),
                        Nomperiodo = registros["Nomperiodo"].ToString(),
                        Finicio = registros["Finicio"].ToString(),
                        Ffin = registros["Ffin"].ToString()
                    };
                    ciclos.Add(art);
                }
            }
            con.Close();
            return ciclos;
        }

        public List<Periodo> GetAllPeriodos()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Periodo> PeriodoList = new List<Periodo>();
            using (SqlCommand com = new SqlCommand("AllPeriodo", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                PeriodoList = (from DataRow dr in dt.Rows
                               select new Periodo()
                               {
                                   Idperiodo = Convert.ToInt32(dr["Idperiodo"]),
                                   Nomperiodo = Convert.ToString(dr["Nomperiodo"]),
                                   Finicio = Convert.ToString(dr["Finicio"]),
                                   Ffin = Convert.ToString(dr["Ffin"]),
                               }).ToList();
            }
            return PeriodoList;
        }

        //To Add Periodo
        public bool AgregarPeriodos(Periodo obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("AddPeriodo", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Nomperiodo", obj.Nomperiodo);
                com.Parameters.AddWithValue("@Finicio", obj.Finicio);
                com.Parameters.AddWithValue("@Ffin", obj.Ffin);
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
        //To Edit Periodo
        public bool EditarPeriodos(Periodo obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("EditPeriodo", con))
            {
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Cod", obj.Idperiodo);
                com.Parameters.AddWithValue("@Nomperiodo", obj.Nomperiodo);
                com.Parameters.AddWithValue("@Finicio", obj.Finicio);
                com.Parameters.AddWithValue("@Ffin", obj.Ffin);

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


        public Periodo ObtenerPeriodos(int cod)
        {

            Periodo periodos = new Periodo();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand cmd = new SqlCommand("getPeriodo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@cod", cod));
                con.Open();
                var registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    periodos.Idperiodo = int.Parse(registros["Idperiodo"].ToString());
                    periodos.Nomperiodo = registros["Nomperiodo"].ToString();
                    periodos.Finicio = registros["Finicio"].ToString();
                    periodos.Ffin =registros["Ffin"].ToString();
                }
            }
            con.Close();
            return periodos;
        }

        public bool DeletePeriodos(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            using (SqlCommand com = new SqlCommand("BorrarPeriodo", con))
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