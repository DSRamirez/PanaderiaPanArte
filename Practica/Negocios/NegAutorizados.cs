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
            objDatoAutorizado.AbmAutorizados("Alta", objEAutorizado);
        }

        public void EditandoAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            objDatoAutorizado.AbmAutorizados(accion, objEAutorizado);
        }

        public void EliminandoAutorizados(string accion, E_Autorizados objEAutorizado)
        {
            objDatoAutorizado.AbmAutorizados(accion, objEAutorizado);
        }

        public DataSet Login(string usuario, string password , E_Autorizados objEAutorizado)
        {
            objEAutorizado.Usuario_aut = usuario;
            objEAutorizado.Clave_aut = password;
            return objDatoAutorizado.Login(objEAutorizado);
        }

        public DataSet ListadoAutorizadoRapido(string cual)
        {
            return objDatoAutorizado.ListadoAutorizadoRapido(cual);
        }
    }
}
