using System;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Datos
{
    public class DatosAutorizados : DatosConexionDB
    {
        public DataSet listadoAutorizados(string cual)
        {
            string orden;
            if (cual != "Todos")

                orden = "select * from Autorizado where Id_autorizado = " + int.Parse(cual) + ";";
            else
                orden = "select * from Autorizado;";
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
                throw new Exception("Error al listar Autorizados", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int AbmAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into Autorizado values ('" + objEAutorizado.Nombre_aut +
                    "','" + objEAutorizado.Apellido_aut +
                    "','" + objEAutorizado.Usuario_aut +
                     "','" + objEAutorizado.Clave_aut +
                    "','" + objEAutorizado.Esta_cancelado + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update Autorizado set Nombre_autorizado = '" + objEAutorizado.Nombre_aut +
                    "', Apellido_autorizado = '" + objEAutorizado.Apellido_aut +
                    "', Usuario_autorizado = '" + objEAutorizado.Usuario_aut +
                    "', Clave_autorizado = '" + objEAutorizado.Clave_aut +
                    "', esta_cancelado = '" + objEAutorizado.Esta_cancelado +
                    "'where Id_autorizado = " + objEAutorizado.Id + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "Update Autorizado set esta_cancelado = '" + objEAutorizado.Esta_cancelado + "' where Id_autorizado = " + objEAutorizado.Id + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de eliminar el autorizado", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet Login(E_Autorizados objEAutorizado)
        {
            string orden = "SELECT Usuario_autorizado, Clave_autorizado FROM Autorizado WHERE Usuario_autorizado = '" + objEAutorizado.Usuario_aut + "'AND Clave_autorizado ='" + objEAutorizado.Clave_aut + "' ";
            SqlCommand cmd = new SqlCommand(orden, Conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                Conexion.Open();
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Usuario no encontrado", e);
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
