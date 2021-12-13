using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosMovimientosExtraordinarios : DatosConexionDB
    {
        public DataSet listadoMovimientosExtraordinarios(string cual)
        {

            string orden = string.Empty;
            if (cual != "Todos")
            {
                //orden = "select * from MovimientosExtraordinarios where Id_MovExt = " + int.Parse(cual) + ";";

                orden = "Select m. Id_MovExt, a.Nombre_autorizado, m.Monto, m.Fecha_MovExt " +
                        "from MovimientosExtraordinarios m " +
                        "Inner join Autorizado a on a.Id_Autorizado = m.Id_autorizado " +
                        "where m.Id_MovExt = " + int.Parse(cual) + ";";               
            }
            else
            {
                orden = "select * from MovimientosExtraordinarios;";
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
                throw new Exception("Error al listar movimientos extraordinarios", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abmMovimientosExtraordinarios(string accion, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into MovimientosExtraordinarios values (" + objEMovimientosExtraordinarios.Id_autorizado +
                 ",'" + objEMovimientosExtraordinarios.Fecha_MovExt +
                 "'," + objEMovimientosExtraordinarios.Monto + ");";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar movimiento", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet RegistrosHoy(string Hoy, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            string orden = "Select m. Id_MovExt, a.Nombre_autorizado, m.Monto, m.Fecha_MovExt from MovimientosExtraordinarios m " +
                "Inner join Autorizado a on a.Id_Autorizado = m.Id_autorizado " +
                "where m.Fecha_MovExt = '" + Hoy + "' and m.Monto > 0 and m.Id_autorizado =" + objEMovimientosExtraordinarios.Id_autorizado +";";
            

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
                throw new Exception("Error al traer los ingresos extras de hoy", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet RegistrosEgresosHoy(string Hoy, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            string orden = "Select m.Id_MovExt, a.Nombre_autorizado, m.Monto, m.Fecha_MovExt from MovimientosExtraordinarios m " +
                "Inner join Autorizado a on a.Id_Autorizado = m.Id_autorizado " +
                "where m.Fecha_MovExt = '" + Hoy + "' and m.Monto < 0 and m.Id_autorizado =" + objEMovimientosExtraordinarios.Id_autorizado + ";";


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
                throw new Exception("Error al traer los ingresos extras de hoy", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet TraerEgresosExtraordinariosPorFechas(string Desde, string Hasta , E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            string orden = "Select a.Nombre_autorizado, m.Monto, m.Fecha_MovExt " +
                "from MovimientosExtraordinarios m " +
                "Inner join Autorizado a on a.Id_Autorizado = m.Id_autorizado " +
                "where m.Fecha_MovExt between '" + Desde + "' and '" + Hasta + "' and Monto < 0 and m.Id_autorizado = " + objEMovimientosExtraordinarios.Id_autorizado + ";";

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

        public DataSet TraerIngresosExtraordinariosPorFechas(string Desde, string Hasta, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            string orden = "Select a.Nombre_autorizado, m.Monto, m.Fecha_MovExt " +
                "from MovimientosExtraordinarios m " +
                "Inner join Autorizado a on a.Id_Autorizado = m.Id_autorizado " +
                "where m.Fecha_MovExt between '" + Desde + "' and '" + Hasta + "' and Monto > 0 and m.Id_autorizado = " + objEMovimientosExtraordinarios.Id_autorizado +";";

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
