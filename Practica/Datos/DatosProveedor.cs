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
        public List<E_Proveedor> ListarProveedores(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARPROVEEDOR", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_Proveedor> Listar = new List<E_Proveedor>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Proveedor
                {
                    Id = LeerFilas.GetInt32(0),
                    Name = LeerFilas.GetString(1),
                    Razonsocial = LeerFilas.GetString(2),
                    Mail = LeerFilas.GetString(3),
                    Tel = LeerFilas.GetString(4),
                    Telrep = LeerFilas.GetString(5),
                    Dom = LeerFilas.GetString(6),
                    Cuil = LeerFilas.GetString(7),
                    Estado = LeerFilas.GetBoolean(8)
                }); 
            }

            Conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public void InsertarProveedor(E_Proveedor proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARPROVEEDOR", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@nombre_prov", proveedor.Name);
            cmd.Parameters.AddWithValue("@razonsocial_prov",proveedor.Razonsocial);
            cmd.Parameters.AddWithValue("@mail_prov", proveedor.Mail);
            cmd.Parameters.AddWithValue("@telefono_prov", proveedor.Tel);
            cmd.Parameters.AddWithValue("@tel_rep", proveedor.Telrep);
            cmd.Parameters.AddWithValue("@dom_prov", proveedor.Dom);
            cmd.Parameters.AddWithValue("@cuil_prov", proveedor.Cuil);
            cmd.Parameters.AddWithValue("@esta_cancelado", proveedor.Estado);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EditarProveedor(E_Proveedor proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARPROVEEDOR", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@id_prov", proveedor.Id);
            cmd.Parameters.AddWithValue("@nombre_prov", proveedor.Name);
            cmd.Parameters.AddWithValue("@razonsocial_prov", proveedor.Razonsocial);
            cmd.Parameters.AddWithValue("@mail_prov", proveedor.Mail);
            cmd.Parameters.AddWithValue("@telefono_prov", proveedor.Tel);
            cmd.Parameters.AddWithValue("@tel_rep", proveedor.Telrep);
            cmd.Parameters.AddWithValue("@dom_prov", proveedor.Dom);
            cmd.Parameters.AddWithValue("@cuil_prov", proveedor.Cuil);
            cmd.Parameters.AddWithValue("@esta_cancelado", proveedor.Estado);

            cmd.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarProveedor(E_Proveedor proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPROVEEDOR", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            Conexion.Open();

            cmd.Parameters.AddWithValue("@esta_cancelado", proveedor.Estado);
            cmd.Parameters.AddWithValue("@id_prov", proveedor.Id);

            cmd.ExecuteNonQuery();
            Conexion.Close();

        }
    }
}
