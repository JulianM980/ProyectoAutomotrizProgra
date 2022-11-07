using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class TipoDoc
    {
        public TipoDoc()
        {
            Id = 0;
            Tipo = "";
        }
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
