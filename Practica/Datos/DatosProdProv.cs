using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosProdProv : DatosConexionDB
    {
        public DataSet listadoProdProv(string cual)
        {
            string orden;
            if (cual != "Todos")

                orden = "select a.Nombre_producto, a.Id_producto from Prod_Prov b " +
                        "Inner join proveedor c on c.id_prov = b.Id_proveedor " +
                        "Inner join producto a on a.Id_producto = b.Id_producto " +
                        "where id_prov = " + int.Parse(cual) + ";";
            else
                orden = "select * from Prod_Prov;";

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
                throw new Exception("Error al listar Producto Proveedor", e);
            }
            finally
            {
                Conexion.Close();
                cmd.Dispose();
            }
            return ds;
        }


        public int AbmProdProv(string accion, E_ProdProv objEProdProv)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "insert into Prod_Prov values (" + objEProdProv.Id_Proveedor1 +
                    "," + objEProdProv.Id_Producto1 + ");";
            }

            SqlCommand cmd = new SqlCommand(orden, Conexion);

            try
            {
                AbrirConexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al tratar de guardar Producto-Proveedor", e);
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
