﻿using AutomotrizAplicacion.Dominio;
using AutomotrizAplicacion.Servicios.Implementaciones;
using AutomotrizAplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public class DataApiImp : IDataApi
    {
        private IFacturaDao dao;
        public DataApiImp()
        {
            //inyeccion de dependencias
            dao = new FacturaDao();
        }
        public bool ActualizarFactura(Factura factura)
        {
            return dao.Actualizar(factura);
        }

        public bool BajaFactura(int idFactura)
        {
            return dao.BajaLogica(idFactura);
        }

        public bool GuardarFacturas(Factura factura)
        {
            return dao.Insertar(factura);
        }

        public List<Producto> ObtenerProductos(string marca)
        {
            return dao.ObtenerProductos(marca);
        }

        public List<Factura> ObtenerFacturas()
        {
            return dao.Obtener();
        }

        public List<Marca> ObtenerMarcas()
        {
            return dao.ObtenerMarcas();
        }
    }
}
