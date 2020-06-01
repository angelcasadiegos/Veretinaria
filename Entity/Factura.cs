using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Factura

    {

        public Factura(Cliente cliente, Empleado empleado) {
            Cliente = cliente;
            Empleado = empleado;

        }
        public string IdEmpleado { get; set; }
        public string IdCliente {get; set;}
        public string NroComprobante {get; set;}
        public DateTime FechaEmision { get; set; }
        public string Codigo { get; set; }

        public decimal Subtotal { get { return detallesFactura.Sum(d => d.ValorTotal); } }

        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public string TipoDocumento { get; set; }
       
        public List<DetalleFactura> detallesFactura { get; set; }

        public void AgregarDetalleFactura(DetalleFactura detalleFactura)
        {
             detallesFactura.Add(detalleFactura);
        }
   
        public decimal Descuento

        {
        
            get { return detallesFactura.Sum(d => d.Descuento); }

        }


        public decimal Total
        {
            get
            {
                return (Descuento > 0) ? Subtotal - Descuento : Subtotal;
            }
        }




    }
}


   
