using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class InicioDelJuegoUserControl : UserControl, IEscenaGrafica
    {
        private IWavePlayer? playerMusica;
        private AudioFileReader? musicaFile;
        private IWavePlayer? playerVoz;
        private AudioFileReader? vozFile;
        private IWavePlayer? playerEfecto;
        private AudioFileReader? efectoFile;

        private List<Dialogo>? listaDialogos;
        private int indiceActual = 0;
        private Form1 _form;
        private string textoCompleto = "";
        private int letraActual = 0;
        private PersonajeNuevo hablanteActual;
        private bool estaEscribiendo = false;

        private int xBaseFlecha;
        private int desplazamientoFlecha = 0;
        private const int MAX_DESPLAZAMIENTO = 6;
        private int alphaFlash = 0;
        private bool yaCambioEscena = false;

        public PictureBox Retrato => this.pbTenna;
        public Panel Dialogo => this.pnlTexto;
        public Control ControlGrafico => this;

        public InicioDelJuegoUserControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            xBaseFlecha = pbFlecha.Left;
            pbFlecha.Visible = false;
            btnEmpezarTenna.Visible = false;

            this.HandleDestroyed += (s, e) => DetenerTodoElAudio();

            this.Load += (s, e) =>
            {
                this.Focus();
                pnlTexto.BringToFront();
                pbTenna.BringToFront();
            };

            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Z || e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    SiguienteDialogo();
                }
            };
        }

        public void SetForm(Form1 form) { _form = form; CargarEscena(); }

        public void CargarEscena()
        {
            EscenaInicial escena = new EscenaInicial();
            listaDialogos = escena.CargarEscena();
            ReproducirMusica("Audio/musica_inicio.mp3");
            indiceActual = 0;
            SiguienteDialogo();
        }
        public void ReproducirMusica(string ruta)
        {
            try
            {
                playerMusica?.Stop(); playerMusica?.Dispose(); musicaFile?.Dispose();
                string rf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
                if (File.Exists(rf))
                {
                    playerMusica = new WaveOutEvent(); musicaFile = new AudioFileReader(rf);
                    playerMusica.Init(musicaFile); playerMusica.Play();
                }
            }
            catch { }
        }

        public void ReproducirSonido(string ruta)
        {
            playerEfecto?.Stop(); playerEfecto?.Dispose(); efectoFile?.Dispose();
            try
            {
                string rf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ruta);
                if (File.Exists(rf))
                {
                    playerEfecto = new WaveOutEvent(); efectoFile = new AudioFileReader(rf);
                    playerEfecto.Init(efectoFile); playerEfecto.Play();
                }
            }
            catch { }
        }

        private void ReproducirVozHablante(string ruta)
        {
            try
            {
                string rv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", ruta);
                if (File.Exists(rv))
                {
                    playerVoz?.Stop(); playerVoz?.Dispose(); vozFile?.Dispose();
                    playerVoz = new WaveOutEvent(); vozFile = new AudioFileReader(rv);
                    playerVoz.Init(vozFile); playerVoz.Play();
                }
            }
            catch { }
        }

        private void DetenerTodoElAudio()
        {
            playerMusica?.Stop(); playerMusica?.Dispose();
            playerVoz?.Stop(); playerVoz?.Dispose();
            playerEfecto?.Stop(); playerEfecto?.Dispose();
        }
        private void SiguienteDialogo()
        {
            if (estaEscribiendo) { TerminarTexto(); return; }
            playerEfecto?.Stop(); playerVoz?.Stop();
            pbFlecha.Visible = false;

            if (listaDialogos != null && indiceActual == listaDialogos.Count - 1)
            {
                btnContinuarTenna.Visible = false;
                btnRegresar.Visible = false;
                btnEmpezarTenna.Visible = true;
                btnEmpezarTenna.BringToFront();
            }

            if (listaDialogos == null || indiceActual >= listaDialogos.Count) return;

            var d = listaDialogos[indiceActual];
            textoCompleto = d.Texto;
            lblNombre.Text = d.Hablante.Nombre;
            lblTexto.Text = ""; letraActual = 0; estaEscribiendo = true;

            if (d.Hablante.Expresiones.ContainsKey(d.ExpresionAUsar))
                CambiarImagen(d.Hablante.Expresiones[d.ExpresionAUsar]);

            if (!string.IsNullOrEmpty(d.Hablante.RutaVoz)) ReproducirVozHablante(d.Hablante.RutaVoz);

            timerAnimacion.Start();
            d.EfectoEspecial?.Invoke(this);
            indiceActual++;
        }
        private void btnEmpezarTenna_Click(object sender, EventArgs e)
        {
            if (yaCambioEscena) return;
            btnEmpezarTenna.Enabled = false;
            playerMusica?.Stop();
            IniciarEfectoFinal("Audio/efecto_final.wav");
        }

        private void IniciarEfectoFinal(string rutaAudio)
        {
            ReproducirSonido(rutaAudio);
            alphaFlash = 0;

            pbTenna.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, pbTenna.ClientRectangle);
            if (pbFaceTenna != null) pbFaceTenna.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, pbFaceTenna.ClientRectangle);
            pnlTexto.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, pnlTexto.ClientRectangle);
            lblTexto.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, lblTexto.ClientRectangle);
            lblNombre.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, lblNombre.ClientRectangle);

            // ESTO EVITA QUE EL BOTÓN SE QUEDE ENFRENTE
            btnEmpezarTenna.Paint += (s, e) => DibujarCapaBlanca(e.Graphics, btnEmpezarTenna.ClientRectangle);

            timerFlash.Interval = 20;
            timerFlash.Tick += (s, e) =>
            {
                if (alphaFlash < 255)
                {
                    alphaFlash += 5;
                    if (alphaFlash > 255) alphaFlash = 255;

                    this.Invalidate();
                    pbTenna.Invalidate();
                    if (pbFaceTenna != null) pbFaceTenna.Invalidate();
                    pnlTexto.Invalidate();
                    lblTexto.Invalidate();
                    lblNombre.Invalidate();
                    btnEmpezarTenna.Invalidate(); // Obligamos al botón a redibujarse con blanco
                }
                else
                {
                    timerFlash.Stop();
                    if (!yaCambioEscena)
                    {
                        yaCambioEscena = true;
                        DetenerTodoElAudio();
                        _form?.MostrarUserControl(new JugarUserControl());
                    }
                }
            };
            timerFlash.Start();
        }

        private void DibujarCapaBlanca(Graphics g, Rectangle rect)
        {
            if (alphaFlash > 0)
            {
                using (SolidBrush b = new SolidBrush(Color.FromArgb(alphaFlash, 255, 255, 255)))
                { g.FillRectangle(b, rect); }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DibujarCapaBlanca(e.Graphics, this.ClientRectangle);
        }
        public void CambiarImagen(Image i) { if (i != null) Retrato.Image = i; }
        public void CambiarTextoDialogo(string t)
        {
            textoCompleto = t; lblTexto.Text = ""; letraActual = 0; estaEscribiendo = true; timerAnimacion.Start();
        }

        public void CambiarFondoConRetraso(Image nuevoFondo, int milisegundos)
        {
            t.Stop(); t.Interval = milisegundos;
            EventHandler handler = null!;
            handler = (s, e) =>
            {
                this.BackgroundImage = nuevoFondo;
                t.Stop(); t.Tick -= handler;
            };
            t.Tick += handler; t.Start();
        }

        public void AnimarAgrandarImagen(int pasos, int limite)
        {
            t2.Stop();
            EventHandler h = null!;
            h = (s, e) =>
            {
                if (pbTenna.Width < limite)
                {
                    pbTenna.Width += pasos; pbTenna.Height += pasos;
                    pbTenna.Left -= pasos / 2; pbTenna.Top -= pasos;
                }
                else { t2.Stop(); t2.Tick -= h; }
            };
            t2.Tick += h; t2.Start();
        }
        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            if (letraActual < textoCompleto.Length) { lblTexto.Text += textoCompleto[letraActual]; letraActual++; }
            else { TerminarTexto(); }
        }

        private void TerminarTexto()
        {
            timerAnimacion.Stop(); lblTexto.Text = textoCompleto; estaEscribiendo = false;
            playerVoz?.Stop();
            if (!btnEmpezarTenna.Visible) { pbFlecha.Visible = true; timerFlecha.Start(); }
        }

        private void timerFlecha_Tick(object sender, EventArgs e)
        {
            desplazamientoFlecha += 2; if (desplazamientoFlecha > 6) desplazamientoFlecha = 0;
            pbFlecha.Left = xBaseFlecha + desplazamientoFlecha;
        }

        private void pnlTexto_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pnlTexto.ClientRectangle, Color.White, 3, ButtonBorderStyle.Solid,
                Color.White, 3, ButtonBorderStyle.Solid, Color.White, 3, ButtonBorderStyle.Solid, Color.White, 3, ButtonBorderStyle.Solid);
        }

        private void btnContinuarTenna_Click(object sender, EventArgs e) => SiguienteDialogo();
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DetenerTodoElAudio();
            _form?.MostrarUserControl(new MenuUserControl());
        }

        private void btnSaltar_Click(object sender, EventArgs e)
        {
            _form?.MostrarUserControl(new JugarUserControl());
        }
    }
}