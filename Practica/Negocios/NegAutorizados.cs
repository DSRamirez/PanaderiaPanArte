using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Negocios
{
    public class NegAutorizados
    {
        DatosAutorizados objDatoAutorizado = new DatosAutorizados();

        public DataSet ListandoAutorizados(string buscar)
        {
            return objDatoAutorizado.listadoAutorizados(buscar);
        }

        public void InsertandoAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            objDatoAutorizado.abmAutorizados("Alta", objEAutorizado);
        }

        public void EditandoAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            objDatoAutorizado.abmAutorizados(accion, objEAutorizado);
        }

        public void EliminandoAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            objDatoAutorizado.abmAutorizados(accion, objEAutorizado);
        }
    }
}
