using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Fachada
{
    public interface IDataUser
    {
        bool ComprobarCredenciales(string user, string pass);

    }
}
