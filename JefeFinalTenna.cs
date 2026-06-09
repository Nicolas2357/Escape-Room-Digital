using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using Escape_Room_Digital.Idiomas;

namespace Escape_Room_Digital.UserControls
{
    public partial class JefeFinalTenna : UserControl, IEscenaGrafica, ITraducible
    {
        private Form1 _form;
        private int tiempoRestante = 100;
        private List<(Acertijo acertijo, Image expresion)> preguntas;
        private IWavePlayer playerVoz;
        private AudioFileReader vozFile;
        private IWavePlayer playerMusica;
        private AudioFileReader musicaFile;

        private List<Dialogo> listaDialogos;
        private int indiceDialogo = 0;

        private int indicePregunta = 0;
        private int respuestasCorrectas = 0;
        private const int RespuestasParaGanar = 3;
        private int _fallos = 0;          
        private const int MaxFallos = 3;  

        private string textoCompleto = "";
        private int letraActual = 0;

        private bool enPreguntas = false;

        private Image _fondoPendiente;


        public PictureBox Retrato => pbRetratoPanel;
        public Panel Dialogo => pnlDialogoUnico;
        public Control ControlGrafico => this;

        public void SetForm(Form1 form)
        {
            _form = form;
            IniciarEscena();
            var rng = new Random();
            preguntas = preguntas.OrderBy(_ => rng.Next()).ToList();
        }
        public void CambiarTextoDialogo(string texto) => lblTextoUnico.Text = texto;
        public void CambiarImagen(Image img) => pbRetratoPanel.Image = img;
        public void AnimarAgrandarImagen(int px, int limite) { }

        public void CambiarFondoConRetraso(Image nuevoFondo, int ms)
        {
            _fondoPendiente = nuevoFondo;
            timerCambioFondo.Interval = ms;
            timerCambioFondo.Start();
        }

        public void ReproducirSonido(string ruta)
        {
            try
            {
                playerVoz?.Stop();
                playerVoz?.Dispose();
                vozFile?.Dispose();

                string rv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", ruta);
                if (File.Exists(rv))
                {
                    playerVoz = new WaveOutEvent();
                    vozFile = new AudioFileReader(rv);
                    playerVoz.Init(vozFile);
                    playerVoz.Play();
                }
            }
            catch { }
        }

        public void ReproducirMusica(string rutaArchivo)
        {
            try
            {
                playerMusica?.Stop();
                playerMusica?.Dispose();
                musicaFile?.Dispose();

                string rm = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audio", rutaArchivo);
                if (File.Exists(rm))
                {
                    playerMusica = new WaveOutEvent();
                    musicaFile = new AudioFileReader(rm);
                    playerMusica.Init(musicaFile);
                    playerMusica.Play();
                }
            }
            catch { }
        }

        public JefeFinalTenna()
        {
            InitializeComponent();
            pbRetratoPanel.Image = Properties.Resources.TennaIdle;
            lblTextoUnico.BackColor = Color.Black;
            lblTextoUnico.ForeColor = Color.White;
            lblStand.Text = EstadoDeJuego.NombreJugador;
            pnlDialogoUnico.Visible = true;
            txtBoxRespuesta.Visible = false;
            btnValidar.Visible = false;
            btnReintentar.Click += btnReintentar_Click;
            btnSalirFinal.Click += btnSalirFinal_Click;

            btnContinuar.Visible = false;
            btnReintentar.Visible = false;
            btnSalirFinal.Visible = false;
            RegistrarHoverBotones(btnRegresar, btnContinuar, btnValidar, btnReintentar, btnSalirFinal);
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
        }
        private int _indice = 0;

        private Button[] BotonesActivos()
        {
            if (btnReintentar.Visible && btnSalirFinal.Visible)
                return new[] { btnReintentar, btnSalirFinal };
            if (btnContinuar.Visible)
                return new[] { btnContinuar };
            if (btnValidar.Visible)
                return new[] { btnValidar };
            return Array.Empty<Button>();
        }

        private void ActualizarSeleccion()
        {
            foreach (var btn in new[] { btnContinuar, btnValidar, btnReintentar, btnSalirFinal })
                btn.ForeColor = Color.White;

            var activos = BotonesActivos();
            if (activos.Length == 0) return;
            if (_indice >= activos.Length) _indice = 0;
            activos[_indice].ForeColor = Color.Yellow;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Si están visibles reintentar y salir, solo navegar entre ellos
            if (btnReintentar.Visible && btnSalirFinal.Visible)
            {
                if (keyData == Keys.Left || keyData == Keys.Right ||
                    keyData == Keys.Up || keyData == Keys.Down)
                {
                    _indice = _indice == 0 ? 1 : 0;
                    ActualizarSeleccion();
                    return true;
                }
                if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    new[] { btnReintentar, btnSalirFinal }[_indice].PerformClick();
                    return true;
                }
                return true; // anula todo lo demás
            }

