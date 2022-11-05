using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Datos.Interfaces
{
    internal interface IUsuariosDao
    {
        bool ComprobarCredenciales(string user, string pass);

    }
}
