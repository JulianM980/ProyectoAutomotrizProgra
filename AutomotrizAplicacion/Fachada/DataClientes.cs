using AutomotrizAplicacion.Datos.Implementaciones;
using AutomotrizAplicacion.Datos.Interfaces;
using AutomotrizAplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public class DataClientes : IDataClientes
    {
        private IClientesDao dao;
        public DataClientes()
        {
            //inyeccion
            dao = new ClientesDao();
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogicaCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarCredenciales(string user, string pass)
        {
            return dao.ComprobarCredenciales(user, pass);
        }

        public bool InsertarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerClientes()
        {
            return dao.Obtener();
        }
    }
}
