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
                factura.Cliente.NombreCompleto = row["nombre_completo"].ToString();
                factura.Fecha = Convert.ToDateTime(row["fecha"]);

                facturas.Add(factura);
            }
            return facturas;
        }

        public List<Factura> ObtenerAlgunas(int anio)
        {
            List<Factura> facturas = new List<Factura>();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@anio",anio));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("obt_facturas_anio",lst);
            foreach (DataRow row in dt.Rows)
            {
                Factura factura = new Factura();
                factura.IdFactura = Convert.ToInt16(row["idFactura"]);
                factura.Cliente.NombreCompleto = row["nombre_completo"].ToString();
                factura.Fecha = Convert.ToDateTime(row["fecha"]);

                facturas.Add(factura);
            }
            return facturas;
        }

      

        public List<Marca> ObtenerMarcas()
        {
            List<Marca> lst = new List<Marca>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("SP_MARCAS");
            if (dt == null) return lst;
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

        public Factura ObtenerUna(int id)
        {
            Factura factura = new Factura();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@id", id));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("obt_factura", lst);
            bool primero = true;
            foreach (DataRow row in dt.Rows)
            {
                if (primero) { 
                    factura.IdFactura = Convert.ToInt16(row["idFactura"]);
                    factura.Cliente.IdCliente = Convert.ToInt16(row["idCliente"]);
                    factura.Cliente.NombreCompleto = row["nombre_completo"].ToString();
                    factura.Vendedor.IdVendedor = Convert.ToInt16(row["idVendedor"]);
                    factura.Vendedor.NombreCompleto = row["nombre_completo_v"].ToString();
                    if (row["idOrdenPedido"] == DBNull.Value) factura.OrdenPedido.IdOrdenPedido = 0;
                    else factura.OrdenPedido.IdOrdenPedido = Convert.ToInt16(row["idOrdenPedido"]);
                    if (row["idAutoPlan"] == DBNull.Value) factura.Plan.IdAutoPlan = 0;
                    else factura.Plan.IdAutoPlan = Convert.ToInt16(row["idAutoPlan"]);
                    factura.Fecha = Convert.ToDateTime(row["fecha"]);
                    factura.Descuento = Convert.ToDouble(row["descuento"]);
                    primero = false;
                }
                DetalleDocumento df = new DetalleDocumento();
                df.Cantidad = Convert.ToInt32(row["cantidad"]);
                df.Producto.IdProducto = Convert.ToInt32(row["idProducto"]);
                df.Producto.Precio = Convert.ToInt32(row["preunitario"]);
                df.Producto.Nombre = row["nom_producto"].ToString();
                factura.AgregarDetalle(df);

               
            }
            return factura;
        }

        public List<Vendedor> ObtenerVendedores()
        {
            List<Vendedor> vendedores = new List<Vendedor>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("OBT_VENDEDORES");
            if (dt == null) return vendedores;
            foreach (DataRow row in dt.Rows)
            {
                Vendedor vendedor = new Vendedor();
                vendedor.IdVendedor = Convert.ToInt16(row["idVendedor"]);
                vendedor.NombreCompleto = row["nombre_completo"].ToString();
                vendedor.Dni = row["documento"].ToString();
                vendedor.NroTel = row["nroTel"].ToString();
                vendedor.Email = row["email"].ToString();
                vendedor.Calle = row["calle"].ToString();
                vendedor.Altura = Convert.ToInt32(row["altura"]);
                vendedor.CodPostal = Convert.ToInt32(row["codPostal"]);
                vendedor.TipoDoc = Convert.ToInt32(row["idTipoDoc"]);

                vendedores.Add(vendedor);
            }
            return vendedores;
        }
    }
}
