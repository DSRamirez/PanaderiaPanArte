using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Producto
    {
        private int id;
        private int cod_prod;
        private string nombre_prod;
        private int stock_prod;
        private decimal p_compra;
        private decimal p_venta;
        private string um;
        private int idcat;

        public E_Producto()
        {

        }

        public E_Producto( int id, int codp, string nombre_p, int stock, decimal pc, decimal pv, string um, int idc)
        {
            Id = id;
            Cod_prod = codp;
            Nombre_prod = nombre_p;
            Stock_prod = stock;
            P_compra = pc;
            P_venta = pv;
            Um = um;
            Idcat = idc;
        }


        public int Id { get => id; set => id = value; }
        public int Cod_prod { get => cod_prod; set => cod_prod = value; }
        public string Nombre_prod { get => nombre_prod; set => nombre_prod = value; }
        public int Stock_prod { get => stock_prod; set => stock_prod = value; }
        public decimal P_compra { get => p_compra; set => p_compra = value; }
        public decimal P_venta { get => p_venta; set => p_venta = value; }
        public string Um { get => um; set => um = value; }
        public int Idcat { get => idcat; set => idcat = value; }
    }
}
