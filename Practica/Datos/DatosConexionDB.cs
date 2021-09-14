using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosConexionDB
    {
        public SqlConnection Conexion;
        public string cadenaConexion = @"Data Source=DESKTOP-H5KG9S2\SQLEXPRESS;Initial Catalog=Panaderia;Integrated Security=True;";

        public DatosConexionDB()
        {
            Conexion = new SqlConnection(cadenaConexion);
        }

        public void AbrirConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Broken || Conexion.State == ConnectionState.Closed)
                {
                    Conexion.Open();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir la conexión", e);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                {
                    Conexion.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar la conexión", e);
            }
        }

    }
}