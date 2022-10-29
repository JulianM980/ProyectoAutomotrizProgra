using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Factura
    {
        public Factura()
        {
            IdFactura = -1;
            Cliente = null;
            Vendedor = null;
            Fecha = DateTime.Today;
            OrdenPedido = null;
            Plan = null;
            DetallesFactura = new List<DetalleDocumento>();
        }
        public Factura(int idFactura, Cliente cliente, Vendedor vendedor, DateTime fecha, OrdenPedido ordenPedido,AutoPlan plan, List<DetalleDocumento> detallesFactura)
        {
            IdFactura = idFactura;
            Cliente = cliente;
            Vendedor = vendedor;
            Fecha = fecha;
            OrdenPedido = ordenPedido;
            Plan = plan;
            DetallesFactura = detallesFactura;
        }

        public int IdFactura{ get; set; }
        public Cliente  Cliente{ get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public OrdenPedido OrdenPedido{ get; set; }
        public AutoPlan Plan { get; set; }
        public List<DetalleDocumento> DetallesFactura { get; set; }
    }
}
