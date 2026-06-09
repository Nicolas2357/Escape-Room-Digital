using Escape_Room_Digital.Fonts;
using Escape_Room_Digital.UserControls;

namespace Escape_Room_Digital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            MostrarUserControl(new MenuUserControl());
            this.KeyPreview = true;
        }
        private void AplicarFuente(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                c.Font = GestorFuentes.Obtener(c.Font.Size, c.Font.Style);

                if (c.HasChildren)
                    AplicarFuente(c.Controls);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.SuppressKeyPress = true;

            if (this.Controls[0] is IControlConMovimiento control)
                control.HabilitarTeclas(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.Controls[0] is IControlConMovimiento control)
                control.HabilitarTeclas(e.KeyCode, false);
        }

        public void MostrarUserControl(UserControl userControl)
        {
            this.Controls.Clear();

            if (userControl is MenuUserControl menuUserControl)
                menuUserControl.SetForm(this);
            else if (userControl is SeleccionSlotUserControl seleccionSlot)
                seleccionSlot.SetForm(this);
            else if (userControl is JugarUserControl jugarUserControl)
                jugarUserControl.SetForm(this);
            else if (userControl is GhostUserControl ghostUserControl)
                ghostUserControl.SetForm(this);
            else if (userControl is ShortSkeletonUserControl shortSkeletonUserControl)
                shortSkeletonUserControl.SetForm(this);
            else if (userControl is AcertijoUserControl acertijoUserControl)
                acertijoUserControl.SetForm(this);
            else if (userControl is ConfiguracionUserControl configuracionUserControl)
                configuracionUserControl.SetForm(this);
            else if (userControl is AdministradorUserControl administradorUserControl)
                administradorUserControl.SetForm(this);
            else if (userControl is CreditosUserControl creditosUserControl)
                creditosUserControl.SetForm(this);
            else if (userControl is NerdUserControl2 nerdUserControl2)
                nerdUserControl2.SetForm(this);
            else if (userControl is InicioDelJuegoUserControl inicioUserControl)
                inicioUserControl.SetForm(this);
            else if (userControl is JefeFinalTenna jefeFinalTenna)
                jefeFinalTenna.SetForm(this);
           
            userControl.Dock = DockStyle.Fill;
            AplicarFuente(userControl.Controls);

            this.Controls.Add(userControl);
            this.Controls.Add(userControl);

            if (userControl is IControlConMovimiento)
            {
                this.Focus();
                this.Select();
            }
            else
                userControl.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}