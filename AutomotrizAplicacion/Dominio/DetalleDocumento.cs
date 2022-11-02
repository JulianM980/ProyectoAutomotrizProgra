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
            PrecioUnitario = 0;
            Cantidad = 0;
            Producto = new Producto();

        }
        public DetalleDocumento( double precioUnitario, int cantidad, Producto producto)
        {
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            Producto = producto;
        }

        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
    }
}
