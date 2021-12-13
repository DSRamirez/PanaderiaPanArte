using System;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosCompra : DatosConexionDB
    {
        public DataSet listadoCompras(string cual)
        {
            string orden;
            if (cual == "TodoCompras")
            {
                orden = "Select c.Id_compra, p.nombre_prov, a.Nombre_autorizado, f.Nombre_fpago , c.Montofinal, c.Fecha_compra, c.Estado_trans, c.N_Factura " +
                    "from compra c Inner join proveedor p on c.Id_proveedor = p.id_prov " +
                    "Inner join Autorizado a on a.Id_autorizado = c.Id_autorizado " +
                    "Inner join fpago f on f.Id_fpago = c.Id_fpago";
            }
            else
            {
                orden = "Select v.Id_compra, c.nombre_prov, a.Nombre_autorizado, p.Nombre_fpago , " +
                        "v.Montofinal, v.Fecha_compra, v.Estado_trans, v.N_Factura from compra v " +
                        "Inner join proveedor c on c.id_prov = v.Id_proveedor " +
                        "Inner join Autorizado a on a.Id_autorizado = v.Id_autorizado " +
                        "Inner join fpago p on p.Id_fpago = v.Id_fpago where Id_compra =" + int.Parse(cual);
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
                throw new Exception("Error al listar compras", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int abmCompra(string accion, E_Compra objECompra)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into compra values ('" + objECompra.Id_Proveedor1 +
                    "','" + objECompra.Id_Autorizado1 +
                    "','" + objECompra.Id_Fpago1 +
                    "','" + objECompra.MontoFinal1 +
                    "','" + objECompra.Fecha_Compra1 +
                    "','" + objECompra.Estado1 +
                    "','" + objECompra.N_Factura1 + "');";
            }

            if (accion == "Modificar")
            {
                orden = "update compra set Id_proveedor = '" + objECompra.Id_Proveedor1 +
                    "','" + objECompra.Id_Autorizado1 +
                    "','" + objECompra.Id_Fpago1 +
                    "','" + objECompra.MontoFinal1 +
                    "','" + objECompra.Fecha_Compra1 +
                    "','" + objECompra.Estado1 +
                    "','" + objECompra.N_Factura1 +
                    "'where compra = " + objECompra.Id_Compra1 + ";";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar la compra", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return resultado;
        }


        public DataSet UltimoRegistroCompra()
        {
            string orden = string.Empty;
            orden = "Select TOP 1 Id_compra from compra order by Id_compra desc";
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
            string orden = "Select c.Id_compra, p.nombre_prov, a.Nombre_autorizado, f.Nombre_fpago , c.Montofinal, c.Fecha_compra, c.Estado_trans, c.N_Factura " +
                    "from compra c Inner join proveedor p on c.Id_proveedor = p.id_prov " +
                    "Inner join Autorizado a on a.Id_autorizado = c.Id_autorizado " +
                    "Inner join fpago f on f.Id_fpago = c.Id_fpago where c.Fecha_compra between '" + Desde + "' and '" + Hasta + "'";

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

        public DataSet RegistrosHoy(string Hoy, string quien)
        {
            string orden = "Select c.Id_compra, p.nombre_prov, a.Nombre_autorizado, f.Nombre_fpago , c.Montofinal, c.Fecha_compra, c.Estado_trans, c.N_Factura " +
                    "from compra c Inner join proveedor p on c.Id_proveedor = p.id_prov " +
                    "Inner join Autorizado a on a.Id_autorizado = c.Id_autorizado " +
                    "Inner join fpago f on f.Id_fpago = c.Id_fpago where c.Fecha_compra = '" + Hoy + "' and c.Id_autorizado =" + int.Parse(quien)+ ";";

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
                throw new Exception("Error al traer los registros de hoy", e);
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
