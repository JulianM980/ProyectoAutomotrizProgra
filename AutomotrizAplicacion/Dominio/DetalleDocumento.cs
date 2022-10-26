using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    internal class DetalleDocumento
    {
        public DetalleDocumento()
        {
            IdDetalle = -1;
            PrecioUnitario = 0;
            Cantidad = 0;
            Producto = new Producto();

        }
        public DetalleDocumento(int idDetalle, double precioUnitario, int cantidad, Producto producto)
        {
            IdDetalle = idDetalle;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
            Producto = producto;
        }

        public int IdDetalle { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
    }
}
