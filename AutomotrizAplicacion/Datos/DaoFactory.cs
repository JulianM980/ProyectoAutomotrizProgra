using AutomotrizAplicacion.Datos.Implementaciones;
using AutomotrizAplicacion.Datos.Interfaces;
using AutomotrizAplicacion.Fachada;
using AutomotrizAplicacion.Servicios.Implementaciones;
using AutomotrizAplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos
{
    public class DaoFactory : AbstractDaoFactory
    {
        public override IClientesDao CrearClienteDao()
        {
            return new ClientesDao();
        }

        public override IDataClientes CrearDatosClientes()
        {
            return new DataClientes();
        }

        public override IDataApi CrearDatosFactura()
        {
            return new DataApiImp();
        }

        public override IFacturaDao CrearFacturaDao()
        {
            return new FacturaDao();

        }
    }
}
