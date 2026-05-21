using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class CreditosUserControl : UserControl
    {
        private int _puntuacion;
        private Form1 _form1;


        public CreditosUserControl()
        {
            InitializeComponent();

            int TiempoTotal = EstadoDeJuego.TiempoRestanteNerd + EstadoDeJuego.TiempoRestanteGhost + EstadoDeJuego.TiempoRestanteShortSkeleton + EstadoDeJuego.TiempoRestanteNerd2;

            int Puntuacion = TiempoTotal * 1000;

            lblPuntuacion.Text = $"Puntuación: {Puntuacion}";
        }
        public void SetForm(Form1 form)
        {
            _form1 = form;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_MouseEnter(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.Yellow;
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            btnSalir.ForeColor = Color.White;
        }
    }
}
