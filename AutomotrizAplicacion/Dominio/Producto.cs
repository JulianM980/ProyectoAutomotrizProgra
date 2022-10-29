using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Producto
    {
        public Producto()
        {
            IdProducto = 0;
            Nombre = "";
            Marca = new Marca();
        }
        public Producto(int id,string nombre,Marca marca)
        {
            IdProducto = id;
            Nombre = nombre;
            Marca = marca;
        }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
    }
}
