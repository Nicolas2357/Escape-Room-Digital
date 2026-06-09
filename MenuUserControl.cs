using Escape_Room_Digital.Idiomas;
using System.Drawing;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class MenuUserControl : UserControl, ITraducible
    {
        private Form1 _form;

        public void SetForm(Form1 form)
        {
            _form = form;
        }

        public MenuUserControl()
        {
            InitializeComponent();
            RegistrarHoverBotones(btnJugar, btnConfiguración, btnSalir, btnAdministrador);
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            VerificarPartidas();
            AplicarTraduccion();
        }
        private void VerificarPartidas()
        {
            var slots = GestorDePartidas.Instancia.CargarSlots();
        }

        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            btnJugar.Text = G.Obtener("menu.jugar");
            btnConfiguración.Text = G.Obtener("menu.configuracion");
            btnSalir.Text = G.Obtener("menu.salir");
            btnAdministrador.Text = G.Obtener("menu.administrador");
            label1.Text = G.Obtener("menu.titulo");
        }
        public new bool Focus()
        {
            if (btnJugar != null)
            {
                _indice = 0;
                ActualizarSeleccion();
                return true;
            }
            return base.Focus();
        }

        private void btnJugar_Click(object sender, EventArgs e) =>
            _form.MostrarUserControl(new SeleccionSlotUserControl()); private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void btnConfiguración_Click(object sender, EventArgs e) => _form.MostrarUserControl(new ConfiguracionUserControl());
        private void btnAdministrador_Click(object sender, EventArgs e) => _form.MostrarUserControl(new AdministradorUserControl());

        private void RegistrarHoverBotones(params Button[] botones)
        {
            foreach (var btn in botones)
            {
                btn.MouseEnter += (s, e) => btn.ForeColor = Color.Yellow;
                btn.MouseLeave += (s, e) => btn.ForeColor = Color.White;
            }
        }

        private int _indice = 0;
        private Button[] Botones => new[] { btnJugar, btnConfiguración, btnSalir, btnAdministrador };

        private void ActualizarSeleccion()
        {
            foreach (var btn in Botones)
                btn.ForeColor = Color.White;
            Botones[_indice].ForeColor = Color.Yellow;
            Botones[_indice].Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (_indice == Botones.Length - 1) return true; 
                _indice++;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Up)
            {
                if (_indice == 0) return true; 
                _indice--;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                Botones[_indice].PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}