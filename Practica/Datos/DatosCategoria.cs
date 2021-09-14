using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosCategoria : DatosConexionDB
    {
        public DataSet listadocategoria(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from categoria where cod_categoria = '" + (cual) + "';";
            }
            else
            {
                orden = "select * from categoria order by cod_categoria;";
            }
            SqlCommand cmd = new SqlCommand(orden, Conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar las Categorias", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }
        public DataSet getcategoria(string cual)
        {
            string orden = string.Empty;
            orden = "select * from categoria where cod_categoria = '" + (cual) + "';";
            SqlCommand cmd = new SqlCommand(orden, Conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al ver datos de Categoria", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet crudcategoria(string accion, Categoria objcategoria)
        {
            string orden = string.Empty;
            if (accion == "Alta")
            {
                orden = "insert into categoria values (" + objcategoria.P_CodCategoria + ", '" + objcategoria.P_NombreCategoria + "', '" + objcategoria.P_DescCategoria + "');";
            }
            if (accion == "Modificar")
            {
                orden = "update categoria set nombre_categoria = '" + objcategoria.P_NombreCategoria + "', descripcion = '" + objcategoria.P_DescCategoria + "' where cod_categoria = '" + objcategoria.P_CodCategoria + "';";
            }
            if (accion == "ModificarCod")
            {
                orden = "update categoria set nombre_categoria = '" + objcategoria.P_NombreCategoria + "', descripcion = '" + objcategoria.P_DescCategoria + "', cod_categoria = '" + objcategoria.P_CodCategoria + "' where id_categoria = '" + objcategoria.P_IDCategoria + "';";
            }
            if (accion == "Quitar")
            {
                orden = "delete from categoria where cod_categoria = '" + objcategoria.P_CodCategoria + "';";
            }
            SqlCommand cmd = new SqlCommand(orden, Conexion);
            DataSet ds = new DataSet();
            try
            {
                AbrirConexion();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar crear nueva Categoría", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }
    }
}
