using Escape_Room_Digital.Idiomas;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class ConfiguracionUserControl : UserControl, ITraducible
    {
        private Form1 _form;
        public event Action? OnRegresar;
        private Panel _panelTrackBar;
        private int _foco = 0;
        private bool _editando = false;

        public void SetForm(Form1 form)
        {
            _form = form;
        }

        public ConfiguracionUserControl()
        {
            InitializeComponent();
            CargarConfiguracion();
            CargarIdiomas();
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();

            _panelTrackBar = new Panel();
            _panelTrackBar.Location = new Point(trackBarVolumen.Left - 3, trackBarVolumen.Top - 3);
            _panelTrackBar.Size = new Size(trackBarVolumen.Width + 6, trackBarVolumen.Height + 6);
            _panelTrackBar.BackColor = Color.Transparent;
            this.Controls.Add(_panelTrackBar);
            _panelTrackBar.BringToFront();
            trackBarVolumen.BringToFront();
            _panelTrackBar.Paint += (s, e) =>
            {
                if (_foco == 2)
                {
                    using (Pen pen = new Pen(Color.Yellow, 3))
                        e.Graphics.DrawRectangle(pen, 1, 1, _panelTrackBar.Width - 3, _panelTrackBar.Height - 3);
                }
            };

            ActualizarSeleccion();
        }

        private void ActualizarSeleccion()
        {
            btnGuardar.ForeColor = Color.White;
            btnRegresar.ForeColor = Color.White;
            _panelTrackBar.Invalidate();

            switch (_foco)
            {
                case 0: btnGuardar.ForeColor = Color.Yellow; btnGuardar.Focus(); break;
                case 1: btnRegresar.ForeColor = Color.Yellow; btnRegresar.Focus(); break;
                case 2: trackBarVolumen.Focus(); break;
                case 3: cmbIdioma.Focus(); break;
            }
            _editando = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_editando)
            {
                if (keyData == Keys.Escape) { _editando = false; ActualizarSeleccion(); return true; }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            switch (_foco)
            {
                case 0: // guardar
                    if (keyData == Keys.Right) { _foco = 1; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Up) { _foco = 2; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { btnGuardar.PerformClick(); return true; }
                    return true;

                case 1: // regresar
                    if (keyData == Keys.Left) { _foco = 0; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Up) { _foco = 3; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { btnRegresar.PerformClick(); return true; }
                    return true;

                case 2: // trackbar
                    if (keyData == Keys.Down) { _foco = 0; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Right) { _foco = 3; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { _editando = true; trackBarVolumen.Focus(); return true; }
                    return true;

                case 3: // combobox
                    if (keyData == Keys.Down) { _foco = 1; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Left) { _foco = 2; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { _editando = true; cmbIdioma.Focus(); return true; }
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CargarConfiguracion()
        {
            trackBarVolumen.Minimum = 0;
            trackBarVolumen.Maximum = 100;
            trackBarVolumen.Value = Properties.Settings.Default.Volumen;
            lblVolumen.Text = trackBarVolumen.Value.ToString();
        }

        private void CargarIdiomas()
        {
            cmbIdioma.DataSource = GestorDeIdiomas.IdiomasDisponibles
                .Select(i => new { i.Codigo, i.Nombre })
                .ToList();
            cmbIdioma.DisplayMember = "Nombre";
            cmbIdioma.ValueMember = "Codigo";
            cmbIdioma.SelectedIndexChanged -= cmbIdioma_SelectedIndexChanged;
            cmbIdioma.SelectedValue = GestorDeIdiomas.Instancia.IdiomaActual;
            cmbIdioma.SelectedIndexChanged += cmbIdioma_SelectedIndexChanged;
        }

        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            lblIdioma.Text = G.Obtener("config.idioma");
            label1.Text = G.Obtener("config.volumen");
            btnGuardar.Text = G.Obtener("config.guardar");
            btnRegresar.Text = G.Obtener("config.regresar");
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

        private void btnGuardar_MouseEnter(object sender, EventArgs e) => btnGuardar.ForeColor = Color.Yellow;
        private void btnGuardar_MouseLeave(object sender, EventArgs e) => btnGuardar.ForeColor = Color.White;
        private void btnRegresar_MouseEnter(object sender, EventArgs e) => btnRegresar.ForeColor = Color.Yellow;
        private void btnRegresar_MouseLeave(object sender, EventArgs e) => btnRegresar.ForeColor = Color.White;

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedValue is string codigo)
                GestorDeIdiomas.Instancia.EstablecerIdioma(codigo);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void ConfiguracionUserControl_Load(object sender, EventArgs e) { }
    }
}