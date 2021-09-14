using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Proveedor
    {
        private int id;
        private string name;
        private string razonsocial;
        private string mail;
        private string tel;
        private string telrep;
        private string dom;
        private string cuil;
        private bool estado;

        public E_Proveedor()
        {
        }

        public E_Proveedor(int id_prov, string nombre_prov, string rs_prov, string mail_prov, string telefono_prov, string telrepartidor_prov, string dom_prov, string cuil_prov, bool esta_cancelado)
        {
            Id = id_prov;
            Name = nombre_prov;
            Razonsocial = rs_prov;
            Mail = mail_prov;
            Tel = telefono_prov;
            Telrep = telrepartidor_prov;
            Dom = dom_prov;
            Cuil = cuil_prov;
            Estado = esta_cancelado;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Razonsocial { get => razonsocial; set => razonsocial = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Telrep { get => telrep; set => telrep = value; }
        public string Dom { get => dom; set => dom = value; }
        public string Cuil { get => cuil; set => cuil = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}