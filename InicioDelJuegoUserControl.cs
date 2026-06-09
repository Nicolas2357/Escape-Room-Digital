using Escape_Room_Digital.Idiomas;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class InicioDelJuegoUserControl : UserControl, IEscenaGrafica, ITraducible
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


            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
            btnRegresar.MouseLeave += (s, e) =>
            {
                if (_botonSeleccionado != btnRegresar)
                    btnRegresar.ForeColor = Color.White;
            };
        }

        private int _indiceSiNo = 0;
        private Button[] BotonesSiNo => new[] { btnSiTenna, btnNoTenna };

        private int _indice = 0;

        private Button[] BotonesActivos()
        {
            if (btnSiTenna.Visible && btnNoTenna.Visible)
                return new[] { btnSiTenna, btnNoTenna, btnSaltar, btnRegresar };
            if (btnEmpezarTenna.Visible)
                return new[] { btnEmpezarTenna, btnSaltar, btnRegresar };
            if (btnContinuarTenna.Visible)
                return new[] { btnContinuarTenna, btnSaltar, btnRegresar };
            return new[] { btnSaltar, btnRegresar };
        }

        private void ActualizarSeleccion()
        {
            foreach (var btn in new[] { btnSiTenna, btnNoTenna, btnEmpezarTenna, btnContinuarTenna, btnSaltar })
                btn.ForeColor = Color.White;

            var activos = BotonesActivos();
            if (_indice >= activos.Length) _indice = 0;
            activos[_indice].ForeColor = Color.Yellow;
        }

        private Button _botonSeleccionado;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txtNombre.Focused)
            {
                if (keyData == Keys.Enter || keyData == Keys.Tab)
                {
                    this.Focus();
                    SeleccionarBoton(btnContinuarTenna.Visible ? btnContinuarTenna : btnSaltar);
                    SiguienteDialogo();
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            // Navegación cuando hay Si/No visibles
            if (btnSiTenna.Visible && btnNoTenna.Visible)
            {
                if (_botonSeleccionado == btnSaltar)
                {
                    if (keyData == Keys.Down) { SeleccionarBoton(btnSiTenna); return true; }
                    if (keyData == Keys.Up) { return true; } // bloquear arriba
                    if (keyData == Keys.Left) { SeleccionarBoton(btnRegresar); return true; }
                    if (keyData == Keys.Right) { return true; } // bloquear derecha
                }
                else if (_botonSeleccionado == btnRegresar)
                {
                    if (keyData == Keys.Down) { SeleccionarBoton(btnSiTenna); return true; }
                    if (keyData == Keys.Up) { return true; }
                    if (keyData == Keys.Right) { SeleccionarBoton(btnSaltar); return true; }
                    if (keyData == Keys.Left) { return true; }
                }
                else
                {
                    if (keyData == Keys.Left) { SeleccionarBoton(btnSiTenna); return true; }
                    if (keyData == Keys.Right) { SeleccionarBoton(btnNoTenna); return true; }
                    if (keyData == Keys.Up) { SeleccionarBoton(btnSaltar); return true; }
                }
                if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    _botonSeleccionado?.PerformClick();
                    return true;
                }
                else if (_botonSeleccionado == btnEmpezarTenna)
                {
                    if (keyData == Keys.Up) { SeleccionarBoton(btnSaltar); return true; }
                    if (keyData == Keys.Down) { SeleccionarBoton(btnSaltar); return true; }
                    if (keyData == Keys.Left || keyData == Keys.Right) { return true; }
                }
                return base.ProcessCmdKey(ref msg, keyData);
            
            }

            // Navegación normal
            if (_botonSeleccionado == btnContinuarTenna || _botonSeleccionado == btnEmpezarTenna)
            {
                if (keyData == Keys.Up) { SeleccionarBoton(pbFlecha.Visible ? btnSaltar : btnRegresar); return true; }
            }
            else if (_botonSeleccionado == btnSaltar)
            {
                if (keyData == Keys.Up) { return true; } // bloquear arriba
                if (keyData == Keys.Down) { SeleccionarBoton(btnContinuarTenna.Visible ? btnContinuarTenna : btnEmpezarTenna); return true; }
                if (keyData == Keys.Left) { SeleccionarBoton(btnRegresar); return true; }
                if (keyData == Keys.Right) { return true; } // bloquear derecha
                else if (_botonSeleccionado == btnSaltar)
                {
                    if (keyData == Keys.Up) { return true; }
                    if (keyData == Keys.Down)
                    {
                        if (btnEmpezarTenna.Visible)
                        { SeleccionarBoton(btnEmpezarTenna); return true; }
                        SeleccionarBoton(btnContinuarTenna.Visible ? btnContinuarTenna : btnEmpezarTenna);
                        return true;
                    }
                    if (keyData == Keys.Left) { SeleccionarBoton(btnRegresar); return true; }
                    if (keyData == Keys.Right) { return true; }
                }
            }
            else if (_botonSeleccionado == btnRegresar)
            {
                if (keyData == Keys.Down) { SeleccionarBoton(btnContinuarTenna.Visible ? btnContinuarTenna : btnEmpezarTenna); return true; }
                if (keyData == Keys.Right) { SeleccionarBoton(btnSaltar); return true; }
                if (keyData == Keys.Up) { return true; } // bloquear arriba
            }

            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                if (txtNombre.Visible) { txtNombre.Focus(); return true; }
                _botonSeleccionado?.PerformClick();
                return true;
            }
            if (keyData == Keys.Z) { SiguienteDialogo(); return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void SeleccionarBoton(Button btn)
        {
            foreach (var b in new[] { btnContinuarTenna, btnSaltar, btnRegresar, btnSiTenna, btnNoTenna, btnEmpezarTenna })
                b.ForeColor = Color.White;
            _botonSeleccionado = btn;
            btn.ForeColor = Color.Yellow;
        }
        private void ActualizarSeleccionSiNo()
        {
            foreach (var btn in BotonesSiNo)
                btn.ForeColor = Color.White;
            BotonesSiNo[_indiceSiNo].ForeColor = Color.Yellow;
        }

        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            btnContinuarTenna.Text = G.Obtener("inicio.btn.continuar");
            btnSaltar.Text = G.Obtener("inicio.btn.saltar");
            btnSiTenna.Text = G.Obtener("inicio.btn.si");
            btnNoTenna.Text = G.Obtener("inicio.btn.no");
            btnEmpezarTenna.Text = G.Obtener("inicio.btn.empezar");
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
                SeleccionarBoton(btnEmpezarTenna);
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
            SeleccionarBoton(btnContinuarTenna.Visible ? btnContinuarTenna : btnEmpezarTenna);
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

        private void InicioDelJuegoUserControl_Load(object sender, EventArgs e)
        {

        }

        private void lblTexto_Click(object sender, EventArgs e)
        {

        }
    }
}