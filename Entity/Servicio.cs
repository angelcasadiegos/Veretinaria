using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Servicio
    {
       public  string CodigodeServicio {get;set;}
       public string NombreServicio {get; set;}    
       public decimal PrecioServicio {get;set;}
       
  
     public Servicio()
        {

        }

        public Servicio(string codigoservicio, string nombreservicio, decimal precioServicio)
        { 
            CodigodeServicio = codigoservicio;
            NombreServicio = nombreservicio;
            
        
            
        }

        
    }
}
