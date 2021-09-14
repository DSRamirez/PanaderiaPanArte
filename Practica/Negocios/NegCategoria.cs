using System;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegCategoria
    {
        DatosCategoria objDatosCategoria = new DatosCategoria();

        public DataSet ListadoCategorias(string cual)
        {
            return objDatosCategoria.listadocategoria(cual);
        }

        public DataSet InformacionCategorias(string cual)
        {
            return objDatosCategoria.getcategoria(cual);
        }

        public DataSet ABMCategorias(string accion, Categoria objcategoria)
        {
            return objDatosCategoria.crudcategoria(accion, objcategoria);
        }
    }
}
