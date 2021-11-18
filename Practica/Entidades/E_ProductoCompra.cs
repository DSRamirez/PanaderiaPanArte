using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_ProductoCompra
    {
        private int Id_producto_compra;
        private int Id_compra;
        private int Id_producto;
        private decimal Cantidad;
        private decimal Preciou_historico;

        public E_ProductoCompra()
        {

        }

        public E_ProductoCompra( int id, int idcompra, int idprod, decimal cant, decimal precio)
        {
            Id_producto_compra1 = id;
            Id_compra1 = idcompra;
            Id_producto1 = idprod;
            Cantidad1 = cant;
            Preciou_historico1 = precio;
        }

        public int Id_producto_compra1 { get => Id_producto_compra; set => Id_producto_compra = value; }
        public int Id_compra1 { get => Id_compra; set => Id_compra = value; }
        public int Id_producto1 { get => Id_producto; set => Id_producto = value; }
        public decimal Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public decimal Preciou_historico1 { get => Preciou_historico; set => Preciou_historico = value; }
    }
}
