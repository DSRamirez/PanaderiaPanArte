using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Cliente
    {
        private int id;
        private string nombre_cl;
        private string nombre_neg;
        private string dom;
        private string mail;
        private string tel;
        private bool esta_cancelado;

        public E_Cliente()
        {
        }

        public E_Cliente(int id, string nombre_cl, string nombre_neg, string dom, string mail, string tel, bool esta_cancelado)
        {
            Id = id;
            Nombre_cl = nombre_cl;
            Nombre_neg = nombre_neg;
            Dom = dom;
            Mail = mail;
            Tel = tel;
            Esta_cancelado = esta_cancelado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre_cl { get => nombre_cl; set => nombre_cl = value; }
        public string Nombre_neg { get => nombre_neg; set => nombre_neg = value; }
        public string Dom { get => dom; set => dom = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Tel { get => tel; set => tel = value; }
        public bool Esta_cancelado { get => esta_cancelado; set => esta_cancelado = value; }
    }
}
