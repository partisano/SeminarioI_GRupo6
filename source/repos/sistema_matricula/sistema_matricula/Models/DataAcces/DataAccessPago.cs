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
    public class DataAccessPago
    {

        public List<Pago> GetPagos()
        {
            int Id = 1; ;
            List<Pago> pagos = new List<Pago>();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("ListarPago", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Pago art = new Pago
                {
                    Idpago = int.Parse(registros["Idpago"].ToString()),
                    FechaPago = DateTime.Parse(registros["FechaPago"].ToString()),
                    Idalumno = int.Parse(registros["Idalumno"].ToString()),
                    Idtramite = int.Parse(registros["Idtramite"].ToString()),
                    Observacion = registros["Observacion"].ToString(),

                };
                pagos.Add(art);
            }
            con.Close();
            return pagos;
        }

        public List<Pago> GetAllPago()
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            List<Pago> PagoList = new List<Pago>();
            SqlCommand com = new SqlCommand("AllPago", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            PagoList = (from DataRow dr in dt.Rows
                         select new Pago()
                         {
                             Idpago = Convert.ToInt32(dr["Idpago"]),
                             FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                             CTramite = Convert.ToString((dr["Tramites"])),
                             CAlumno = Convert.ToString((dr["Apellidos"]) + " " + (dr["Nombres"])),
                             Observacion = Convert.ToString((dr["Observacion"])),
                         }).ToList();



            return PagoList;
        }



        //To Add Pago
        public bool AgregarPago(Pago obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddPago", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
            com.Parameters.AddWithValue("@Idtramite", obj.Idtramite);
            com.Parameters.AddWithValue("@Idalumno", obj.Idalumno);
            com.Parameters.AddWithValue("@Observacion", obj.Observacion);
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



        public bool AgregarPagoAumno(Pago obj)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("AddPago", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FechaPago", obj.FechaPago);
            com.Parameters.AddWithValue("@Idtramite", obj.Idtramite);
            com.Parameters.AddWithValue("@Idalumno", obj.Idalumno);
            com.Parameters.AddWithValue("@Observacion", obj.Observacion);
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



        public Pago ObtenerPago(int cod)
        {
            Pago Pagos = new Pago();
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand cmd = new SqlCommand("getPago", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", cod));
            con.Open();
            var registros = cmd.ExecuteReader();
            while (registros.Read())
            {
                Pagos.Idpago = int.Parse(registros["Idpago"].ToString());
                Pagos.FechaPago = DateTime.Parse(registros["FechaPago"].ToString());
                Pagos.Idalumno = int.Parse(registros["Idalumno"].ToString());
                Pagos.Idtramite = int.Parse(registros["Idtramite"].ToString());
                Pagos.Observacion = registros["Observacion"].ToString();
            }
            con.Close();
            return Pagos;
        }

        public bool DeletePago(int Cod)
        {
            SqlConnection con = new SqlConnection(Conexion_global.strConexion);
            SqlCommand com = new SqlCommand("BorrarPago", con);
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