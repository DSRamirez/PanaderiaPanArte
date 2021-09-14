using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entidades;

namespace Datos
{
    public class DatosClientes : DatosConexionDB
    {
        public DataSet listadoClientes(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                
                orden = "select * from cliente where id_cliente = " + int.Parse(cual) + ";";             
            else
                orden = "select * from cliente;";
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
                    throw new Exception("Error al listar clientes", e);
                }
                finally
                {
                    Conexion.Close();
                    cmd.Dispose();
                }
                return ds;          
        }
        

        public int abmClientes(string accion, E_Cliente objECliente)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into cliente values ('" + objECliente.Nombre_cl +
                    "','" + objECliente.Nombre_neg +
                    "','" + objECliente.Dom +
                    "','" + objECliente.Mail +
                    "','" + objECliente.Tel +
                    "','" + objECliente.Esta_cancelado + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update cliente set nombre_cliente = '" + objECliente.Nombre_cl +
                    "', nombre_neg = '" + objECliente.Nombre_neg +
                    "', dom_cl = '" + objECliente.Dom +
                    "', mail_cliente = '" + objECliente.Mail +
                    "', telefono_cliente = '" + objECliente.Tel +
                    "', esta_cancelado = '" + objECliente.Esta_cancelado +
                    "'where id_cliente = " + objECliente.Id + ";";
            }

            if (accion == "Eliminar")
            {
                orden = "Update cliente set esta_cancelado = '" + objECliente.Esta_cancelado + "' where id_cliente = " + objECliente.Id + ";";
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


    }

    //AGREGAR ESTADO EN LA BAJA Y MOSTRAR QUE SE DIO DE BAJA(ACTIVO O NO)
    //    UPDATE DEL ESTADO

}


