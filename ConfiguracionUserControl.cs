using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class ConfiguracionUserControl : UserControl
    {
        private Form1 _form;
        public event Action? OnRegresar;
        public void SetForm(Form1 form)
        {
            _form = form;
        }
        public ConfiguracionUserControl()
        {
            InitializeComponent();
            CargarConfiguracion();
        }
        private void CargarConfiguracion()
        {
            trackBarVolumen.Minimum = 0;
            trackBarVolumen.Maximum = 100;
            trackBarVolumen.Value = Properties.Settings.Default.Volumen;
            lblVolumen.Text = trackBarVolumen.Value.ToString();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void trackBarVolumen_Scroll(object sender, EventArgs e)
        {
            lblVolumen.Text = trackBarVolumen.Value.ToString();
            AudioManager.AplicarVolumen(trackBarVolumen.Value);
        }

        private void GuardarConfiguracion()
        {
            Properties.Settings.Default.Volumen = trackBarVolumen.Value;
            Properties.Settings.Default.Save();
            OnRegresar?.Invoke();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void btnVolver_MouseEnter(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.Yellow;
        }

        private void btnVolver_MouseLeave(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.White;
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.ForeColor = Color.Yellow;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.ForeColor = Color.White;
        }

        private void btnRegresar_MouseEnter(object sender, EventArgs e)
        {
            btnRegresar.ForeColor = Color.Yellow;
        }

        private void btnRegresar_MouseLeave(object sender, EventArgs e)
        {
            btnRegresar.ForeColor = Color.White;
        }

        private void ConfiguracionUserControl_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
