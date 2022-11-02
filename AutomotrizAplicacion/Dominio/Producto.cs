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
            Precio = 0;

        }
        public Producto(int id,string nombre, Marca marca, double precio)
        {
            IdProducto = id;
            Nombre = nombre;
            Marca = marca;
            Precio = precio;
        }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public double Precio { get; set; }
    }
}
