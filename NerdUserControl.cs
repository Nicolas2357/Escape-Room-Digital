using Escape_Room_Digital.Idiomas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class NerdUserControl : AcertijoUserControl, ITraducible
    {
        int segundosRestantes = 60;

        public NerdUserControl()
        {
            InitializeComponent();
            timerCronómetro.Start();
            _acertijo = new AcertijoTexto(
                "Un león se esconde en una de tres habitaciones.. \nSabiendo que solamente una de esas afirmaciones es verdadera, ¿en cuál habitación está el león?(1,2 o 3)", "3", 120
            );
            lblAcertijo.Text = GestorDeIdiomas.Instancia.Obtener("nerd.acertijo");
            lblIntentos.Text = string.Format(GestorDeIdiomas.Instancia.Obtener("nerd.intentos"), _acertijo.Intentos);
            RegistrarHoverBotones(btnValidar, btnContinuarRight, btnContinuarFail, btnVolver);
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
            ActualizarSeleccion();
        }

     
        private int _foco = 0;
        private bool _editando = false;

        private void ActualizarSeleccion()
        {
            btnValidar.ForeColor = Color.White;
            btnVolver.ForeColor = Color.White;
            btnContinuarRight.ForeColor = Color.White;
            btnContinuarFail.ForeColor = Color.White;

            // Si algún panel está visible, ese tiene prioridad
            if (pnlNerd.Visible)
            {
                btnContinuarRight.ForeColor = Color.Yellow;
                btnContinuarRight.Focus();
                return;
            }
            if (pnlNerdIncorrecto.Visible)
            {
                btnContinuarFail.ForeColor = Color.Yellow;
                btnContinuarFail.Focus();
                return;
            }

            switch (_foco)
            {
                case 0: btnValidar.ForeColor = Color.Yellow; btnValidar.Focus(); break;
                case 1: txtRespuesta.Focus(); break;
                case 2: btnVolver.ForeColor = Color.Yellow; btnVolver.Focus(); break;
            }
            _editando = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Si hay panel visible solo Enter funciona
            if (pnlNerd.Visible)
            {
                if (keyData == Keys.Enter) { btnContinuarRight.PerformClick(); return true; }
                return true; // anula todo lo demás
            }
            if (pnlNerdIncorrecto.Visible)
            {
                if (keyData == Keys.Enter) { btnContinuarFail.PerformClick(); return true; }
                return true;
            }

            if (_editando)
            {
                if (keyData == Keys.Enter) { _editando = false; ActualizarSeleccion(); return true; }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            switch (_foco)
            {
                case 0: // validar
                    if (keyData == Keys.Up) { _foco = 1; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Right) { _foco = 2; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { btnValidar.PerformClick(); return true; }
                    return true;

                case 1: // txt
                    if (keyData == Keys.Down) { _foco = 0; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { _editando = true; txtRespuesta.Focus(); return true; }
                    return true;

                case 2: // volver
                    if (keyData == Keys.Left) { _foco = 0; ActualizarSeleccion(); return true; }
                    if (keyData == Keys.Enter) { btnVolver.PerformClick(); return true; }
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            lblAcertijo.Text = G.Obtener("nerd.acertijo");
            lblIntentos.Text = string.Format(G.Obtener("nerd.intentos"), _acertijo.Intentos);
            lblPista1.Text = G.Obtener("nerd.pista1");
            lblPista2.Text = G.Obtener("nerd.pista2");
            lblPista3.Text = G.Obtener("nerd.pista3");
            label4.Text = G.Obtener("nerd.label.respuesta");
            lblDialogoNerd.Text = G.Obtener("nerd.exito");
            label5.Text = G.Obtener("nerd.fail");
            btnVolver.Text = G.Obtener("nerd.btn.volver");
            btnValidar.Text = G.Obtener("nerd.btn.validar");
            btnContinuarRight.Text = G.Obtener("nerd.btn.continuar");
            btnContinuarFail.Text = G.Obtener("nerd.btn.continuar");
        }
        private void btnValidar_Click(object sender, EventArgs e)
        {
            timerCronómetro.Stop();
            int intentosAntes = _acertijo.Intentos;
            Validar(txtRespuesta.Text);
            if (_acertijo.Intentos > 0 && _acertijo.Intentos < intentosAntes)
                lblIntentos.Text = string.Format(GestorDeIdiomas.Instancia.Obtener("nerd.intentos"), _acertijo.Intentos);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            timerCronómetro.Stop();
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void timerCronómetro_Tick(object sender, EventArgs e)
        {
            if (segundosRestantes > 0)
            {
                segundosRestantes--;
                pbTiempo.Value = segundosRestantes;
                pbTiempo.Value = segundosRestantes + 1;
                pbTiempo.Value = segundosRestantes;
                lblCronómetro.Text = string.Format("00:00:{0:00}", segundosRestantes);
            }
            else
            {
                timerCronómetro.Stop();
                pnlNerdIncorrecto.Visible = true;
            }
        }
        protected override void AlCorrecto()
        {
            timerCronómetro.Stop();
            pnlNerd.Visible = true;
            ActualizarSeleccion();
        }
        protected override void AlIncorrecto()
        {
            timerCronómetro.Stop();
            pnlNerdIncorrecto.Visible = true;
            ActualizarSeleccion();
        }
        protected override void AlResolver()
        {
            timerCronómetro.Stop();
            EstadoDeJuego.NivelNerdCompletado = true;
            EstadoDeJuego.TiempoRestanteNerd = segundosRestantes;
            EstadoDeJuego.cantidadNivelesCompletados++;
            GestorDePartidas.Instancia.GuardarEstadoActual(EstadoDeJuego.SlotActual, "JugarUserControl"); // ← agregar
        _form.MostrarUserControl(new JugarUserControl());
        }

        private void btnContinuarRight_Click(object sender, EventArgs e)
        {
            AlResolver();
        }

        private void pnlNerd_Paint(object sender, PaintEventArgs e)
        {
            DibujarBorde(e, pnlNerd);

        }

        private void btnContinuarFail_Click(object sender, EventArgs e)
        {
            timerCronómetro.Stop();
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void pnlNerdIncorrecto_Paint(object sender, PaintEventArgs e)
        {
            DibujarBorde(e, pnlNerdIncorrecto);

        }
        private void RegistrarHoverBotones(params Button[] botones)
        {
            foreach (var btn in botones)
            {
                btn.MouseEnter += (s, e) => btn.ForeColor = Color.Yellow;
                btn.MouseLeave += (s, e) => btn.ForeColor = Color.White;
            }
        }
        private void DibujarBorde(PaintEventArgs e, Panel panel)
        {
            int grosor = 3;
            using (Pen pen = new Pen(Color.White, grosor))
            {
                int offset = grosor / 2;
                e.Graphics.DrawRectangle(pen, offset, offset,
                    panel.ClientSize.Width - grosor,
                    panel.ClientSize.Height - grosor);
            }
        }

        private void NerdUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}