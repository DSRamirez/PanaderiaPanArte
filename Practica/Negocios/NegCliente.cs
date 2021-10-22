using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Negocios
{
    public class NegCliente
    {

        DatosClientes objDatoCliente = new DatosClientes();

        //Listar Clientes 
        public DataSet ListandoClientes(string buscar)
        {
            return objDatoCliente.listadoClientes(buscar);
        }

        public void InsertandoCliente(string accion, E_Cliente objECliente)
        {
            objDatoCliente.abmClientes("Alta", objECliente);
        }

        public void EditandoCliente(string accion, E_Cliente objECliente)
        {
            objDatoCliente.abmClientes(accion, objECliente);
        }

        public void EliminandoCliente(string accion, E_Cliente objECliente)
        {
            objDatoCliente.abmClientes(accion, objECliente);
        }

        public DataTable ListaC()
        {
            return objDatoCliente.listaC();
        }
    }
}
