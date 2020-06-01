using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinariaGUI
{
    public partial class from : Form
    {
        public from()
        {
            InitializeComponent();
        }

        private void CerrarBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizarBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuVeterinarioFrm menuVeterinarioFrm = new MenuVeterinarioFrm();
            menuVeterinarioFrm.Show();
        }

        private void from_Load(object sender, EventArgs e)
        {

        }

        private void CitasBtn_Click(object sender, EventArgs e)
        {
          
         
        }

        private void ClienteBtn_Click(object sender, EventArgs e)
        {
            MenuClientesFrm menuClientesFrm = new MenuClientesFrm();
            menuClientesFrm.Show();
        }

        private void PasientesBtn_Click(object sender, EventArgs e)
        {
            MenuMascotasFrm menuMascotasFrm = new MenuMascotasFrm();
            menuMascotasFrm.Show();
        }

        private void ServiciosBtn_Click(object sender, EventArgs e)
        {
            MenuServiciosFrm ServicioFrm = new MenuServiciosFrm();
           ServicioFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {   FacturarServiciosFrm FacturarServicioFrm = new FacturarServiciosFrm();
            FacturarServicioFrm.Show();
        }
    }
}
