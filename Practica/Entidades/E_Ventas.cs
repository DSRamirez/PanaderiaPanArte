using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Ventas
    {
        private int Id_venta;
        private int Id_cliente;
        private int Id_autorizado;
        private int Id_fpago;
        private decimal Monto;
        private string Fecha_compra;
        private string Hora_venta;
        private string Estado_trans;
        private string Num_Factura;

        public E_Ventas()
        {

        }

        public E_Ventas(int id, int id_cliente, int id_aut, int id_fpago, decimal monto, string fecha, string hora, string estado, string numf)
        {
            Id_venta1 = id;
            Id_cliente1 = id_cliente;
            Id_autorizado1 = id_aut;
            Id_fpago1 = id_fpago;
            Monto1 = monto;
            Fecha_compra1 = fecha;
            Hora_venta1 = hora;
            Estado_trans1 = estado;
            Num_Factura1 = numf;

        }

        public int Id_venta1 { get => Id_venta; set => Id_venta = value; }
        public int Id_cliente1 { get => Id_cliente; set => Id_cliente = value; }
        public int Id_autorizado1 { get => Id_autorizado; set => Id_autorizado = value; }
        public int Id_fpago1 { get => Id_fpago; set => Id_fpago = value; }
        public decimal Monto1 { get => Monto; set => Monto = value; }
        public string Fecha_compra1 { get => Fecha_compra; set => Fecha_compra = value; }
        public string Hora_venta1 { get => Hora_venta; set => Hora_venta = value; }
        public string Estado_trans1 { get => Estado_trans; set => Estado_trans = value; }
        public string Num_Factura1 { get => Num_Factura; set => Num_Factura = value; }
    }
}
