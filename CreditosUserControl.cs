using Escape_Room_Digital.Idiomas;
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
    public partial class CreditosUserControl : UserControl, ITraducible
    {
        private int _puntuacion;
        private Form1 _form1;


        public CreditosUserControl()
        {
            InitializeComponent();

            int TiempoTotal = EstadoDeJuego.TiempoRestanteNerd + EstadoDeJuego.TiempoRestanteGhost + EstadoDeJuego.TiempoRestanteShortSkeleton + EstadoDeJuego.TiempoRestanteNerd2;

            int Puntuacion = TiempoTotal * 1000;

            lblPuntuacion.Text = string.Format(GestorDeIdiomas.Instancia.Obtener("creditos.puntuacion"), Puntuacion);
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
        }
        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            btnSalir.Text = G.Obtener("creditos.btn.salir");
            label1.Text = G.Obtener("creditos.gracias");
            lblPuntuacion.Text = string.Format(G.Obtener("creditos.puntuacion"),
                (EstadoDeJuego.TiempoRestanteNerd + EstadoDeJuego.TiempoRestanteGhost +
                 EstadoDeJuego.TiempoRestanteShortSkeleton + EstadoDeJuego.TiempoRestanteNerd2) * 1000);
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

        private void CreditosUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
