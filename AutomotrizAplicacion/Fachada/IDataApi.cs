using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public interface IDataApi
    {
        List<Factura> ObtenerFacturas();
        List<Producto> ObtenerProductos(string marca);
        List<Marca> ObtenerMarcas();
        bool GuardarFacturas(Factura factura);
        bool ActualizarFactura(Factura factura);
        bool BajaFactura(int idFactura);
    }
}
