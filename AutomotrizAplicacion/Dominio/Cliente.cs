using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Cliente: Persona
    {
        public Cliente(int id, string nombreC, string dni, string nroTel, string email, string calle, int altura, int codPostal, int tipoDoc,string apellido,string nombre, int idCliente, TipoCliente tipoCliente, bool estado)
            : base(id, nombreC, dni, nroTel, email, calle, altura, codPostal, tipoDoc,apellido,nombre)
        {
            IdCliente = idCliente;
            TipoCliente = tipoCliente;
            Estado = estado;
        }
        public Cliente() : base()
        {
            IdCliente = -1;
            TipoCliente = new TipoCliente();
            Estado = false;
        }

        public int IdCliente { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public bool Estado { get; set; }
    }
}
