using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    internal class Marca
    {
        public Marca()
        {
            IdMarca = -1;
            Nombre = "";
        }
        public Marca(int idMarca, string marca)
        {
            IdMarca = idMarca;
            Nombre = marca;
        }

        public int IdMarca { get; set; }
        public string Nombre { get; set; }
    }
}
