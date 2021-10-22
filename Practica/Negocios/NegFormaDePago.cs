using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegFormaDePago
    {
        DatosFormaDePago objDatosFormaDePago = new DatosFormaDePago();

        public DataSet ListandoFormaDePago(string buscar)
        {
            return objDatosFormaDePago.listadoFormaDePago(buscar);
        }

    }
}