            // Si el textbox tiene el foco, solo Enter para validar
            if (txtBoxRespuesta.Visible && txtBoxRespuesta.Focused)
            {
                if (keyData == Keys.Enter) { btnValidar.PerformClick(); return true; }
                return base.ProcessCmdKey(ref msg, keyData);
            }

            var activos = BotonesActivos();
            if (activos.Length == 0) return base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Left || keyData == Keys.Up)
            {
                _indice = (_indice - 1 + activos.Length) % activos.Length;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Right || keyData == Keys.Down)
            {
                _indice = (_indice + 1) % activos.Length;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                activos[_indice].PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            btnContinuar.Text = G.Obtener("tercera.btn.continuar");
            btnValidar.Text = G.Obtener("tercera.btn.validar");
            btnRegresar.Text = G.Obtener("tercera.btn.regresar");
            btnReintentar.Text = G.Obtener("tercera.btn.reintentar");
            btnSalirFinal.Text = G.Obtener("tercera.btn.salir");
            lblCronometro.Text = G.Obtener("tercera.label.tiempo");
        }

        private void IniciarEscena()
        {
            _fallos = 0;
            tiempoRestante = 300;
            timerCronometro.Stop();
            TerceraEscena escena = new TerceraEscena();
            listaDialogos = escena.CargarEscena();
            preguntas = escena.CargarPreguntas();
            indiceDialogo = 0;
            enPreguntas = false;
            pnlDialogoUnico.BringToFront();
            pbTacha1.BringToFront();
            pbTacha2.BringToFront();
            pbTacha3.BringToFront();
            lblCronometro.BringToFront();
            pbTiempo.BringToFront();
            pbTacha1.Visible = false;
            pbTacha2.Visible = false;
            pbTacha3.Visible = false;

            MostrarDialogo();
        }

        private void MostrarDialogo()
        {
            if (indiceDialogo >= listaDialogos.Count)
            {
                enPreguntas = true;
                indicePregunta = 0;
                respuestasCorrectas = 0;
                MostrarPregunta();
                return;
            }

            pnlDialogoUnico.Visible = true;
            pnlDialogoUnico.BringToFront();

            var d = listaDialogos[indiceDialogo];
            lblNombreUnico.Text = d.Hablante.Nombre;
            textoCompleto = d.Texto;
            letraActual = 0;
            lblTextoUnico.Text = "";
            btnContinuar.Visible = true;
            txtBoxRespuesta.Visible = false;
            btnValidar.Visible = false;
            _indice = 0; ActualizarSeleccion();

            if (d.ExpresionAUsar != null && d.Hablante.Expresiones.ContainsKey(d.ExpresionAUsar))
                pictureBox2.Image = d.Hablante.Expresiones[d.ExpresionAUsar];

            ReproducirSonido(d.Hablante.RutaVoz);
            d.EfectoEspecial?.Invoke(this);
            indiceDialogo++;
            timerAnimacionTexto.Start();
            pbRetratoPanel.BringToFront();
            lblNombreUnico.BringToFront();
            pbTacha1.BringToFront();
            pbTacha2.BringToFront();
            pbTacha3.BringToFront();
        }

        private void MostrarPregunta()
        {
            if (indicePregunta >= preguntas.Count)
            {
                FinDelJuego();
                return;
            }
            if (indicePregunta == 0)
                timerCronometro.Start();



            var (acertijo, expresion) = preguntas[indicePregunta];
            lblNombreUnico.Text = "Tenna";
            textoCompleto = acertijo.Pregunta;
            letraActual = 0;
            lblTextoUnico.Text = "";
            btnContinuar.Visible = false;
            txtBoxRespuesta.Visible = false;
            btnValidar.Visible = false;
            txtBoxRespuesta.Text = "";

            if (expresion != null)
                pictureBox2.Image = expresion;

            ReproducirSonido("TennaVoice.wav");
            timerAnimacionTexto.Start();
            pbRetratoPanel.BringToFront();
            lblNombreUnico.BringToFront();
            pbTacha1.BringToFront();
            pbTacha2.BringToFront();
            pbTacha3.BringToFront();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            var G = GestorDeIdiomas.Instancia;
            (Acertijo acertijo, Image _) = preguntas[indicePregunta];
            bool correcto = acertijo.ValidarRespuesta(txtBoxRespuesta.Text);

            if (correcto)
            {
                respuestasCorrectas++;

                if (respuestasCorrectas >= RespuestasParaGanar)
                {
                    timerCronometro.Stop();
                    MostrarFeedback(string.Format(G.Obtener("tercera.ganaste"), respuestasCorrectas));
                    txtBoxRespuesta.Visible = false;
                    btnValidar.Visible = false;
                    btnContinuar.Visible = true;
                    indicePregunta = preguntas.Count;
                    return;
                }

                MostrarFeedback(string.Format(G.Obtener("tercera.correcto"), respuestasCorrectas, RespuestasParaGanar)); indicePregunta++;
                txtBoxRespuesta.Visible = false;
                btnValidar.Visible = false;
                btnContinuar.Visible = true;
            }
            else
            {
                _fallos++;
                MostrarFeedback(G.Obtener("tercera.incorrecto"));
                txtBoxRespuesta.Text = "";

                if (!pbTacha1.Visible) pbTacha1.Visible = true;
                else if (!pbTacha2.Visible) pbTacha2.Visible = true;
                else if (!pbTacha3.Visible) pbTacha3.Visible = true;

                if (_fallos >= MaxFallos)
                {
                    timerCronometro.Stop();
                    txtBoxRespuesta.Visible = false;
                    btnValidar.Visible = false;
                    FinDelJuego();
                    return;
                }

                txtBoxRespuesta.Focus();
            }
        }

