using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entidades;

namespace Datos
{
    public class DatosProveedor : DatosConexionDB
    {
        public DataSet listadoProveedor(string cual)
        {

            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from proveedor where id_prov = " + int.Parse(cual) + ";";
            }
            else
            {
                orden = "select * from proveedor;";
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
                throw new Exception("Error al listar proveedores", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abmProveedor(string accion, E_Proveedor objEProveedor)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into proveedor values ('" + objEProveedor.Name +
                 "','" + objEProveedor.Razonsocial +
                 "','" + objEProveedor.Mail +
                 "','" + objEProveedor.Tel +
                 "','" + objEProveedor.Telrep +
                 "','" + objEProveedor.Dom +
                 "','" + objEProveedor.Cuil +
                 "','" + objEProveedor.Estado + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update proveedor set nombre_prov = '" + objEProveedor.Name +
                    "', razonsocial_prov = '" + objEProveedor.Razonsocial +
                    "', mail_prov = '" + objEProveedor.Mail +
                    "', telefono_prov = '" + objEProveedor.Tel +
                    "', tel_rep = '" + objEProveedor.Telrep +
                    "', dom_prov = '" + objEProveedor.Dom +
                    "', cuil_prov = '" + objEProveedor.Cuil +
                    "', esta_cancelado = '" + objEProveedor.Estado +
                    "'where id_prov = " + objEProveedor.Id + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "Update proveedor set esta_cancelado = '" + objEProveedor.Estado + "' where id_prov = " + objEProveedor.Id + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar proveedor", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }

        public DataSet ListadoProveedorRapido(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
            {
                orden = "select * from proveedor where nombre_prov like '%" + cual + "%' or razonsocial_prov like '" + cual + "%';";
            }
            else
            {
                orden = "select * from proveedor;";
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
                throw new Exception("Error al listar proveedor", e);
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
