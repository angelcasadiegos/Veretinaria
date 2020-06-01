using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;
using System.Configuration;

namespace VeterinariaGUI
{
    public partial class RegistrarServicioFrm : Form
    {

        ServiciosService servicioservice;
        public RegistrarServicioFrm()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["desktop-2hfrprb"].ConnectionString;
            servicioservice = new ServiciosService(connectionString);

            InitializeComponent();
        }

        private void RegistrarServicioFrm_Load(object sender, EventArgs e)
        {

        }

        private void MinimizarBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GuardarServicioBtn_Click(object sender, EventArgs e)
        {
           Servicio servicio = MapearServicios();
            string mensaje = servicioservice.Guardar(servicio);
            MessageBox.Show(mensaje);
        }

        private Servicio MapearServicios()
        {
            Servicio servicio = new Servicio();
            servicio.CodigodeServicio = CodigoTxt.Text;
            servicio.NombreServicio = NombreTxt.Text;
            servicio.PrecioServicio =  int.Parse(preciotxt.Text);

            return servicio;
        }

        private void LimpiarServicioBtn_Click(object sender, EventArgs e)
        {
            CodigoTxt.Text = "";
            NombreTxt.Text = "";
            preciotxt.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Servicio servicio = MapearServicios();
                string mensaje = servicioservice.Modificar(servicio);

                MessageBox.Show("Servicio Modificado Correctamente");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResponseBusquedaServicio respuesta = new  ResponseBusquedaServicio();
            string codigoServicio = CodigoTxt.Text;

            if (codigoServicio != "")
            {
                respuesta = servicioservice.Buscar(codigoServicio);

                if (respuesta.servicio!= null)
                {
                    NombreTxt.Text = respuesta.servicio.NombreServicio;
                    CodigoTxt.Text = respuesta.servicio.CodigodeServicio;
                    preciotxt.Text = respuesta.servicio.PrecioServicio.ToString();
                    
                }
                else
                {
                    MessageBox.Show($"El servicio con la identificación {codigoServicio} no se encuentra registrada");
                }

            }
            else
            {
                MessageBox.Show("digite una identificacion a buscar");
            }
        }

        private void CancelarCancelarBtn_Click(object sender, EventArgs e)
        {
            string codigoServicio = CodigoTxt.Text;
            if (codigoServicio != "")
            {
                ResponseBusquedaServicio respuesta = servicioservice.Buscar(codigoServicio);
                if (respuesta.servicio != null)
                {
                    codigoServicio= CodigoTxt.Text;
                    var mensaje = servicioservice.Eliminar(codigoServicio);
                    MessageBox.Show(mensaje, "Confirmacion de ELiminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"elservicio con el codigo {codigoServicio} no se encuentra registrado");
                }


            }
        }
    }
}
