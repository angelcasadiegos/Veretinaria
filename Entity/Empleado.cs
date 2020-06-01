using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Empleado : Persona
    {
        public string Cargo { get; set; }
        public DateTime FechaIngreso {get;set;}

        public Empleado(string identificacion, string cargo , DateTime fechaIngreso, string cedula, string nombre, string apellidos, string telefono, string email)
            : base(identificacion,cedula, nombre, apellidos, telefono, email )
        {
       
        }

        public Empleado()
        {

        }
    }
}
