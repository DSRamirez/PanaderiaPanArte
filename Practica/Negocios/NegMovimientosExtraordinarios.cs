using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegMovimientosExtraordinarios
    {

        DatosMovimientosExtraordinarios objDatosMovimientosExtraordinarios = new DatosMovimientosExtraordinarios();

        public DataSet listadoMovimientosExtraordinarios(string buscar)
        {
            return objDatosMovimientosExtraordinarios.listadoMovimientosExtraordinarios(buscar);
        }
        public void InsertandoMovimientosExtraordinarios(string accion, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            objDatosMovimientosExtraordinarios.abmMovimientosExtraordinarios("Alta", objEMovimientosExtraordinarios);
        }

        public void EliminandoMovimientosExtraordinarios(string accion, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            objDatosMovimientosExtraordinarios.abmMovimientosExtraordinarios(accion, objEMovimientosExtraordinarios);
        }

        public DataSet RegistrosIngresosHoy(string Hoy, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            return objDatosMovimientosExtraordinarios.RegistrosHoy(Hoy, objEMovimientosExtraordinarios);
        }

        public DataSet RegistrosEgresosHoy(string Hoy, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            return objDatosMovimientosExtraordinarios.RegistrosEgresosHoy(Hoy, objEMovimientosExtraordinarios);
        }
        public DataSet TraerEgresosExtraordinariosPorFechas(string Desde, string Hasta, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            return objDatosMovimientosExtraordinarios.TraerEgresosExtraordinariosPorFechas(Desde, Hasta, objEMovimientosExtraordinarios);
        }
        public DataSet TraerIngresosExtraordinariosPorFechas(string Desde, string Hasta, E_MovimientosExtraordinarios objEMovimientosExtraordinarios)
        {
            return objDatosMovimientosExtraordinarios.TraerIngresosExtraordinariosPorFechas(Desde, Hasta, objEMovimientosExtraordinarios);
        }
    }
}
