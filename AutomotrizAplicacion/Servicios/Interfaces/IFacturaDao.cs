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
        bool InsertarFactura(Factura factura);
    }
}
