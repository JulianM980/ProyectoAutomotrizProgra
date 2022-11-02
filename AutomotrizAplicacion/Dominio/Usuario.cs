using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Usuario
    {
        public Usuario()
        {
            IdUsuario = -1;
            Nombre = "";
            Contrasenia = "";
        }
        public Usuario(int idUsuario, string nombre, string contrasenia)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Contrasenia = contrasenia;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasenia { get; set; }
    }
}
