using AutomotrizAplicacion.Datos;
using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Servicios.Interfaces;
using RecetasSLN.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Servicios.Implementaciones
{
    internal class FacturaDao : IFacturaDao
    {
        public bool Actualizar(Factura factura)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(int idFactura)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Factura factura)
        {
            List<Parametro> pMaestro = new List<Parametro>();
            pMaestro.Add(new Parametro("@idCliente",factura.Cliente.IdCliente));
            pMaestro.Add(new Parametro("@idVendedor",factura.Vendedor.IdVendedor));
            pMaestro.Add(new Parametro("@fecha",factura.Fecha));
            pMaestro.Add(new Parametro("@idOrdenPedido",factura.OrdenPedido.IdOrdenPedido));
            pMaestro.Add(new Parametro("@idAutoPlan",factura.Plan.IdAutoPlan));
            pMaestro.Add(new Parametro("@descuento",factura.Descuento));

            

            return HelperDB.ObtenerInstancia().InsertarFactura("INS_FACTURA",pMaestro,"@id", "INS_DETALLE_FACTURA", factura);
        }

        public List<Factura> Obtener()
        {
            List<Factura> facturas = new List<Factura>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("OBTENER_FACTURAS");
            foreach (DataRow row in dt.Rows) { 
                Factura factura = new Factura();
                factura.IdFactura = Convert.ToInt16(row["idFactura"]);
                factura.Cliente.Apellido = row["apellido"].ToString();
                factura.Cliente.Nombre = row["nombre"].ToString();
                factura.Fecha = Convert.ToDateTime(row["fecha"]);

                facturas.Add(factura);
            }
            return facturas;
        }

      

        

        public List<Marca> ObtenerMarcas()
        {
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("SP_MARCAS");
            List<Marca> lst = new List<Marca>();
            foreach (DataRow row in dt.Rows) { 
                Marca m = new Marca();
                m.IdMarca = Convert.ToInt16(row["idMarca"]);
                m.Nombre = row["nombre"].ToString();
                lst.Add(m);
            }
            return lst;
        }

        public List<Producto> ObtenerProductos(string marca)
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@marca", marca));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("SP_PRODUCTOS", lst);
            List<Producto> prod = new List<Producto>();
            foreach (DataRow row in dt.Rows)
            {
                Producto p = new Producto();
                p.IdProducto = Convert.ToInt16(row["idProducto"]);
                p.Nombre = row["nombre"].ToString();
                p.Precio = Convert.ToDouble(row["preUnitario"]);
                prod.Add(p);
            }
            return prod;
        }
    }
}
