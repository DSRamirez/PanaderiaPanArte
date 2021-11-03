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

        public DataSet ListandoProveedor(string buscar)
        {
            return objDatoProveedor.listadoProveedor(buscar);
        }
        public void InsertandoPrroveedor(string accion, E_Proveedor objEProveedor)
        {
            objDatoProveedor.abmProveedor("Alta", objEProveedor);
        }

        public void EditandoProveedor(string accion, E_Proveedor objEProveedor)
        {
            objDatoProveedor.abmProveedor(accion, objEProveedor);
        }

        public void EliminandoProveedor(string accion, E_Proveedor objEProveedor)
        {
            objDatoProveedor.abmProveedor(accion, objEProveedor);
        }

        public DataSet ListadoProveedorRapido(string cual)
        {
            return objDatoProveedor.ListadoProveedorRapido(cual);
        }
    }
}
