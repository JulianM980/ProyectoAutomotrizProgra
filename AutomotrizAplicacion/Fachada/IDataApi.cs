using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public interface IDataApi
    {
        List<Factura> ObtenerFacturas();
        List<Factura> ObtenerAlgunas(int anio);
        Factura ObtenerUna(int id);
        

        List<Producto> ObtenerProductos(string marca);
        List<Marca> ObtenerMarcas();
        List<Vendedor> ObtenerVendedores();

        bool GuardarFacturas(Factura factura);
        bool ActualizarFactura(Factura factura);
        bool BajaFactura(int idFactura);
    }
}
