using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_Caja
    {
        private int Id_Caja;
        private int Id_Autorizado;
        private string Fecha;
        private decimal ImporteInicial;
        private decimal ImporteFinal;
        private bool Estado;

        public E_Caja()
        {

        }

        public E_Caja(int id, int idAut, string fecha, decimal impInicio, decimal impFin, bool estado)
        {
            Id_Caja1 = id;
            Id_Autorizado1 = idAut;
            Fecha1 = fecha;
            ImporteInicial1 = impInicio;
            ImporteFinal1 = impFin;
            Estado1 = estado;
        }

        public int Id_Caja1 { get => Id_Caja; set => Id_Caja = value; }
        public int Id_Autorizado1 { get => Id_Autorizado; set => Id_Autorizado = value; }
        public string Fecha1 { get => Fecha; set => Fecha = value; }
        public decimal ImporteInicial1 { get => ImporteInicial; set => ImporteInicial = value; }
        public decimal ImporteFinal1 { get => ImporteFinal; set => ImporteFinal = value; }
        public bool Estado1 { get => Estado; set => Estado = value; }
    }
}
