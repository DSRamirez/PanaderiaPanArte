using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegProdProv
    {
        DatosProdProv objDatosProdProv = new DatosProdProv();
        public void AbmProdProv(string accion, E_ProdProv objEProduProv)
        {
            objDatosProdProv.AbmProdProv("Alta", objEProduProv);
        }

        public DataSet ListadoProdProv(string buscar)
        {
            return objDatosProdProv.listadoProdProv(buscar);
        }
    }
}
