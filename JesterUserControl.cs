using Escape_Room_Digital.Idiomas;
using NAudio.CoreAudioApi;
using NAudio.Gui;
using NAudio.Wave;
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
    public partial class JesterUserControl : AcertijoUserControl, ITraducible
    {
        private List<Button> secuenciaCorrecta = new List<Button>();
        private List<Button> secuenciaJugador = new List<Button>();
        private bool esperandoJugador = false;
        private int cantidadNotas = 3;
        private int indexSecuencia = 0;
        private Button botonActual = null;
        private Color colorIluminado = Color.Yellow;
        private int rondaActual = 1;
        private int totalRondas = 3;
        private int cantidadIntentos = 3;

        private Dictionary<Button, string> rutasNotas;
        public JesterUserControl()
        {
            InitializeComponent();
            InicializarRutas();
            InicializarEventosBotones();

            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
            ActualizarSeleccion();
        }
        private int _foco = 0; // 0 = iniciar, 1 = volver

        private void ActualizarSeleccion()
        {
            btnIniciar.ForeColor = Color.White;
            btnVolver.ForeColor = Color.White;
            if (_foco == 0) { btnIniciar.ForeColor = Color.Yellow; btnIniciar.Focus(); }
            else { btnVolver.ForeColor = Color.Yellow; btnVolver.Focus(); }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Si el panel está visible, solo Enter en el botón activo
            if (pnlDialogoJester.Visible)
            {
                if (keyData == Keys.Enter || keyData == Keys.Space)
                {
                    if (btnOkJester.Visible) { btnOkJester.PerformClick(); return true; }
                    if (btnContinuarJester.Visible) { btnContinuarJester.PerformClick(); return true; }
                    if (btnAceptarJester.Visible) { btnAceptarJester.PerformClick(); return true; }
                }
                return true; // anula todo lo demás
            }

            if (keyData == Keys.Down || keyData == Keys.Right)
            {
                _foco = 1; ActualizarSeleccion(); return true;
            }
            if (keyData == Keys.Up || keyData == Keys.Left)
            {
                _foco = 0; ActualizarSeleccion(); return true;
            }
            if (keyData == Keys.Enter)
            {
                if (_foco == 0) btnIniciar.PerformClick();
                else btnVolver.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            btnVolver.Text = G.Obtener("jester.btn.volver");
            btnIniciar.Text = G.Obtener("jester.btn.iniciar");
            btnContinuarJester.Text = G.Obtener("jester.btn.continuar");
            btnOkJester.Text = G.Obtener("jester.btn.ok");
            btnAceptarJester.Text = G.Obtener("jester.btn.aceptar");
            lblNumeroDeRonda.Text = string.Format(G.Obtener("jester.ronda"), rondaActual, totalRondas);
            lblProgreso.Text = string.Format(G.Obtener("jester.progreso"), 0, cantidadNotas);
            lblCantidadDeIntentos.Text = string.Format(G.Obtener("jester.intentos"), cantidadIntentos);
            lblInstrucciones.Text = G.Obtener("jester.instrucciones"); 
            if (!btnIniciar.Enabled == false)
                lblInstrucciones.Text = G.Obtener("jester.inicio");
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            timerIluminar.Stop();
            timerSecuencia.Stop();
            _form.MostrarUserControl(new JugarUserControl());
        }
        private void InicializarRutas()
        {
            string base64 = AppDomain.CurrentDomain.BaseDirectory;
            rutasNotas = new Dictionary<Button, string>
            {
                { btnDo,   Path.Combine(base64, "Audio/Piano/Do.mp3") },
                { btnDoS,  Path.Combine(base64, "Audio/Piano/DoS.mp3") },
                { btnRe,   Path.Combine(base64, "Audio/Piano/Re.mp3") },
                { btnReS,  Path.Combine(base64, "Audio/Piano/ReS.mp3") },
                { btnMi,   Path.Combine(base64, "Audio/Piano/Mi.mp3") },
                { btnFa,   Path.Combine(base64, "Audio/Piano/Fa.mp3") },
                { btnFaS,  Path.Combine(base64, "Audio/Piano/FaS.mp3") },
                { btnSol,  Path.Combine(base64, "Audio/Piano/Sol.mp3") },
                { btnSolS, Path.Combine(base64, "Audio/Piano/SolS.mp3") },
                { btnLa,   Path.Combine(base64, "Audio/Piano/La.mp3") },
                { btnLaS,  Path.Combine(base64, "Audio/Piano/LaS.mp3") },
                { btnSi,   Path.Combine(base64, "Audio/Piano/Si.mp3") },
                { btnDo2,  Path.Combine(base64, "Audio/Piano/Do2.mp3") },
                {btnDoS2,  Path.Combine(base64, "Audio/Piano/DoS2.mp3") },
                { btnRe2,  Path.Combine(base64, "Audio/Piano/Re2.mp3") },
                { btnReS2, Path.Combine(base64, "Audio/Piano/ReS2.mp3")},
                { btnMi2,  Path.Combine(base64, "Audio/Piano/Mi2.mp3") },
            };
        }
        private void InicializarEventosBotones()
        {
            foreach (var par in rutasNotas)
            {
                var boton = par.Key;
                boton.Click += (s, e) =>
                {
                    if (!esperandoJugador) return;
                    ReproducirNota(boton);
                    IluminarBotonJugador(boton);
                    secuenciaJugador.Add(boton);
                    lblProgreso.Text = string.Format(GestorDeIdiomas.Instancia.Obtener("jester.progreso"), secuenciaJugador.Count, cantidadNotas);
                    if (secuenciaJugador.Count == cantidadNotas)
                    {
                        esperandoJugador = false;
                        VerificarSecuencia();
                    }
                };
            }
        }
        private void GenerarSecuencia()
        {
            var random = new Random();
            var teclas = rutasNotas.Keys.ToList();
            secuenciaCorrecta.Clear();
            secuenciaJugador.Clear();
            for (int i = 0; i < cantidadNotas; i++)
                secuenciaCorrecta.Add(teclas[random.Next(teclas.Count)]);
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var G = GestorDeIdiomas.Instancia;
            btnIniciar.Enabled = false;
            esperandoJugador = false;
            GenerarSecuencia();
            indexSecuencia = 0;
            lblNumeroDeRonda.Text = string.Format(G.Obtener("jester.ronda"), rondaActual, totalRondas);
            lblInstrucciones.Text = G.Obtener("jester.instrucciones");
            lblProgreso.Text = string.Format(G.Obtener("jester.progreso"), 0, cantidadNotas);
            lblCantidadDeIntentos.Text = string.Format(G.Obtener("jester.intentos"), cantidadIntentos);
            timerSecuencia.Start();
        }
        private void timerSecuencia_Tick(object sender, EventArgs e)
        {
            if (indexSecuencia < secuenciaCorrecta.Count)
            {
                botonActual = secuenciaCorrecta[indexSecuencia];
                botonActual.BackColor = colorIluminado;
                ReproducirNota(botonActual);
                timerIluminar.Start();
                indexSecuencia++;
            }
            else
            {
                timerSecuencia.Stop();
                esperandoJugador = true;
                lblInstrucciones.Text = GestorDeIdiomas.Instancia.Obtener("jester.turno"); btnIniciar.Enabled = true;
            }
        }

        private void timerIluminar_Tick(object sender, EventArgs e)
        {
            timerIluminar.Stop();
            if (botonActual != null)
            {
                bool esNegra = botonActual == btnDoS || botonActual == btnReS ||
                               botonActual == btnFaS || botonActual == btnSolS ||
                               botonActual == btnLaS || botonActual == btnDoS2 ||
                               botonActual == btnReS2;
                botonActual.BackColor = esNegra ? Color.Black : Color.White;
            }
        }
        private void IluminarBotonJugador(Button boton)
        {
            bool esNegra = boton == btnDoS || boton == btnReS ||
                           boton == btnFaS || boton == btnSolS ||
                           boton == btnLaS || boton == btnDoS2 ||
                           boton == btnReS2;
            Color colorOriginal = esNegra ? Color.Black : Color.White;
            boton.BackColor = colorIluminado;
            t.Interval = 300;
            t.Tick += (s, e) =>
            {
                boton.BackColor = colorOriginal;
                t.Stop();
                t.Dispose();
            };
            t.Start();
        }
        private void ReproducirNota(Button boton)
        {
            if (!rutasNotas.ContainsKey(boton)) return;
            string ruta = rutasNotas[boton];
            if (!File.Exists(ruta)) return;

            try
            {
                var audioFile = new AudioFileReader(ruta);
                var outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
                outputDevice.PlaybackStopped += (s, e) =>
                {
                    outputDevice.Dispose();
                    audioFile.Dispose();
                };
            }
            catch { }
        }
        private void VerificarSecuencia()
        {
            var G = GestorDeIdiomas.Instancia;
            bool correcto = secuenciaCorrecta.SequenceEqual(secuenciaJugador);

            if (correcto)
            {
                if (rondaActual >= totalRondas)
                {
                    pnlDialogoJester.Visible = true;
                    btnOkJester.Visible = true;
                    btnOkJester.ForeColor = Color.Yellow; 
                    btnOkJester.Focus();
                    btnContinuarJester.Visible = false;
                    lblDialogoJester.Text = G.Obtener("jester.exito.final");
                    EstadoDeJuego.NivelJesterCompletado = true;
                    EstadoDeJuego.cantidadNivelesCompletados++;
                    GestorDePartidas.Instancia.GuardarEstadoActual(EstadoDeJuego.SlotActual, "JugarUserControl");
                }
                else
                {
                    rondaActual++;
                    cantidadNotas++;
                    pnlDialogoJester.Visible = true;
                    btnOkJester.Visible = false;
                    btnContinuarJester.ForeColor = Color.Yellow; 
                    btnContinuarJester.Focus();
                    btnContinuarJester.Visible = true;
                    lblDialogoJester.Text = string.Format(G.Obtener("jester.exito.ronda"), rondaActual);
                    secuenciaJugador.Clear();
                    lblProgreso.Text = string.Format(G.Obtener("jester.progreso"), 0, cantidadNotas);
                    lblInstrucciones.Text = G.Obtener("jester.sig.ronda");
                    btnIniciar.Enabled = true;
                }
            }
            else
            {
                cantidadIntentos--;
                if (cantidadIntentos > 0)
                {
                    pnlDialogoJester.Visible = true;
                    btnContinuarJester.Visible = true;
                    btnContinuarJester.ForeColor = Color.Yellow; 
                    btnContinuarJester.Focus();
                    btnOkJester.Visible = false;
                    lblDialogoJester.Text = G.Obtener("jester.fail.intento");
                    secuenciaJugador.Clear();
                    lblProgreso.Text = string.Format(G.Obtener("jester.progreso"), 0, cantidadNotas);
                    lblInstrucciones.Text = G.Obtener("jester.sig.intento");
                    lblCantidadDeIntentos.Text = string.Format(G.Obtener("jester.intentos"), cantidadIntentos);
                    btnIniciar.Enabled = true;
                }
                else
                {
                    timerIluminar.Stop();
                    timerSecuencia.Stop();
                    secuenciaCorrecta.Clear();
                    pnlDialogoJester.Visible = true;
                    btnAceptarJester.Visible = true;
                    btnAceptarJester.ForeColor = Color.Yellow; 
                    btnAceptarJester.Focus();
                    btnContinuarJester.Visible = false;
                    btnOkJester.Visible = false;
                    lblDialogoJester.Text = G.Obtener("jester.fail.final");
                }
            }
         
        }

        private void pnlDialogoJester_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3;
            Color colorBorde = Color.White;

            using (Pen pen = new Pen(colorBorde, grosor))
            {
                int offset = grosor / 2;
                e.Graphics.DrawRectangle(pen,
                    offset,
                    offset,
                    pnlDialogoJester.ClientSize.Width - grosor,
                    pnlDialogoJester.ClientSize.Height - grosor);
            }
        }

        private void btnOkJester_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new JugarUserControl());
        }

        private void btnContinuarJester_Click(object sender, EventArgs e)
        {
            pnlDialogoJester.Visible = false;
        }

        private void btnAceptarJester_Click(object sender, EventArgs e)
        {
            _form.MostrarUserControl(new MenuUserControl());
        }

        private void JesterUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
