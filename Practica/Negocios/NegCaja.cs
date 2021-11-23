using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegCaja
    {
        DatosCaja objDatosCaja = new DatosCaja();
        public int abmCaja(string accion, E_Caja objECaja)
        {
            return objDatosCaja.abmCaja(accion, objECaja);
        }

        public DataSet datosUltimoAutorizadoConCajaAbierta()
        {
            return objDatosCaja.DatosUltimoAutorizadoConCajaAbierta();
        }

    }
}
