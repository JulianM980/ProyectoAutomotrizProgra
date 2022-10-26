using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    internal class OrdenPedido
    {
        public OrdenPedido()
        {
            IdOrdenPedido = 0;
            FechaEntrega = DateTime.Today;
            Descripcion = "";
            DetallesOrden = new List<DetalleDocumento>(9);
        }
        public OrdenPedido(int idOrdenPedido, DateTime fechaEntrega, string descripcion, List<DetalleDocumento> detallesOrden)
        {
            IdOrdenPedido = idOrdenPedido;
            FechaEntrega = fechaEntrega;
            Descripcion = descripcion;
            DetallesOrden = 
            DetallesOrden = detallesOrden;
        }

        public int IdOrdenPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }
        public List<DetalleDocumento> DetallesOrden { get; set; }
    }
}
