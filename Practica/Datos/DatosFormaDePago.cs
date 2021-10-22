using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosFormaDePago : DatosConexionDB
    {
        public DataSet listadoFormaDePago(string cual)
        {

            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from fpago where Id_fpago = " + int.Parse(cual) + ";";
            }
            else
            {
                orden = "select * from fpago";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conexion.Open();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar formas de pago", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

    }

}
