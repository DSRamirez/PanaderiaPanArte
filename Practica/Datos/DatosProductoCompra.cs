using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProductoCompra : DatosConexionDB
    {
        public DataSet listadoProductoCompra(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")

                orden = "select * from producto_compra where id_producto_compra = " + int.Parse(cual) + ";";
            else
                orden = "select * from producto_compra;";

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
                throw new Exception("Error al listar detalle de la compra", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int abmProductoCompra(string accion, E_ProductoCompra objEProductoCompra)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into producto_compra values ('" + objEProductoCompra.Id_compra1 +
                    "','" + objEProductoCompra.Id_producto1 +
                    "','" + objEProductoCompra.Cantidad1 +
                    "','" + objEProductoCompra.Preciou_historico1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update producto_compra set Id_producto = '" + objEProductoCompra.Id_producto1 +
                    "','" + objEProductoCompra.Id_compra1 +
                    "','" + objEProductoCompra.Cantidad1 +
                    "','" + objEProductoCompra.Preciou_historico1 +
                    "'where producto_compra = " + objEProductoCompra.Id_producto_compra1 + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar el detalle de la compra", e);
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
