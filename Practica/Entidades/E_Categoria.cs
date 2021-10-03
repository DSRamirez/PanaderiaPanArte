using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Categoria
    {
        private int id;
        private string name;
        private string cod;

        public E_Categoria()
        {

        }

        public E_Categoria(int id_categoria, string nombre_categoria, string cod_categoria)
        {
            Id = id_categoria;
            Name = nombre_categoria;
            Cod = cod_categoria;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Cod { get => cod; set => cod = value; }
    }
}