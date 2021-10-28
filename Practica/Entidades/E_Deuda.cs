using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Deuda
    {
        private int Id;
        private int Id_cliente;
        private int Id_venta;
        private string Fecha;
        private decimal Importe;
        private string Descripcion;

        public E_Deuda()
        {

        }

        public E_Deuda(int id, int id_cliente, int id_venta, string fecha, decimal importe, string descripcion)
        {
            Id1 = id;
            Id_cliente1 = id_cliente;
            Id_venta1 = id_venta;
            Fecha1 = fecha;
            Importe1 = importe;
            Descripcion1 = descripcion;
        }

        public int Id1 { get => Id; set => Id = value; }
        public int Id_cliente1 { get => Id_cliente; set => Id_cliente = value; }
        public int Id_venta1 { get => Id_venta; set => Id_venta = value; }
        public string Fecha1 { get => Fecha; set => Fecha = value; }
        public decimal Importe1 { get => Importe; set => Importe = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
    }
}
