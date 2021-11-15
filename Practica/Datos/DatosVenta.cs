using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosVenta : DatosConexionDB
    {
        public DataSet listadoVentas(string cual)
        {
            string orden;
            if (cual == "TodosDetalle")
            {
                orden = "Select v.Id_venta, c.nombre_cliente, a.Nombre_autorizado, p.Nombre_fpago , " +
                    "v.Montofinal, v.Fecha_venta, v.Hora_venta, v.Estado_trans, v.N_Factura from venta v " +
                    "Inner join cliente c on c.id_cliente = v.Id_cliente " +
                    "Inner join Autorizado a on a.Id_autorizado = v.Id_autorizado " +
                    "Inner join fpago p on p.Id_fpago = v.Id_fpago";
            }
            else { 
                orden = "select * from venta";
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
                throw new Exception("Error al listar ventas", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int abmVenta(string accion, E_Ventas objEVentas)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into venta values ('" + objEVentas.Id_cliente1 +
                    "','" + objEVentas.Id_autorizado1 +
                    "','" + objEVentas.Id_fpago1 +
                    "','" + objEVentas.Monto1 +
                    "','" + objEVentas.Fecha_compra1 +
                    "','" + objEVentas.Hora_venta1 +
                    "','" + objEVentas.Estado_trans1 +
                    "','" + objEVentas.Num_Factura1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update venta set Id_cliente = '" + objEVentas.Id_cliente1 +
                    "','" + objEVentas.Id_autorizado1 +
                    "','" + objEVentas.Id_fpago1 +
                    "','" + objEVentas.Monto1 +
                    "','" + objEVentas.Fecha_compra1 +
                    "','" + objEVentas.Hora_venta1 +
                    "','" + objEVentas.Estado_trans1 +
                    "','" + objEVentas.Num_Factura1 + 
                    "'where venta = " + objEVentas.Id_venta1 + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar la venta", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }


        public DataSet UltimoRegistroVenta()
        {
            string orden = string.Empty;
                orden = "Select TOP 1 Id_venta from venta order by Id_venta desc";
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
                throw new Exception("Error al traer ultimo registro", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }

        public DataSet TraerRegistrosPorFechas(string Desde, string Hasta)
        {
            string orden = "Select v.Id_venta, c.nombre_cliente, a.Nombre_autorizado, p.Nombre_fpago , v.Montofinal, v.Fecha_venta, v.Hora_venta, v.Estado_trans, v.N_Factura " +
                "from venta v " +
                "Inner join cliente c on c.id_cliente = v.Id_cliente " +
                "Inner join Autorizado a on a.Id_autorizado = v.Id_autorizado " +
                "Inner join fpago p on p.Id_fpago = v.Id_fpago where v.Fecha_venta between '" +Desde +"' and '"+ Hasta +"'";

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
                throw new Exception("Error al traer ultimo registro", e);
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
