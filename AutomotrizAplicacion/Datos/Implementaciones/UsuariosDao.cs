using AutomotrizAplicacion.Datos.Interfaces;
using RecetasSLN.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos.Implementaciones
{
    internal class UsuariosDao: IUsuariosDao
    {
        public bool ComprobarCredenciales(string user, string pass)
        {
            return HelperDB.ObtenerInstancia().Login(user, pass, "comprobar_credenciales");
        }
    }
}
