using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Cliente: Persona
    {
        public Cliente(int id, string nombre, string apellido, string dni, string nroTel, string email, string calle, int altura, int codPostal, int tipoDoc,int idCliente, int tipoCliente, bool estado)
            :base(id,nombre,apellido,dni,nroTel,email,calle,altura,codPostal,tipoDoc)
        {
            IdCliente = idCliente;
            TipoCliente = tipoCliente;
            Estado = estado;
        }

        public int IdCliente { get; set; }
        public int TipoCliente { get; set; }
        public bool Estado { get; set; }
    }
}
