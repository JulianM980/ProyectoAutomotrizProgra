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
            Cliente = new Cliente();
            Vendedor = new Vendedor();
            Fecha = DateTime.Today;
            OrdenPedido = new OrdenPedido();
            Plan = new AutoPlan();
            DetallesFactura = new List<DetalleDocumento>();
            Descuento = 0;
        }
        public Factura(int idFactura, Cliente cliente, Vendedor vendedor, DateTime fecha, OrdenPedido ordenPedido,AutoPlan plan, List<DetalleDocumento> detallesFactura, double descuento)
        {
            IdFactura = idFactura;
            Cliente = cliente;
            Vendedor = vendedor;
            Fecha = fecha;
            OrdenPedido = ordenPedido;
            Plan = plan;
            DetallesFactura = detallesFactura;
            Descuento = descuento;
        }

        public int IdFactura{ get; set; }
        public Cliente  Cliente{ get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public OrdenPedido OrdenPedido{ get; set; }
        public AutoPlan Plan { get; set; }
        public List<DetalleDocumento> DetallesFactura { get; set; }
        public double Descuento { get; set; }
        public void AgregarDetalle(DetalleDocumento dt) {
            DetallesFactura.Add(dt);
        }
        public void QuitarDetalle(int id) {
            DetallesFactura.RemoveAt(id);
        }
    }
}
