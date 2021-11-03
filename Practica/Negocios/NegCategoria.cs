using System;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegCategoria
    {
        DatosCategoria objDatosCategoria = new DatosCategoria();

        public DataSet ListandoCategorias(string buscar)
        {
            return objDatosCategoria.listadocategoria(buscar);
        }
        public void InsertandoCategoria(string accion, E_Categoria objECategoria)
        {
            objDatosCategoria.abmCategoria("Alta", objECategoria);
        }

        public void EditandoCategoria(string accion, E_Categoria objECategoria)
        {
            objDatosCategoria.abmCategoria(accion, objECategoria);
        }

        public void EliminandoCategoria(string accion, E_Categoria objECategoria)
        {
            objDatosCategoria.abmCategoria(accion, objECategoria);
        }

        public DataSet ListadoCategoriaRapido(string cual)
        {
            return objDatosCategoria.ListadoCategoriaRapido(cual);
        }
    }
}
