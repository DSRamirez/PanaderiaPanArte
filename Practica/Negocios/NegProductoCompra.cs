using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegProductoCompra
    {
        DatosProductoCompra objDatosProductoCompra = new DatosProductoCompra();
        public void InsertandoProductoCompra(string accion, E_ProductoCompra objEProductoCompra)
        {
            objDatosProductoCompra.abmProductoCompra("Alta", objEProductoCompra);
        }

        public DataSet ListandoProductoCompra(string buscar)
        {
            return objDatosProductoCompra.listadoProductoCompra(buscar);
        }
    }
}
