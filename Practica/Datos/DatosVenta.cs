using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosVenta : DatosConexionDB
    {
        public DataSet listadoVentas(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")

                orden = "select * from venta where Id_venta = " + int.Parse(cual) + ";";
            else
                orden = "select * from venta;";
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
                throw new Exception("Error al listar ventas", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int abmVenta(string accion, E_Ventas objEVentas)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into venta values ('" + objEVentas.Id_cliente1 +
                    "','" + objEVentas.Id_autorizado1 +
                    "','" + objEVentas.Id_fpago1 +
                    "','" + objEVentas.Monto1 +
                    "','" + objEVentas.Fecha_compra1 +
                    "','" + objEVentas.Hora_venta1 +
                    "','" + objEVentas.Estado_trans1 +
                    "','" + objEVentas.Num_Factura1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update venta set Id_cliente = '" + objEVentas.Id_cliente1 +
                    "','" + objEVentas.Id_autorizado1 +
                    "','" + objEVentas.Id_fpago1 +
                    "','" + objEVentas.Monto1 +
                    "','" + objEVentas.Fecha_compra1 +
                    "','" + objEVentas.Hora_venta1 +
                    "','" + objEVentas.Estado_trans1 +
                    "','" + objEVentas.Num_Factura1 + 
                    "'where venta = " + objEVentas.Id_venta1 + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "Update venta set Estado_trans = '" + objEVentas.Estado_trans1 + "' where Id_venta = " + objEVentas.Id_venta1 + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar la venta", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }
    }
}
