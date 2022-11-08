using AutomotrizAplicacion.Datos;
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
            dao = new DaoFactory().CrearClienteDao();
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            return dao.Actualizar(cliente);
        }

        public bool BajaLogicaCliente(int idCliente)
        {
            return dao.BajaLogica(idCliente);
        }

        public bool ComprobarCredenciales(string user, string pass)
        {
            return dao.ComprobarCredenciales(user, pass);
        }

        public bool InsertarCliente(Cliente cliente)
        {
            return dao.Insertar(cliente);
        }

        public List<Cliente> ObtenerClientes()
        {
            return dao.Obtener();
        }

        public List<Cliente> ObtenerClientesPorTipo(int idTipo)
        {
            return dao.ObtenerClientePorTipo(idTipo);
        }

        public List<TipoCliente> ObtenerTiposClientes()
        {
            return dao.ObtenerTiposClientes();
        }

        public List<TipoDoc> ObtenerTiposDoc()
        {
            return dao.ObtenerTiposDoc();
        }

        public Cliente ObtenerUno(int id)
        {
            return dao.ObtenerUno(id);
        }
    }
}
