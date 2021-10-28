using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegDeuda
    {
        DatosDeuda objDatosDeuda = new DatosDeuda();

        public DataSet ListandoDeudas(string buscar)
        {
            return objDatosDeuda.listadoDeudas(buscar);
        }

        public DataSet ListandoDeudasPorCliente(string buscar)
        {
            return objDatosDeuda.listadoDeudasPorCliente(buscar);
        }
        public void InsertandoDeuda(string accion, E_Deuda objEDeuda)
        {
            objDatosDeuda.abmDeuda("Alta", objEDeuda);
        }

        public void EditandoDeuda(string accion, E_Deuda objEDeuda)
        {
            objDatosDeuda.abmDeuda(accion, objEDeuda);
        }
    }
}