        private void MostrarFeedback(string texto)
        {
            timerAnimacionTexto.Stop();
            lblTextoUnico.Text = texto;
        }

        private void FinDelJuego()
        {
            
            if (respuestasCorrectas >= RespuestasParaGanar)
            {
                EstadoDeJuego.TiempoRestanteNerd2 = respuestasCorrectas;
                _form.MostrarUserControl(new CreditosUserControl());
            }
            else
            {
                timerAnimacionTexto.Stop();
                lblTextoUnico.Text = string.Format(GestorDeIdiomas.Instancia.Obtener("tercera.resultado"),
                    respuestasCorrectas, preguntas.Count, RespuestasParaGanar); lblNombreUnico.Text = "Tenna";
                btnContinuar.Visible = false;
                txtBoxRespuesta.Visible = false;
                btnValidar.Visible = false;

                pnlDialogoUnico.Visible = false;  
                btnReintentar.Visible = true;
                btnSalirFinal.Visible = true;
                btnReintentar.BringToFront();
                btnSalirFinal.BringToFront();
             

                _indice = 0; ActualizarSeleccion();

            }
            EstadoDeJuego.TiempoRestanteNerd2 = respuestasCorrectas;
            GestorDePartidas.Instancia.GuardarEstadoActual(EstadoDeJuego.SlotActual, "JugarUserControl"); // ← agregar
        }
        private void timerAnimacionTexto_Tick(object sender, EventArgs e)
        {
            if (letraActual < textoCompleto.Length)
            {
                lblTextoUnico.Text += textoCompleto[letraActual];
                letraActual++;
            }
            else
            {
                timerAnimacionTexto.Stop();
                playerVoz?.Stop();

                if (enPreguntas)
                {
                    txtBoxRespuesta.Visible = true;
                    btnValidar.Visible = true;
                    txtBoxRespuesta.Focus();
                    _indice = 0; ActualizarSeleccion();
                }
                else
                {
                    btnContinuar.Visible = true;
                }
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (timerAnimacionTexto.Enabled)
            {
                timerAnimacionTexto.Stop();
                lblTextoUnico.Text = textoCompleto;
                letraActual = textoCompleto.Length;
                playerVoz?.Stop();

                if (enPreguntas)
                {
                    btnContinuar.Visible = false;
                    txtBoxRespuesta.Visible = true;
                    btnValidar.Visible = true;
                    txtBoxRespuesta.Focus();
                }
            }
            else
            {
                btnContinuar.Visible = false;
                if (enPreguntas)
                    MostrarPregunta();
                else
                    MostrarDialogo();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            btnReintentar.Visible = false;
            btnSalirFinal.Visible = false;
            pnlDialogoUnico.Visible = true;
            IniciarEscena();
        }

        private void btnSalirFinal_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void RegistrarHoverBotones(params Button[] botones)
        {
            foreach (var btn in botones)
            {
                btn.MouseEnter += (s, e) => btn.ForeColor = Color.Yellow;
                btn.MouseLeave += (s, e) => btn.ForeColor = Color.White;
            }
        }

        private void pnlDialogoUnico_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timerCronometro_Tick(object sender, EventArgs e)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante--;
                if (tiempoRestante <= pbTiempo.Maximum)
                {
                    pbTiempo.Value = tiempoRestante + 1;
                    pbTiempo.Value = tiempoRestante;
                }
                lblCronometro.Text = string.Format("{0:00}:{1:00}", tiempoRestante / 60, tiempoRestante % 60);
            }
            else
            {
                timerCronometro.Stop();
                lblCronometro.Text = GestorDeIdiomas.Instancia.Obtener("tercera.tiempo");
                FinDelJuego();
            }
        }

        private void JefeFinalTenna_Load(object sender, EventArgs e)
        {

        }
    }
}