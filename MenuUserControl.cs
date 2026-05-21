using System.Drawing;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class MenuUserControl : UserControl
    {
        private Form1 _form;

        public void SetForm(Form1 form)
        {
            _form = form;
        }

        public MenuUserControl()
        {
            InitializeComponent();
            btnJugar.Text = AdministradorLenguaje.Traducir("menu_play");
            btnConfiguración.Text = AdministradorLenguaje.Traducir("menu_settings");
            btnSalir.Text = AdministradorLenguaje.Traducir("menu_exit");
            btnAdministrador.Text = AdministradorLenguaje.Traducir("menu_admin");
            RegistrarHoverBotones(btnJugar, btnConfiguración, btnSalir, btnAdministrador);
        }

        public new bool Focus()
        {
            if (btnJugar != null)
            {
                btnJugar.ForeColor = Color.Yellow;
                return btnJugar.Focus();
            }
            return base.Focus();
        }

        private void btnJugar_Click(object sender, EventArgs e) => _form.MostrarUserControl(new InicioDelJuegoUserControl());
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (btnJugar.Focused)
            {
                if (keyData == Keys.Down) { btnConfiguración.Focus(); btnConfiguración.ForeColor = Color.Yellow; btnJugar.ForeColor = Color.White; return true; }
                else if (keyData == Keys.Up) { btnAdministrador.Focus(); btnAdministrador.ForeColor = Color.Yellow; btnJugar.ForeColor = Color.White; return true; }
            }
            else if (btnConfiguración.Focused)
            {
                if (keyData == Keys.Down) { btnSalir.Focus(); btnSalir.ForeColor = Color.Yellow; btnConfiguración.ForeColor = Color.White; return true; }
                else if (keyData == Keys.Up) { btnJugar.Focus(); btnJugar.ForeColor = Color.Yellow; btnConfiguración.ForeColor = Color.White; return true; }
            }
            else if (btnSalir.Focused)
            {
                if (keyData == Keys.Down) { btnAdministrador.Focus(); btnAdministrador.ForeColor = Color.Yellow; btnSalir.ForeColor = Color.White; return true; }
                else if (keyData == Keys.Up) { btnConfiguración.Focus(); btnConfiguración.ForeColor = Color.Yellow; btnSalir.ForeColor = Color.White; return true; }
            }
            else if (btnAdministrador.Focused)
            {
                if (keyData == Keys.Down) { btnJugar.Focus(); btnJugar.ForeColor = Color.Yellow; btnAdministrador.ForeColor = Color.White; return true; }
                else if (keyData == Keys.Up) { btnSalir.Focus(); btnSalir.ForeColor = Color.Yellow; btnAdministrador.ForeColor = Color.White; return true; }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}