using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class GhostUserControl : AcertijoUserControl, IControlConMovimiento
    {
        private int frameActual = 0;
        private Image[] framesActuales;
        private Image[] framesAnimacionAbajo;
        private Image[] framesAnimacionArriba;
        private Image[] framesAnimacionDerecha;
        private Image[] framesAnimacionIzquierda;
        private List<ObjetoInteractuable> objetos;
        private ObjetoInteractuable objetoCercano = null;
        int segundosRestantes = 60;
        int cantidadDeIntentos = 2;

        public new void SetForm(Form1 form)
        {
            _form = form;
            timerCronometro.Start();
            objetos = new List<ObjetoInteractuable>
            {
                new ObjetoInteractuable_Jeringa(pbNeedle, this),
                new ObjetoInteractuable_Piano(pbPiano, this),
                new ObjetoInteractuable_Libro(pbBook, this),
                new ObjetoInteractuable_Mapa(pbMap, this),
                new ObjetoInteractuable_Reloj(pbClock, this)
            };
        }

        public GhostUserControl()
        {
            InitializeComponent();
            lblIntentos.Text = $"Intentos: {cantidadDeIntentos}";
            pbTiempo.Minimum = 0;
            pbTiempo.Maximum = 60;
            pbTiempo.Value = 60;

            RegistrarTabStop(btnVolver, btnSiBook, btnNoBook, btnSiNeedle, btnNoNeedle,
                btnSiClock, btnNoClock, btnSiMap, btnNoMap, btnSiPiano, btnNoPiano,
                btnFailContinuar, btnIntentar, btnSeguir);

            RegistrarHover(btnVolver, btnSiBook, btnNoBook, btnSiNeedle, btnNoNeedle,
                btnSiClock, btnNoClock, btnSiMap, btnNoMap, btnSiPiano, btnNoPiano,
                btnFailContinuar, btnIntentar, btnSeguir);

            framesAnimacionAbajo = new Image[]
            {
                Properties.Resources.SkeletonWalk3,
                Properties.Resources.SkeletonWalk1,
                Properties.Resources.SkeletonWalk4,
                Properties.Resources.SkeletonWalk2
            };
            framesAnimacionArriba = new Image[]
            {
                Properties.Resources.SkeletonUpWalk,
                Properties.Resources.SkeletonUpWalk2,
                Properties.Resources.SkeletonUpWalk3,
                Properties.Resources.SkeletonUpWalk1
            };
            framesAnimacionDerecha = new Image[]
            {
                Properties.Resources.SkeletonRightWalk,
                Properties.Resources.SkeletonRightWalk2,
                Properties.Resources.SkeletonRightWalk3,
                Properties.Resources.SkeletonRightWalk1
            };
            framesAnimacionIzquierda = new Image[]
            {
                Properties.Resources.SkeletonLeftWalk1,
                Properties.Resources.SkeletonLeftWalk2,
                Properties.Resources.SkeletonLeftWalk4,
                Properties.Resources.SkeletonLeftWalk3
            };

            framesActuales = framesAnimacionAbajo;
            pbJugador.Image = framesActuales[0];
        }

        // Metodos de ayuda
        private void RegistrarTabStop(params Button[] botones)
        {
            foreach (var btn in botones)
                btn.TabStop = false;
        }

        private void RegistrarHover(params Button[] botones)
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

        private void MostrarPanelIncorrecto()
        {
            pnlFail.Visible = true;
            btnIntentar.Visible = true;
            btnFailContinuar.Visible = false;
            btnSeguir.Visible = false;
        }

        private void CerrarPanelObjeto(Panel panel)
        {
            panel.Visible = false;
            objetoCercano = null;
            VerificarProximidad();
            _form.Focus();
        }

        private void RegistrarIntento(Panel panel)
        {
            panel.Visible = false;
            pnlNeedle.Visible = false;
            cantidadDeIntentos--;
            lblIntentos.Text = $"Intentos: {cantidadDeIntentos}";
            MostrarPanelIncorrecto();
            VerificarIntentos();
            objetoCercano = null;
            VerificarProximidad();
            _form.Focus();
        }
        private void CambiarFramesAnimacion(Image[] frames)
        {
            if (framesActuales != frames)
            {
                framesActuales = frames;
                frameActual = 0;
                pbJugador.Image = framesActuales[0];
            }
            timerAnimacion.Start();
        }

        public void DetenerMovimiento()
        {
            timerMoverArriba.Stop();
            timerMoverAbajo.Stop();
            timerMoverIzquierda.Stop();
            timerMoverDerecha.Stop();
            timerAnimacion.Stop();
            if (framesActuales != null)
            {
                frameActual = 0;
                pbJugador.Image = framesActuales[0];
            }
        }

        public void HabilitarTeclas(Keys tecla, bool presionada)
        {
            if (presionada)
            {
                if (tecla == Keys.Space && objetoCercano != null)
                {
                    DetenerMovimiento();
                    if (objetoCercano is ObjetoInteractuable_Jeringa) { lblNeedle.Text = objetoCercano.TextoDialogo; pnlNeedle.Visible = true; }
                    else if (objetoCercano is ObjetoInteractuable_Piano) { lblPiano.Text = objetoCercano.TextoDialogo; pnlPiano.Visible = true; }
                    else if (objetoCercano is ObjetoInteractuable_Libro) { lblBook.Text = objetoCercano.TextoDialogo; pnlBook.Visible = true; }
                    else if (objetoCercano is ObjetoInteractuable_Mapa) { lblDialogoMap.Text = objetoCercano.TextoDialogo; pnlMap.Visible = true; }
                    else if (objetoCercano is ObjetoInteractuable_Reloj) { lblClock.Text = objetoCercano.TextoDialogo; pnlClock.Visible = true; }
                    return;
                }
                if (tecla == Keys.W) { timerMoverArriba.Start(); CambiarFramesAnimacion(framesAnimacionArriba); }
                else if (tecla == Keys.A) { timerMoverIzquierda.Start(); CambiarFramesAnimacion(framesAnimacionIzquierda); }
                else if (tecla == Keys.S) { timerMoverAbajo.Start(); CambiarFramesAnimacion(framesAnimacionAbajo); }
                else if (tecla == Keys.D) { timerMoverDerecha.Start(); CambiarFramesAnimacion(framesAnimacionDerecha); }
            }
            else
            {
                timerMoverArriba.Stop();
                timerMoverAbajo.Stop();
                timerMoverIzquierda.Stop();
                timerMoverDerecha.Stop();
                timerAnimacion.Stop();
                frameActual = 0;
                pbJugador.Image = framesActuales[0];
            }
        }

        private void VerificarProximidad()
        {
            objetoCercano = null;
            pbPianoCloud.Visible = false;
            pbNeedleCloud.Visible = false;
            pbBookCloud.Visible = false;
            pbClockCloud.Visible = false;
            pbMapCloud.Visible = false;

            foreach (var obj in objetos)
            {
                if (!obj.EstaCerca(pbJugador)) continue;
                objetoCercano = obj;
                if (obj is ObjetoInteractuable_Libro) pbBookCloud.Visible = true;
                else if (obj is ObjetoInteractuable_Jeringa) pbNeedleCloud.Visible = true;
                else if (obj is ObjetoInteractuable_Mapa) pbMapCloud.Visible = true;
                else if (obj is ObjetoInteractuable_Reloj) pbClockCloud.Visible = true;
                else if (obj is ObjetoInteractuable_Piano) pbPianoCloud.Visible = true;
                break;
            }
        }

        private void VerificarIntentos()
        {
            if (cantidadDeIntentos > 0) return;
            timerCronometro.Stop();
            DetenerMovimiento();
            lblFail.Text = "Oh no... Perdiste, adios\r\na nuestra libertad\r\nOh no...\r\n";
            pnlFail.Visible = true;
            btnFailContinuar.Visible = true;
            btnIntentar.Visible = false;
        }
        private void timerMoverDerecha_Tick(object sender, EventArgs e) { if (pbJugador.Right < ClientSize.Width) pbJugador.Left += 5; VerificarProximidad(); }
        private void timerMoverArriba_Tick(object sender, EventArgs e) { if (pbJugador.Top > 0) pbJugador.Top -= 5; VerificarProximidad(); }
        private void timerMoverIzquierda_Tick(object sender, EventArgs e) { if (pbJugador.Left > 0) pbJugador.Left -= 5; VerificarProximidad(); }
        private void timerMoverAbajo_Tick(object sender, EventArgs e) { if (pbJugador.Bottom < ClientSize.Height) pbJugador.Top += 5; VerificarProximidad(); }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            frameActual = (frameActual + 1) % framesActuales.Length;
            pbJugador.Image = framesActuales[frameActual];
        }

        private void timerCronometro_Tick(object sender, EventArgs e)
        {
            if (segundosRestantes > 0)
            {
                segundosRestantes--;
                if (segundosRestantes < pbTiempo.Maximum)
                {
                    pbTiempo.Value = segundosRestantes + 1;
                    pbTiempo.Value = segundosRestantes;
                }
                else pbTiempo.Value = segundosRestantes;
                lblCronometro.Text = string.Format("00:00:{0:00}", segundosRestantes);
            }
            else
            {
                timerCronometro.Stop();
                DetenerMovimiento();
                lblFail.Text = "Oh no... Perdiste, adios\r\na nuestra libertad\r\nOh no...\r\n";
                pnlFail.Visible = true;
                btnFailContinuar.Visible = true;
            }
        }

        //Botones Si/No
        private void btnSiMap_Click(object sender, EventArgs e)
        {
            timerCronometro.Stop();
            lblFail.Text = "Wow, en serio lo lograste, \nfelicidades y todo eso...";
            pnlFail.Visible = true;
            btnSeguir.Visible = true;
            btnIntentar.Visible = false;
            btnFailContinuar.Visible = false;
            AlResolver();
        }

        private void btnNoMap_Click(object sender, EventArgs e) => CerrarPanelObjeto(pnlMap);
        private void btnSiNeedle_Click(object sender, EventArgs e) => RegistrarIntento(pnlNeedle);
        private void btnNoNeedle_Click(object sender, EventArgs e) => CerrarPanelObjeto(pnlNeedle);
        private void btnSiPiano_Click(object sender, EventArgs e) => RegistrarIntento(pnlPiano);
        private void btnNoPiano_Click(object sender, EventArgs e) => CerrarPanelObjeto(pnlPiano);
        private void btnSiBook_Click(object sender, EventArgs e) => RegistrarIntento(pnlBook);
        private void btnNoBook_Click(object sender, EventArgs e) => CerrarPanelObjeto(pnlBook);
        private void btnSiClock_Click(object sender, EventArgs e) => RegistrarIntento(pnlClock);
        private void btnNoClock_Click(object sender, EventArgs e) => CerrarPanelObjeto(pnlClock);

        //Navegación
        private void btnVolver_Click(object sender, EventArgs e) => _form.MostrarUserControl(new JugarUserControl());
        private void btnFailContinuar_Click(object sender, EventArgs e) => _form.MostrarUserControl(new MenuUserControl());
        private void btnIntentar_Click(object sender, EventArgs e) => pnlFail.Visible = false;
        private void btnSeguir_Click(object sender, EventArgs e) => _form.MostrarUserControl(new JugarUserControl());

        //Paint 
        private void pnlClock_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlClock);
        private void pnlBook_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlBook);
        private void pnlPiano_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlPiano);
        private void pnlNeedle_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlNeedle);
        private void pnlMap_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlMap);
        private void pnlFail_Paint(object sender, PaintEventArgs e) => DibujarBorde(e, pnlFail);

        //AlResolver
        protected override void AlResolver()
        {
            EstadoDeJuego.TiempoRestanteGhost = segundosRestantes;
            EstadoDeJuego.NivelGhostCompletado = true;
            EstadoDeJuego.cantidadNivelesCompletados++;
        }
    }
}