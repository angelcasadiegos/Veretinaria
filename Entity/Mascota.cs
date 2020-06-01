using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Mascota
    {
        public  string Codigo { get; set; }
        public string NombreMascota { get; set; }
        public string IdCliente { get; set; }
        public string TipoMascota { get; set; }
      
        public string Color { get; set; }
        public string laRaza { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Mascota(string codigo,string nombreMascota, DateTime fechaNacimiento, string laRaza, string idcliente,string color,string tipomascota)
        {
            Codigo = codigo;
            NombreMascota = nombreMascota;
            this.FechaNacimiento = fechaNacimiento;
            this.laRaza = laRaza;
            IdCliente = idcliente;
            Color = color;
            TipoMascota = tipomascota;
        }

        public Mascota()
        {
    
        }
    }
}
