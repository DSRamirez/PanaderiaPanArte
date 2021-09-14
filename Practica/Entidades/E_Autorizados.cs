using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Autorizados
    {
        private int id;
        private string nombre_aut;
        private string apellido_aut;
        private string usuario_aut;
        private string clave_aut;
        private bool esta_cancelado;

        public E_Autorizados()
        {
        }

        public E_Autorizados(int id, string nombre_aut, string apellido_aut, string usuario_aut, string clave_aut, bool esta_cancelado)
        {
            Id = id;
            Nombre_aut = nombre_aut;
            Apellido_aut = apellido_aut;
            Usuario_aut = usuario_aut;
            Clave_aut = clave_aut;
            Esta_cancelado = esta_cancelado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre_aut { get => nombre_aut; set => nombre_aut = value; }
        public string Apellido_aut { get => apellido_aut; set => apellido_aut = value; }
        public string Usuario_aut { get => usuario_aut; set => usuario_aut = value; }
        public string Clave_aut { get => clave_aut; set => clave_aut = value; }
        public bool Esta_cancelado { get => esta_cancelado; set => esta_cancelado = value; }
    }
}
