using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_ProductoVenta
    {
        private int id_producto_venta;
        private int id_venta;
        private int id_producto;
        private int cantidad;
        private int preciou_historico;


        public E_ProductoVenta()
        {

        }

        public E_ProductoVenta(int idpv, int idv, int idp, int cant, int puh)
        {
            Id_producto_venta = idpv;
            Id_venta = idv;
            Id_producto = idp;
            Cantidad = cant;
            Preciou_historico = puh;
        }

        public int Id_producto_venta { get => id_producto_venta; set => id_producto_venta = value; }
        public int Id_venta { get => id_venta; set => id_venta = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Preciou_historico { get => preciou_historico; set => preciou_historico = value; }
    }
}

