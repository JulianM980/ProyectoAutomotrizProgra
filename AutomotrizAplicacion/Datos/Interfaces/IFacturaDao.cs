using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Servicios.Interfaces
{
    internal interface IFacturaDao
    {
        List<Factura> Obtener();
        List<Producto> ObtenerProductos(string marca);
        List<Marca> ObtenerMarcas();
        bool Insertar(Factura factura);
        bool Actualizar(Factura factura);
        bool BajaLogica(int idFactura);
    }
}
