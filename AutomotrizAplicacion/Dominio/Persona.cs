using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class Persona
    {
        public Persona()
        {
            Id = -1;
            Nombre = "";
            Apellido = "";
            Dni = "";
            NroTel = "";
            Email = "";
            Calle = "";
            Altura = -1;
            CodPostal = -1;
            TipoDoc = -1;
        }
        public Persona(int id, string nombre, string apellido, string dni, string nroTel, string email, string calle, int altura, int codPostal, int tipoDoc)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            NroTel = nroTel;
            Email = email;
            Calle = calle;
            Altura = altura;
            CodPostal = codPostal;
            TipoDoc = tipoDoc;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string NroTel { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int CodPostal { get; set; }
        public int TipoDoc { get; set; }
    }
}
