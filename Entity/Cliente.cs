using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente : Persona
    {
      public DateTime FechaRegistro {get;set;}
      public List<Mascota> mascotas {get;set;}

        public Cliente(DateTime fechaRegistro, string identificacion, string nombre, string apellidos, string telefono, string correo, string direccion)
            :base( identificacion,nombre, apellidos, telefono, correo,direccion)
        {
            FechaRegistro = fechaRegistro;
           
        }

        public Cliente()
        {

        }
    }
}
