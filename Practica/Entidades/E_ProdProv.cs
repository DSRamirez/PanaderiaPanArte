using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace Entidades
{
    public class E_ProdProv
    {
        private int Id_ProdProv;
        private int Id_Producto;
        private int Id_Proveedor;

        public E_ProdProv()
        {
        }

        public E_ProdProv(int Id, int Id_Prod, int Id_Prov)
        {
            Id_ProdProv1 = Id;
            Id_Producto1 = Id_Prod;
            Id_Proveedor1 = Id_Prov;
        }

        public int Id_ProdProv1 { get => Id_ProdProv; set => Id_ProdProv = value; }
        public int Id_Producto1 { get => Id_Producto; set => Id_Producto = value; }
        public int Id_Proveedor1 { get => Id_Proveedor; set => Id_Proveedor = value; }
    }
}
