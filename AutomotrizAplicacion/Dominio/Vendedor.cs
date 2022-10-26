using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    internal class Vendedor : Persona
    {
        public Vendedor(int id, string nombre, string apellido, string dni, string nroTel, string email, string calle, int altura, int codPostal, int tipoDoc, int idVendedor, DateTime fechaIngreso, DateTime fechaBaja)
            :base(id,nombre,apellido,dni,nroTel,email,calle,altura,codPostal,codPostal)
        {
            IdVendedor = idVendedor;
            FechaIngreso = fechaIngreso;
            FechaBaja = fechaBaja;
        }

        public int IdVendedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }

    }
}
