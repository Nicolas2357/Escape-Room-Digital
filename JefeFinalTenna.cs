using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;

namespace Escape_Room_Digital.UserControls
{
    public partial class JefeFinalTenna : UserControl, IEscenaGrafica
    {
        private Form1 _form;
        private int tiempoRestante = 100;
        private List<(AcertijoTexto acertijo, Image expresion)> preguntas;

        private IWavePlayer playerVoz;
        private AudioFileReader vozFile;
        private IWavePlayer playerMusica;
        private AudioFileReader musicaFile;

        private List<Dialogo> listaDialogos;
        private int indiceDialogo = 0;

        private int indicePregunta = 0;
        private int respuestasCorrectas = 0;
        private const int RespuestasParaGanar = 3;

        private string textoCompleto = "";
        private int letraActual = 0;

        private bool enPreguntas = false;

        private Image _fondoPendiente;


        public PictureBox Retrato => pbRetratoPanel;
        public Panel Dialogo => pnlDialogoUnico;
        public Control ControlGrafico => this;

        public void SetForm(Form1 form) => _form = form;
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
            pbRetratoPanel.Image = null;
            lblTextoUnico.BackColor = Color.Black;
            lblTextoUnico.ForeColor = Color.White;
            lblStand.Text = EstadoDeJuego.NombreJugador;
            pnlDialogoUnico.Visible = true;
            txtBoxRespuesta.Visible = false;
            btnValidar.Visible = false;

            btnContinuar.Visible = false;
            btnReintentar.Visible = false;
            btnSalirFinal.Visible = false;
            RegistrarHoverBotones(btnRegresar, btnContinuar, btnValidar, btnReintentar, btnSalirFinal);
            IniciarEscena();
        }

        private void IniciarEscena()
        {
            tiempoRestante = 300; 
            timerCronometro.Stop();
            TerceraEscena escena = new TerceraEscena();
            listaDialogos = escena.CargarEscena();
            preguntas = escena.CargarPreguntas();
            indiceDialogo = 0;
            enPreguntas = false;
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

            if (d.ExpresionAUsar != null && d.Hablante.Expresiones.ContainsKey(d.ExpresionAUsar))
                pictureBox2.Image = d.Hablante.Expresiones[d.ExpresionAUsar];

            ReproducirSonido(d.Hablante.RutaVoz);
            d.EfectoEspecial?.Invoke(this);
            indiceDialogo++;
            timerAnimacionTexto.Start();
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
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            (AcertijoTexto acertijo, Image _) = preguntas[indicePregunta];
            bool correcto = acertijo.ValidarRespuesta(txtBoxRespuesta.Text);

            if (correcto)
            {
                respuestasCorrectas++;

                if (respuestasCorrectas >= RespuestasParaGanar)
                {
                    timerCronometro.Stop();
                    MostrarFeedback($"¡Lograste {respuestasCorrectas} respuestas correctas! ¡Ganaste!");
                    txtBoxRespuesta.Visible = false;
                    btnValidar.Visible = false;
                    btnContinuar.Visible = true;
                    indicePregunta = preguntas.Count;
                    return;
                }

                MostrarFeedback($"¡Correcto! Llevas {respuestasCorrectas} de {RespuestasParaGanar} necesarias.");
                indicePregunta++;
                txtBoxRespuesta.Visible = false;
                btnValidar.Visible = false;
                btnContinuar.Visible = true;
            }
            else
            {
                MostrarFeedback("Incorrecto, intenta de nuevo.");
                txtBoxRespuesta.Text = "";
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
                lblTextoUnico.Text = $"Obtuviste {respuestasCorrectas}/{preguntas.Count} respuestas correctas.\n¡Necesitabas {RespuestasParaGanar} para ganar!";
                lblNombreUnico.Text = "Tenna";
                btnContinuar.Visible = false;
                txtBoxRespuesta.Visible = false;
                btnValidar.Visible = false;

                btnReintentar.Visible = true;
                btnSalirFinal.Visible = true;
            }
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
                lblCronometro.Text = "¡Tiempo agotado!";
                FinDelJuego();
            }
        }
    }
}