using AutomotrizAplicacion.Datos.Interfaces;
using AutomotrizAplicacion.Fachada;
using AutomotrizAplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos
{
    public abstract class AbstractDaoFactory
    {
        public abstract IFacturaDao CrearFacturaDao();
        public abstract IClientesDao CrearClienteDao();
        public abstract IDataApi CrearDatosFactura();
        public abstract IDataClientes CrearDatosClientes();
    }
}
