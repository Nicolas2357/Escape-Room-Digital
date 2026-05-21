using Escape_Room_Digital.UserControls;

namespace Escape_Room_Digital
{
    public abstract class ObjetoInteractuable
    {
        protected PictureBox pictureBox;
        protected UserControl _control;

        public abstract string TextoDialogo { get;}

        public ObjetoInteractuable(PictureBox pb, UserControl control)
        {
            pictureBox = pb;
            _control = control;
        }

        public bool EstaCerca(PictureBox jugador, int distancia = 80)
        {
            Rectangle zona = new Rectangle(
                pictureBox.Left - distancia,
                pictureBox.Top - distancia,
                pictureBox.Width + distancia * 2,
                pictureBox.Height + distancia * 2
            );
            return zona.IntersectsWith(jugador.Bounds);
        }
    }
}