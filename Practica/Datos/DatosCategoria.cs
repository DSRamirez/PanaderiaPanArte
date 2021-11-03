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
                orden = "select * from categoria where Id_categoria = " + int.Parse(cual) + ";";
            }
            else
            {
                orden = "select * from categoria;";
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
                throw new Exception("Error al listar categorias", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abmCategoria(string accion, E_Categoria objECategoria)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into categoria values ('" + objECategoria.Name +
                    "','" + objECategoria.Cod + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update categoria set Nombre_categoria = '" + objECategoria.Name +
                    "', Cod_cat = '" + objECategoria.Cod +
                    "'where Id_categoria = " + objECategoria.Id + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "delete from categoria where cod_categoria = '" + objECategoria.Cod + "';";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar cliente", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet ListadoCategoriaRapido(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from categoria where Nombre_categoria like '%" + cual + "%' or Cod_cat like '" + cual + "%';";
            }
            else
            {
                orden = "select * from categoria;";
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
                throw new Exception("Error al listar categoría", e);
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