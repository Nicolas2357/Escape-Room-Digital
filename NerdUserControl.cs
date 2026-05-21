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
    public partial class NerdUserControl : AcertijoUserControl
    {
        int segundosRestantes = 60;

        public NerdUserControl()
        {
            InitializeComponent();
            timerCronómetro.Start();
            _acertijo = new AcertijoTexto(
                "Un león se esconde en una de tres habitaciones.. \nSabiendo que solamente una de esas afirmaciones es verdadera, ¿en cuál habitación está el león?(1,2 o 3)",
                "3", 120
            );
            lblAcertijo.Text = _acertijo.Pregunta;
            lblIntentos.Text = $"Intentos: {_acertijo.Intentos}";
            RegistrarHoverBotones(btnValidar, btnContinuarRight, btnContinuarFail, btnVolver);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            timerCronómetro.Stop();
            int intentosAntes = _acertijo.Intentos;
            Validar(txtRespuesta.Text);
            if (_acertijo.Intentos > 0 && _acertijo.Intentos < intentosAntes)
            lblIntentos.Text = $"Intentos: {_acertijo.Intentos}";
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
        }
        protected override void AlIncorrecto()
        {
            timerCronómetro.Stop();
            pnlNerdIncorrecto.Visible = true;
        }
        protected override void AlResolver()
        {
            timerCronómetro.Stop();
            EstadoDeJuego.NivelNerdCompletado = true;
            EstadoDeJuego.TiempoRestanteNerd = segundosRestantes;
            EstadoDeJuego.cantidadNivelesCompletados++;
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
    }
}