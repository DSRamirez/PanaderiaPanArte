using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosDeuda : DatosConexionDB
    {
        public DataSet listadoDeudas(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")

                orden = "select * from Deuda where ID_deuda = " + int.Parse(cual) + ";";
            else
                orden = "select * from Deuda;";
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
                throw new Exception("Error al listar deudas", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet listadoDeudasPorCliente(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")

                orden = "select * from Deuda where Id_cliente = " + int.Parse(cual) + ";";
            else
                orden = "select * from Deuda;";
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
                throw new Exception("Error al listar deudas", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public int abmDeuda(string accion, E_Deuda objEDeuda)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into Deuda values ('" + objEDeuda.Id_cliente1 +
                    "','" + objEDeuda.Id_venta1 +
                    "','" + objEDeuda.Fecha1 +
                    "','" + objEDeuda.Importe1 +
                    "','" + objEDeuda.Descripcion1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update Deuda set Importe = '" + objEDeuda.Importe1 +
                    "'where Id_cliente = " + objEDeuda.Id_cliente1 + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar la deuda", e);
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
