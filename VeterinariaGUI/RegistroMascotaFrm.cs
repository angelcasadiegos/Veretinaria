using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entity;
using System.Configuration;

namespace VeterinariaGUI
{
    public partial class RegistroMascotaFrm : Form
    {
        MascotaService mascotaService;

        public RegistroMascotaFrm()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["desktop-2hfrprb"].ConnectionString;
            mascotaService = new MascotaService(connectionString);

            InitializeComponent();
        }

        private void MinimizarBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void RegistroMascotaFrm_Load(object sender, EventArgs e)
        {

        }

        private void GuardarMascotaBtn_Click(object sender, EventArgs e)
        {
            Mascota mascota = MapearMascota();
            string mensaje = mascotaService.Guardar(mascota);
            MessageBox.Show(mensaje);


        }

        private Mascota MapearMascota()
        {
            Mascota mascota = new Mascota();
            mascota.Codigo = CodigoMascotatxt.Text;
            mascota.IdCliente = IdClientetxt.Text;
            mascota.TipoMascota = TipoMascotacmb.Text;
            mascota.NombreMascota = nombretxt.Text;
            mascota.laRaza = raxatxt.Text;
            mascota.Color = colortxt.Text;
            mascota.FechaNacimiento = datemascota.Value;
            return mascota;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string codigo = CodigoMascotatxt.Text;
            if (codigo != "")
            {
                ResponseMascotaBusqueda respuesta = mascotaService.Buscar(codigo);
                if (respuesta.mascota != null)
                {
                    codigo = CodigoMascotatxt.Text;
                    var mensaje = mascotaService.Eliminar(codigo);
                    MessageBox.Show(mensaje, "Confirmacion de ELiminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"La persona con la identificación {codigo} no se encuentra registrada");
                }


            }
        }

        private void CANCELARBTN_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void LIMPIAR_Click(object sender, EventArgs e)
        {
            CodigoMascotatxt.Text = "";
            nombretxt.Text = "";
            IdClientetxt.Text = "";
            TipoMascotacmb.Text = "";
            raxatxt.Text = "";
            colortxt.Text = "";


        }

        private void BuscarMascotaBtn_Click(object sender, EventArgs e)
        {
            ResponseMascotaBusqueda respuesta = new ResponseMascotaBusqueda();
            string codigo = CodigoMascotatxt.Text;

            if (codigo != "")
            {
                respuesta = mascotaService.Buscar(codigo);

                if (respuesta.mascota != null)
                {
                    CodigoMascotatxt.Text = respuesta.mascota.Codigo;
                    nombretxt.Text =respuesta.mascota.NombreMascota;
                    IdClientetxt.Text = respuesta.mascota.IdCliente;
                    TipoMascotacmb.Text = respuesta.mascota.TipoMascota;
                    raxatxt.Text = respuesta.mascota.laRaza;
                    colortxt.Text = respuesta.mascota.Color;

                }
                else
                {
                    MessageBox.Show($"El cliente con la identificación {codigo} no se encuentra registrada");
                }

            }
            else
            {
                MessageBox.Show("digite una identificacion a buscar");
            }
        }

        private void ModificarMascotaBtn_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Está seguro de Modificar la información", "Mensaje de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Mascota mascota = MapearMascota();
                string mensaje = mascotaService.Modificar(mascota);

                MessageBox.Show("mascota Modificada Correctamente");
            }
        }
    }
}

