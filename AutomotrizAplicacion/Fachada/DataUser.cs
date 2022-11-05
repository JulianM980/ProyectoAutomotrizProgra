using AutomotrizAplicacion.Datos.Implementaciones;
using AutomotrizAplicacion.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomotrizAplicacion.Fachada
{
    public class DataUser : IDataUser
    {
        private IUsuariosDao dao;
        public DataUser()
        {
            dao = new UsuariosDao();
        }
        public bool ComprobarCredenciales(string user, string pass)
        {
            return dao.ComprobarCredenciales(user, pass);
        }
    }
}
