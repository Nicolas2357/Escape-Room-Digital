namespace Escape_Room_Digital.UserControls
{
    public partial class AcertijoUserControl : UserControl
    {
        protected Form1 _form;
        protected Acertijo _acertijo;

        public void SetForm(Form1 form)
        {
            _form = form;
        }

        public AcertijoUserControl()
        {
            InitializeComponent();
        }

        protected void Validar(string respuesta)
        {
            bool correcto = _acertijo.ResolverRespuesta(respuesta);

            if (correcto)
            {
                AlCorrecto();
            }
            else if (_acertijo.Intentos == 0)
            {
                AlIncorrecto();
            }
            else
            {
                MessageBox.Show($"Incorrecto. Te quedan {_acertijo.Intentos} intentos.");
            }
        }
        protected virtual void AlCorrecto()
        {
            MessageBox.Show("¡Respuesta Correcta! Has resuelto el acertijo.");
            AlResolver();
        }
        protected virtual void AlIncorrecto()
        {
            MessageBox.Show("Respuesta Incorrecta. Game Over.");
            _form.MostrarUserControl(new MenuUserControl());
        }
        protected virtual void AlResolver()
        {
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void AcertijoUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}