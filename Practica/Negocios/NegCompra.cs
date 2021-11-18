using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;
namespace Negocios
{
    public class NegCompra
    {

            DatosCompra objDatosCompra = new DatosCompra();

            public DataSet ListandoCompras(string buscar)
            {
                return objDatosCompra.listadoCompras(buscar);
            }
            public void InsertandoCompra(string accion, E_Compra objECompra)
            {
                objDatosCompra.abmCompra("Alta", objECompra);
            }

            public void EditandoCompra(string accion, E_Compra objECompra)
            {
                objDatosCompra.abmCompra(accion, objECompra);
            }

            public void EliminandoCompra(string accion, E_Compra objECompra)
            {
                objDatosCompra.abmCompra(accion, objECompra);
            }

            public DataSet UltimoRegistroCompra()
            {
                return objDatosCompra.UltimoRegistroCompra();
            }
            public DataSet ComprasEntre(string Desde, string Hasta)
            {
                return objDatosCompra.TraerRegistrosPorFechas(Desde, Hasta);
            }
    }
}
