using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegProductoVenta
    {
        DatosProductoVenta objDatosProductoVenta = new DatosProductoVenta();
        public void InsertandoProductoVenta(string accion, E_ProductoVenta objEProductoVenta)
        {
            objDatosProductoVenta.abmProductoVenta("Alta", objEProductoVenta);
        }

        public DataSet ListandoProductoVentas(string buscar)
        {
            return objDatosProductoVenta.listadoProductoVenta(buscar);
        }
    }
}
