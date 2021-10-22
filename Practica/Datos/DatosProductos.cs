using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProductos : DatosConexionDB
    {
        public DataSet listadoProducto(string cual)
        {

            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from producto where Id_producto = " + int.Parse(cual) + ";";
            }
            else
            {
                orden = "select * from producto;";
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
                throw new Exception("Error al listar productos", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abmProducto(string accion, E_Producto objEProducto)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into producto values ('" + objEProducto.Cod_prod +
                 "','" + objEProducto.Nombre_prod +
                 "','" + objEProducto.Stock_prod +
                 "','" + objEProducto.P_compra +
                 "','" + objEProducto.P_venta +
                 "','" + objEProducto.Idcat + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update producto set Cod_producto = '" + objEProducto.Cod_prod +
                    "', Nombre_producto = '" + objEProducto.Nombre_prod +
                    "', Stock_producto = '" + objEProducto.Stock_prod +
                    "', Preciouc_producto = '" + objEProducto.P_compra +
                    "', Preciouv_producto = '" + objEProducto.P_venta +
                    "', Id_categoria = '" + objEProducto.Idcat +
                    "'where Id_producto = " + objEProducto.Id + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "delete from producto where Id_producto = '" + objEProducto.Id + "';";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar producto", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public int ActualizarStock(string accion, E_ProductoVenta objEProductoVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "RestaStock")
            {
                orden = "UPDATE producto SET Stock_producto = Stock_producto - "+ objEProductoVenta.Cantidad + " WHERE Id_producto = " + objEProductoVenta.Id_producto;
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar stock", e);
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
