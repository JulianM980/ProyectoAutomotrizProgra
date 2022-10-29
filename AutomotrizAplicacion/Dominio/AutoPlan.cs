using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotrizAplicacion.Dominio
{
    public class AutoPlan
    {
        public AutoPlan()
        {
            IdAutoPlan = -1;
            CantidadCuotas = 0;
            Interes = 0;
            FechaInicio = DateTime.Today;
        }
        public AutoPlan(int idAutoPlan, int cantidadCuotas, double interes, DateTime fechaInicio)
        {
            IdAutoPlan = idAutoPlan;
            CantidadCuotas = cantidadCuotas;
            Interes = interes;
            FechaInicio = fechaInicio;
        }

        public int IdAutoPlan { get; set; }
        public int CantidadCuotas { get; set; }
        public double Interes { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
