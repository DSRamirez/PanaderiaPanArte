using System;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegProducto
    {
        DatosProductos objDatosProductos = new DatosProductos();

        public DataSet ListandoProductos(string buscar)
        {
            return objDatosProductos.listadoProducto(buscar);
        }
        public void InsertandoProducto(string accion, E_Producto objEProducto)
        {
            objDatosProductos.abmProducto("Alta", objEProducto);
        }

        public void EditandoProducto(string accion, E_Producto objEProducto)
        {
            objDatosProductos.abmProducto(accion, objEProducto);
        }

        public void EliminandoProducto(string accion, E_Producto objEProducto)
        {
            objDatosProductos.abmProducto(accion, objEProducto);
        }

        public void ActualizarStock(string accion, E_ProductoVenta objEProductoVenta)
        {
            objDatosProductos.ActualizarStock(accion, objEProductoVenta);
        }

    }
}
