using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DetalleFactura
    {
        public DetalleFactura( Servicio servicio, decimal descuento)
        {
            Servicio = servicio;
            ValorTotal = Servicio.PrecioServicio;
            Descuento = descuento;
        }

        public string Codigo { get; set; }
        public string idServicio { get; set; }
        public decimal Descuento { get; set; }
        public Servicio Servicio { get; set; }
        public decimal ValorTotal { get; set; }



    }
}
