using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegVenta
    {
        DatosVenta objDatosVenta = new DatosVenta();

        public DataSet ListandoVentas(string buscar)
        {
            return objDatosVenta.listadoVentas(buscar);
        }
        public void InsertandoVenta(string accion, E_Ventas objEVentas)
        {
            objDatosVenta.abmVenta("Alta", objEVentas);
        }
        public DataSet UltimoRegistroVenta()
        {
            return objDatosVenta.UltimoRegistroVenta();
        }
        public DataSet VentasEntre(string Desde, string Hasta)
        {
            return objDatosVenta.TraerRegistrosPorFechas(Desde, Hasta);
        }
        public DataSet RegistrosHoy(string VentasHoy, string quien)
        {
            return objDatosVenta.RegistrosHoy(VentasHoy, quien);
        }
    }
}
