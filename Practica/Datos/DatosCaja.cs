using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;
namespace Datos
{
    public class DatosCaja : DatosConexionDB
    {
        public int abmCaja(string accion, E_Caja objECaja)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into Caja values (" + objECaja.Id_Autorizado1 +
                           ",'" + objECaja.Fecha1 +
                           "'," + objECaja.ImporteInicial1 +
                           "," + objECaja.ImporteFinal1 +
                           ",'" + objECaja.Estado1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update Caja set Fecha = '" + objECaja.Fecha1 +
                    "'," + objECaja.ImporteInicial1 +
                    "," + objECaja.ImporteFinal1 +
                    "," + objECaja.Estado1 +
                    " where Id_Caja = " + objECaja.Id_Caja1 + ";";
            }
            if (accion == "Cierre")
            {
                orden = "update Caja set Fecha = '" + objECaja.Fecha1 + "', ImporteFinal = " + objECaja.ImporteFinal1 + ", Estado = '" + objECaja.Estado1 + "';";
            }
            if (accion == "IdCaja")
            {
                orden = "Select Id_Caja from Caja where Fecha = '" + objECaja.Fecha1 + "'";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de abrir/cerrar caja", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet DatosUltimoAutorizadoConCajaAbierta()
        {
            string orden = string.Empty;
            orden = "select * from Caja where Fecha = '" + DateTime.Now.ToString("d") + "' and Estado=1;";

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
                throw new Exception("Error al traer ultimo registro", e);
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
