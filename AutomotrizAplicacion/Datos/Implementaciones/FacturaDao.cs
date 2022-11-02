using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Servicios.Interfaces;
using RecetasSLN.datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public List<Factura> Obtener()
        {
            List<Factura> facturas = new List<Factura>();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSp("OBTENER_FACTURAS");
            foreach (DataRow row in dt.Rows) { 
                Factura factura = new Factura();
                factura.IdFactura = Convert.ToInt16(row["idFactura"]);
                factura.Cliente.Apellido
                factura.Cliente.Nombre
            }
        }
    }
}
