using System.Drawing;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class PersonajeUserControl : UserControl
    {
        private int frameActual = 0;
        private Image[] framesActuales;
        private Image[] framesAnimacionAbajo;
        private Image[] framesAnimacionArriba;
        private Image[] framesAnimacionDerecha;
        private Image[] framesAnimacionIzquierda;
        public Rectangle BoundsJugador => pbJugador.Bounds;

        public PersonajeUserControl()
        {
            InitializeComponent();

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

        public void Detener()
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

        // Propiedad para obtener la posición del jugador desde afuera
        public Rectangle Bounds => pbJugador.Bounds;

        private void timerMoverDerecha_Tick(object sender, EventArgs e)
        {
            if (pbJugador.Right < this.Parent.ClientSize.Width)
                pbJugador.Left += 5;
        }

        private void timerMoverArriba_Tick(object sender, EventArgs e)
        {
            if (pbJugador.Top > 0)
                pbJugador.Top -= 5;
        }

        private void timerMoverIzquierda_Tick(object sender, EventArgs e)
        {
            if (pbJugador.Left > 0)
                pbJugador.Left -= 5;
        }

        private void timerMoverAbajo_Tick(object sender, EventArgs e)
        {
            if (pbJugador.Bottom < this.Parent.ClientSize.Height)
                pbJugador.Top += 5;
        }

        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            frameActual++;
            if (frameActual >= framesActuales.Length)
                frameActual = 0;
            pbJugador.Image = framesActuales[frameActual];
        }
    }
}