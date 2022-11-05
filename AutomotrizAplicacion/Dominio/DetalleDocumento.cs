using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class DetalleDocumento
    {
        public DetalleDocumento()
        {
            Cantidad = 0;
            Producto = new Producto();

        }
        public DetalleDocumento(  int cantidad, Producto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
        }

        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public double CalcularSubTotal()
        {
            return Producto.Precio * Cantidad;
        }
    }
}
