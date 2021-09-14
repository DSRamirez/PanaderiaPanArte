using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Entidades;
using Datos;

namespace Negocios
{
    public class NegProveedores
    {
        DatosProveedor objDatoProveedor = new DatosProveedor();

        public List<E_Proveedor>ListandoProveedores(string buscar)
        {
            return objDatoProveedor.ListarProveedores(buscar);
        }

        public void InsertandoProveedor(E_Proveedor proveedor)
        {
            objDatoProveedor.InsertarProveedor(proveedor);
        }

        public void EditandoProveedor(E_Proveedor proveedor)
        {
            objDatoProveedor.EditarProveedor(proveedor);
        }

        public void EliminandoProveedor(E_Proveedor proveedor)
        {
            objDatoProveedor.EliminarProveedor(proveedor);
        }
    }
}
