using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Compra
    {
        private int Id_Compra;
        private int Id_Proveedor;
        private int Id_Autorizado;
        private int Id_Fpago;
        private decimal MontoFinal;
        private string Fecha_Compra;
        private string Estado;
        private string N_Factura;

        public E_Compra()
        {

        }

        public E_Compra(int Id_Compra, int Id_Proveedor, int Id_Autorizado, int Id_Fpago, decimal MontoFinal, string Fecha_Compra, string Estado, string N_Factura)
        {
            Id_Compra1 = Id_Compra;
            Id_Proveedor1 = Id_Proveedor;
            Id_Autorizado1 = Id_Autorizado;
            Id_Fpago1 = Id_Fpago;
            MontoFinal1 = MontoFinal;
            Fecha_Compra1 = Fecha_Compra;
            Estado1 = Estado;
            N_Factura1 = N_Factura;
        }

        public int Id_Compra1 { get => Id_Compra; set => Id_Compra = value; }
        public int Id_Proveedor1 { get => Id_Proveedor; set => Id_Proveedor = value; }
        public int Id_Autorizado1 { get => Id_Autorizado; set => Id_Autorizado = value; }
        public int Id_Fpago1 { get => Id_Fpago; set => Id_Fpago = value; }
        public decimal MontoFinal1 { get => MontoFinal; set => MontoFinal = value; }
        public string Fecha_Compra1 { get => Fecha_Compra; set => Fecha_Compra = value; }
        public string Estado1 { get => Estado; set => Estado = value; }
        public string N_Factura1 { get => N_Factura; set => N_Factura = value; }
    }
}
