using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Vendedor : Persona
    {
        public Vendedor(int id, string nombreC, string dni, string nroTel, string email, string calle, int altura, int codPostal, int tipoDoc,string nombre,string apellido, int idVendedor, DateTime fechaIngreso, DateTime fechaBaja)
            :base(id,nombreC,dni,nroTel,email,calle,altura,codPostal,codPostal,nombre,apellido)
        {
            IdVendedor = idVendedor;
            FechaIngreso = fechaIngreso;
            FechaBaja = fechaBaja;
        }
        public Vendedor():base()
        {
            IdVendedor = -1 ;
            FechaIngreso = DateTime.Today;
            FechaBaja = DateTime.Today;
        }
        public int IdVendedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaBaja { get; set; }

    }
}
