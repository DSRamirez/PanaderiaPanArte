using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_FormaDePago
    {
        private int Id_fpago;
        private string Nombre_fpago;

        public E_FormaDePago()
        {

        }

        public E_FormaDePago(int id, string namefp)
        {
            Id_fpago1 = id;
            Nombre_fpago1 = namefp;
        }

        public int Id_fpago1 { get => Id_fpago; set => Id_fpago = value; }
        public string Nombre_fpago1 { get => Nombre_fpago; set => Nombre_fpago = value; }
    }
}
