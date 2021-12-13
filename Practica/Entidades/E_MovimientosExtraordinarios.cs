using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class E_MovimientosExtraordinarios
    {
        private int id_MovExt;
        private int id_autorizado;
        private string fecha_MovExt;
        private decimal monto;

        public E_MovimientosExtraordinarios()
        {
        }

        public E_MovimientosExtraordinarios( int id, int idAut, string fecha, decimal monto)
        {
            Id_MovExt = id;
            Id_autorizado = idAut;
            Fecha_MovExt = fecha;
            Monto = monto;
        }


        public int Id_MovExt { get => id_MovExt; set => id_MovExt = value; }
        public int Id_autorizado { get => id_autorizado; set => id_autorizado = value; }
        public string Fecha_MovExt { get => fecha_MovExt; set => fecha_MovExt = value; }
        public decimal Monto { get => monto; set => monto = value; }

    }
}
