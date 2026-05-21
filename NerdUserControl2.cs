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
    public partial class NerdUserControl2 : AcertijoUserControl
    {
        int segundosRestantes = 80;
        public NerdUserControl2()
        {
            InitializeComponent();
            timerCronometro.Start();
            _acertijo = new AcertijoTexto("Un dragón tiene 5 cabezas; por cada cabeza que se le corta le crecen 5 más. Si se le cortan 6 cabezas,\r\n¿cuántas cabezas tendrá al final?", "29", 80, 3);
            lblAcertijo.Text = _acertijo.Pregunta;
            lblIntentos.Text = $"Intentos: {_acertijo.Intentos}";
            RegistrarHoverBotones(btnValidar, btnContinuarFailNerd, btnVolver);
        }

        private void timerCronometro_Tick(object sender, EventArgs e)
        {
            if (segundosRestantes > 0)
            {
                segundosRestantes--;
                pbTiempo.Value = segundosRestantes;
                pbTiempo.Value = segundosRestantes + 1;
                pbTiempo.Value = segundosRestantes;
                lblCronometro.Text = string.Format("00:00:{0:00}", segundosRestantes);
            }
            else
            {
                timerCronometro.Stop();
                pnlNerd.Visible = true;
            }
        }
        protected override void AlCorrecto()
        {
            timerCronometro.Stop();
            lblNerd.Text = "WOW! VAS EN UNA RACHA! Nadie ha podido llegar \nhasta aqui";
            btnAceptarNerd.Visible = true;
            pnlNerd.Visible = true;
        }
        protected override void AlIncorrecto()
        {
            timerCronometro.Stop();
            btnContinuarFailNerd.Visible = true;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            timerCronometro.Stop();
            int intentosAntes = _acertijo.Intentos;
            Validar(txtRespuesta.Text);
            if (_acertijo.Intentos > 0 && _acertijo.Intentos < intentosAntes)
                lblIntentos.Text = $"Intentos: {_acertijo.Intentos}";
            _acertijo.Intentos--;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            timerCronometro.Stop();
            _form.MostrarUserControl(new JugarUserControl());
        }
        protected override void AlResolver()
        {
            timerCronometro.Stop();
            EstadoDeJuego.TiempoRestanteNerd2 = segundosRestantes;
            EstadoDeJuego.NivelNerdCompletado = true;
            EstadoDeJuego.cantidadNivelesCompletados++;
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void btnAceptarNerd_Click(object sender, EventArgs e)
        {
            AlResolver();
        }

        private void btnContinuarFailNerd_Click(object sender, EventArgs e)
        {
            pnlNerd.Visible = false;
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
