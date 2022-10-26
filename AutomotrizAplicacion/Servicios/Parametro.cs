using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Servicios
{
    internal class Parametro
    {
        public Parametro(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public string Nombre { get; set; }
        public Object Valor { get; set; }
    }
}
