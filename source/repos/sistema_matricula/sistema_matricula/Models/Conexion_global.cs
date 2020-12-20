using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sistema_matricula.Models
{
    public static class Conexion_global
    {

        public static String strConexion = ConfigurationManager.ConnectionStrings["connlocal"].ConnectionString;
        public static void AddParametros(this SqlCommand cmd,ParameterDirection TipoInpOut,
                                       string strNameParametro,SqlDbType SqlTipoDato,
                                       int intSizeData,Object ObjValue = null)
        {
            SqlParameter parametro = new SqlParameter()
            {
                ParameterName = strNameParametro,
                SqlDbType = SqlTipoDato,
                Direction = TipoInpOut,
                Size = intSizeData
            };
            if (!(parametro.Direction == ParameterDirection.Output))
            {
                parametro.Value = ObjValue;
            }
            cmd.Parameters.Add(parametro);
        }


    }
}