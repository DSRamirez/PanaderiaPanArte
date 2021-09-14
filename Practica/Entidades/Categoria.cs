using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        private string id;
        private string cod;
        private string name;
        private string desc;

        public Categoria()
        {

        }

        public Categoria(string id_categoria, string cod_categoria, string nombre_categoria, string descripcion_categoria)
        {
            id = id_categoria;
            cod = cod_categoria;
            name = nombre_categoria;
            desc = descripcion_categoria;
        }

        public string P_IDCategoria
        {
            get { return id; }
            set { id = value; }
        }
        public string P_CodCategoria
        {
            get { return cod; }
            set { cod = value; }
        }

        public string P_NombreCategoria
        {
            get { return name; }
            set { name = value; }
        }

        public string P_DescCategoria
        {
            get { return desc; }
            set { desc = value; }
        }

    }
}