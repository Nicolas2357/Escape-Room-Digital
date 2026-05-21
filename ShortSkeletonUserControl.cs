using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class ShortSkeletonUserControl : UserControl, IControlConMovimiento
    {
        private Form1 _form1;
        int segundosRestantes = 300;

        private int frameActual = 0;
        private Image[] framesActuales;
        private Image[] framesAnimacionAbajo;
        private Image[] framesAnimacionArriba;
        private Image[] framesAnimacionDerecha;
        private Image[] framesAnimacionIzquierda;


        private int tamCelda = 75;
        private bool moviendose = false;

        //celdas no pixeles
        private int jugadorCeldaX, jugadorCeldaY;
        private Dictionary<PictureBox, (int x, int y)> posicionCeldas = new Dictionary<PictureBox, (int, int)>();


        private Dictionary<PictureBox, (int x, int y)> posicionesIniciales = new Dictionary<PictureBox, (int, int)>();
        private (int x, int y) jugadorInicial;


        private List<PictureBox> cajas = new List<PictureBox>();
        private List<PictureBox> metas = new List<PictureBox>();
        private List<PictureBox> paredes = new List<PictureBox>();

        private PictureBox cajaAnimando = null;
        private int animPasos = 0;
        private int animPasosTotales = 8;
        private int animDxPixel, animDyPixel;
        private int jugadorDxPixel, jugadorDyPixel;

        public void SetForm(Form1 form)
        {
            _form1 = form;
        }

        public ShortSkeletonUserControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            timerCronometro.Start();

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

            paredes.Add(pbPared);
            paredes.Add(pbPared1);
            paredes.Add(pbPared2);
            paredes.Add(pbPared3);
            paredes.Add(pbPared4);
            paredes.Add(pbPared5);
            paredes.Add(pbPared6);
            paredes.Add(pbPared7);
            paredes.Add(pbPared8);
            paredes.Add(pbPared9);
            paredes.Add(pbPared10);
            paredes.Add(pbPared11);
            paredes.Add(pbPared12);
            paredes.Add(pbPared13);
            paredes.Add(pbPared14);
            paredes.Add(pbPared15);
            paredes.Add(pbPared16);
            paredes.Add(pbPared17);
            paredes.Add(pbPared18);
            paredes.Add(pbPared19);
            paredes.Add(pbPared20);
            paredes.Add(pbPared21);


            cajas.Add(pbCaja);
            cajas.Add(pbCaja1);
            cajas.Add(pbCaja2);
            cajas.Add(pbCaja3);
            cajas.Add(pbCaja4);
            cajas.Add(pbCaja5);

            metas.Add(pbMeta);
            metas.Add(pbMeta1);
            metas.Add(pbMeta2);
            metas.Add(pbMeta3);
            metas.Add(pbMeta4);
            metas.Add(pbMeta5);

            InicializarPosiciones();

            foreach (var meta in metas)
                meta.SendToBack();
            foreach (var caja in cajas)
                caja.BringToFront();
            pbJugador.BringToFront();
        }

        private bool CeldaChocaConControl(int celdaX, int celdaY, PictureBox pb)
        {
            int px = celdaX * tamCelda;
            int py = celdaY * tamCelda;
            return px >= pb.Left && px < pb.Left + pb.Width &&
                   py >= pb.Top && py < pb.Top + pb.Height;
        }

        private (int x, int y) PixelACelda(Point p)
        {
            return (p.X / tamCelda, p.Y / tamCelda);
        }

        private Point CeldaAPixel(int cx, int cy)
        {
            return new Point(cx * tamCelda, cy * tamCelda);
        }

        private void InicializarPosiciones()
        {
            jugadorCeldaX = pbJugador.Left / tamCelda;
            jugadorCeldaY = pbJugador.Top / tamCelda;
            jugadorInicial = (jugadorCeldaX, jugadorCeldaY);

            foreach (var caja in cajas)
            {
                var celda = PixelACelda(caja.Location);
                posicionCeldas[caja] = celda;
                posicionesIniciales[caja] = celda;
            }

            pbJugador.BringToFront();
        }

        public void HabilitarTeclas(Keys tecla, bool presionada)
        {
            if (!presionada || moviendose) return;

            int dx = 0, dy = 0;
            Image[] frames = framesActuales;

            if (tecla == Keys.W) { dy = -1; frames = framesAnimacionArriba; }
            else if (tecla == Keys.S) { dy = 1; frames = framesAnimacionAbajo; }
            else if (tecla == Keys.A) { dx = -1; frames = framesAnimacionIzquierda; }
            else if (tecla == Keys.D) { dx = 1; frames = framesAnimacionDerecha; }
            else return;

            if (framesActuales != frames)
            {
                framesActuales = frames;
                frameActual = 0;
                pbJugador.Image = framesActuales[0];
            }

            IntentarMover(dx, dy);
        }

        public void DetenerMovimiento()
        {
            moviendose = false;
            timerAnimacion.Stop();
            frameActual = 0;
            if (framesActuales != null)
                pbJugador.Image = framesActuales[0];
        }


        private void IntentarMover(int dx, int dy)
        {
            int nuevaX = jugadorCeldaX + dx;
            int nuevaY = jugadorCeldaY + dy;

            // Hay pared?
            foreach (var pared in paredes)
                if (CeldaChocaConControl(nuevaX, nuevaY, pared)) return;

            // Hay caja?
            PictureBox cajaEncontrada = null;
            foreach (var caja in cajas)
            {
                var c = posicionCeldas[caja];
                if (c.x == nuevaX && c.y == nuevaY)
                {
                    cajaEncontrada = caja;
                    break;
                }
            }

            if (cajaEncontrada != null)
            {
                int cajaNuevaX = nuevaX + dx;
                int cajaNuevaY = nuevaY + dy;

                // La caja choca con pared?
                foreach (var pared in paredes)
                    if (CeldaChocaConControl(cajaNuevaX, cajaNuevaY, pared)) return;

                // La caja choca con otra caja?
                foreach (var otraCaja in cajas)
                {
                    if (otraCaja == cajaEncontrada) continue;
                    var c = posicionCeldas[otraCaja];
                    if (c.x == cajaNuevaX && c.y == cajaNuevaY) return;
                }

                posicionCeldas[cajaEncontrada] = (cajaNuevaX, cajaNuevaY);
                cajaAnimando = cajaEncontrada;
            }

            jugadorCeldaX = nuevaX;
            jugadorCeldaY = nuevaY;

            animDxPixel = dx * tamCelda / animPasosTotales;
            animDyPixel = dy * tamCelda / animPasosTotales;
            jugadorDxPixel = animDxPixel;
            jugadorDyPixel = animDyPixel;
            animPasos = 0;
            moviendose = true;
            timerMovimiento.Start();
            timerAnimacion.Start();
        }

        private void timerMovimiento_Tick(object sender, EventArgs e)
        {
            pbJugador.Left += jugadorDxPixel;
            pbJugador.Top += jugadorDyPixel;

            if (cajaAnimando != null)
            {
                cajaAnimando.Left += animDxPixel;
                cajaAnimando.Top += animDyPixel;
            }

            animPasos++;

            if (animPasos >= animPasosTotales)
            {
                pbJugador.Location = CeldaAPixel(jugadorCeldaX, jugadorCeldaY);
                if (cajaAnimando != null)
                {
                    var c = posicionCeldas[cajaAnimando];
                    cajaAnimando.Location = CeldaAPixel(c.x, c.y);
                }

                timerMovimiento.Stop();
                timerAnimacion.Stop();
                frameActual = 0;
                pbJugador.Image = framesActuales[0];
                cajaAnimando = null;
                moviendose = false;

                VerificarVictoria();
            }
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            frameActual++;
            if (frameActual >= framesActuales.Length)
                frameActual = 0;
            pbJugador.Image = framesActuales[frameActual];
        }


        private void VerificarVictoria()
        {
            int cajasEnMeta = 0;

            foreach (var meta in metas)
            {
                var metaCelda = PixelACelda(meta.Location);
                foreach (var caja in cajas)
                {
                    var cajaCelda = posicionCeldas[caja];
                    if (cajaCelda.x == metaCelda.x && cajaCelda.y == metaCelda.y)
                    {
                        cajasEnMeta++;
                        break;
                    }
                }
            }

            lblProgreso.Text = $"Cajas: {cajasEnMeta}/{metas.Count}";

            if (cajasEnMeta == metas.Count)
            {
                DetenerMovimiento();
                EstadoDeJuego.TiempoRestanteShortSkeleton = segundosRestantes;
                EstadoDeJuego.NivelShortSkeletonCompletado = true;
                EstadoDeJuego.cantidadNivelesCompletados++;
                lblDialogoShortSkeleton.Text = "Wow, en serio lo lograste, pensaba \nque no lo ibas a lograr, parece \nque superaste mis expectativas";
                timerCronometro.Stop();
                pnlDialogoShortSkeleton.BringToFront();
                pnlDialogoShortSkeleton.Visible = true;
                btnContinuarShortSkeleton.Visible = true;
                btnOkShortSkeleton.Visible = false;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            moviendose = false;
            timerMovimiento.Stop();
            timerAnimacion.Stop();

            jugadorCeldaX = jugadorInicial.x;
            jugadorCeldaY = jugadorInicial.y;
            pbJugador.Location = CeldaAPixel(jugadorCeldaX, jugadorCeldaY);

            foreach (var caja in cajas)
            {
                posicionCeldas[caja] = posicionesIniciales[caja];
                caja.Location = CeldaAPixel
                    (
                    posicionesIniciales[caja].x,
                    posicionesIniciales[caja].y
                    );
            }

            frameActual = 0;
            pbJugador.Image = framesActuales[0];
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            _form1.MostrarUserControl(new JugarUserControl());
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
                lblCronometro.Text = "¡Tiempo agotado!";
                DetenerMovimiento();
                btnContinuarShortSkeleton.Visible = false;
                pnlDialogoShortSkeleton.Visible = true;

            }
        }

        private void btnOkShortSkeleton_Click(object sender, EventArgs e)
        {
            _form1.MostrarUserControl(new MenuUserControl());
        }

        private void btnContinuarShortSkeleton_Click(object sender, EventArgs e)
        {
            _form1.MostrarUserControl(new JugarUserControl());
        }

        private void pnlDialogoShortSkeleton_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3;
            Color colorBorde = Color.White;

            using (Pen pen = new Pen(colorBorde, grosor))
            {
                int offset = grosor / 2;
                e.Graphics.DrawRectangle(pen,
                    offset,
                    offset,
                    pnlDialogoShortSkeleton.ClientSize.Width - grosor,
                    pnlDialogoShortSkeleton.ClientSize.Height - grosor);
            }
        }

        private void pnlProgreso_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3;
            Color colorBorde = Color.White;

            using (Pen pen = new Pen(colorBorde, grosor))
            {
                int offset = grosor / 2;
                e.Graphics.DrawRectangle(pen,
                    offset,
                    offset,
                    pnlDialogoShortSkeleton.ClientSize.Width - grosor,
                    pnlDialogoShortSkeleton.ClientSize.Height - grosor);
            }
        }

        private void btnVolver_MouseEnter(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.Yellow;
        }

        private void btnVolver_MouseLeave(object sender, EventArgs e)
        {
            btnVolver.ForeColor = Color.White;
        }

        private void btnReiniciar_MouseEnter(object sender, EventArgs e)
        {
            btnReiniciar.ForeColor = Color.Yellow;
        }

        private void btnReiniciar_MouseLeave(object sender, EventArgs e)
        {
            btnReiniciar.ForeColor = Color.White;
        }

        private void btnContinuarShortSkeleton_MouseEnter(object sender, EventArgs e)
        {
            btnContinuarShortSkeleton.ForeColor = Color.Yellow;
        }

        private void btnContinuarShortSkeleton_MouseLeave(object sender, EventArgs e)
        {
            btnContinuarShortSkeleton.ForeColor = Color.White;
        }

        private void btnOkShortSkeleton_MouseEnter(object sender, EventArgs e)
        {
            btnOkShortSkeleton.ForeColor = Color.Yellow;
        }

        private void btnOkShortSkeleton_MouseLeave(object sender, EventArgs e)
        {
            btnOkShortSkeleton.ForeColor = Color.White;
        }
    }
}