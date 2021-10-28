using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProductoVenta : DatosConexionDB
    {
        public DataSet listadoProductoVenta(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")

                orden = "select * from producto_venta where id_producto_venta = " + int.Parse(cual) + ";";
            else
                orden = "select * from producto_venta;";

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
                throw new Exception("Error al listar detalle de venta", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int abmProductoVenta(string accion, E_ProductoVenta objEProductoVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into producto_venta values ('" + objEProductoVenta.Id_producto_venta +
                    "','" + objEProductoVenta.Id_venta +
                    "','" + objEProductoVenta.Id_producto +
                    "','" + objEProductoVenta.Cantidad +
                    "','" + objEProductoVenta.Preciou_historico +
                    "','" + objEProductoVenta.Monto + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update producto_venta set Id_cliente = '" + objEProductoVenta.Id_venta +
                    "','" + objEProductoVenta.Id_producto +
                    "','" + objEProductoVenta.Cantidad +
                    "','" + objEProductoVenta.Preciou_historico +
                    "','" + objEProductoVenta.Monto +
                    "'where producto_venta = " + objEProductoVenta.Id_producto_venta + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar el detalle de la venta", e);
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
