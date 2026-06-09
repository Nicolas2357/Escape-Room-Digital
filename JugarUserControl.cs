using Escape_Room_Digital.Idiomas;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class JugarUserControl : UserControl, IControlConMovimiento, IEscenaGrafica, ITraducible
    {
        private Form1 _form;
        private int frameActual = 0;
        private Image[] framesActuales;
        private Image[] framesAnimacionAbajo;
        private Image[] framesAnimacionArriba;
        private Image[] framesAnimacionDerecha;
        private Image[] framesAnimacionIzquierda;

        private IWavePlayer playerMusica;
        private AudioFileReader musicaFile;
        private IWavePlayer playerVoz;
        private AudioFileReader vozFile;
        private IWavePlayer playerEfecto;
        private AudioFileReader efectoFile;

        private string textoCompleto = "";
        private int letraActual = 0;

        private List<Dialogo> listaDialogos;
        private int indiceActual = 0;
        private SegundaEscena gestorEscenas = new SegundaEscena();
        private List<ObjetoInteractuable> objetos;
        private ObjetoInteractuable objetoCercano = null;

        private PictureBox _pbNPCActual = null;
        private EventHandler _handlerSi;
        private EventHandler _handlerNo;
        private SoundPlayer _musicaActual;

        private int _agrandarPixeles;
        private int _agrandarLimite;
        private Image _fondoPendiente;

        public PictureBox Retrato => pbRetratoPanel;
        public Panel Dialogo => pnlDialogoUnico;
        public Control ControlGrafico => this;

        public JugarUserControl()
        {
            InitializeComponent();
            ConfigurarAnimaciones();
            RegistrarHoverBotones(btnVolver, btnSi, btnNo, btnContinuar);
            pnlDialogoUnico.Visible = false;

            VerificarEstadoMision();
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            AplicarTraduccion();
        }
        private int _indice = 0;

        private Button[] BotonesActivos()
        {
            if (btnSi.Visible && btnNo.Visible)
                return new[] { btnSi, btnNo, btnVolver };
            if (btnContinuar.Visible)
                return new[] { btnContinuar, btnVolver };
            return new[] { btnVolver };
        }

        private void ActualizarSeleccion()
        {
            foreach (var btn in new[] { btnSi, btnNo, btnContinuar, btnVolver })
                btn.ForeColor = Color.White;

            var activos = BotonesActivos();
            if (_indice >= activos.Length) _indice = 0;
            activos[_indice].ForeColor = Color.Yellow;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Solo navegar cuando el panel de diálogo está visible
            if (!pnlDialogoUnico.Visible)
                return base.ProcessCmdKey(ref msg, keyData);

            var activos = BotonesActivos();

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
            btnContinuar.Text = G.Obtener("jugar.btn.continuar");
            btnVolver.Text = G.Obtener("jugar.btn.volver");
            btnSi.Text = G.Obtener("jugar.btn.si");
            btnNo.Text = G.Obtener("jugar.btn.no");
            lblMision.Text = G.Obtener("jugar.mision");
        }
        public void CambiarTextoDialogo(string texto) => lblTextoUnico.Text = texto;
        public void CambiarImagen(Image nuevaImagen) => pbRetratoPanel.Image = nuevaImagen;

        public void AnimarAgrandarImagen(int pixelesPorPaso, int limite)
        {
            _agrandarPixeles = pixelesPorPaso;
            _agrandarLimite = limite;
            timerAgrandar.Start();
        }

        public void CambiarFondoConRetraso(Image nuevoFondo, int milisegundos)
        {
            _fondoPendiente = nuevoFondo;
            timerCambioFondo.Interval = milisegundos;
            timerCambioFondo.Start();
        }

        public void SetForm(Form1 form)
        {
            _form = form;
            GestorDePartidas.Instancia.GuardarEstadoActual(EstadoDeJuego.SlotActual, "JugarUserControl");
            objetos = new List<ObjetoInteractuable>
            {
                new NPC_Nerd(pbSpamton, this),
                new NPC_Jester(pbJester, this),
                new NPC_Ghost(pbGhost, this),
                new NPC_ShortSkeleton(pbRoulx, this),
                new NPC_Turtle(pbTenna, this)
            };
        }
        public void ReproducirSonido(string ruta)
        {
            try
            {
                if (playerVoz != null)
                {
                    playerVoz.Stop();
                    playerVoz.Dispose();
                    vozFile?.Dispose();
                }

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
        private void AbrirDialogo(List<Dialogo> lista)
        {
            listaDialogos = lista;
            indiceActual = 0;
            pnlDialogoUnico.Visible = true;
            pnlDialogoUnico.BringToFront();
            SiguienteDialogo();
            ActualizarSeleccion();
        }

        private void SiguienteDialogo()
        {
            if (listaDialogos == null || indiceActual >= listaDialogos.Count)
            {
                CerrarDialogo();
                return;
            }

            btnContinuar.Visible = true;
            btnSi.Visible = btnNo.Visible = false;

            var d = listaDialogos[indiceActual];
            lblNombreUnico.Text = d.Hablante.Nombre;
            textoCompleto = d.Texto;
            letraActual = 0;
            lblTextoUnico.Text = "";

            pbRetratoPanel.Image = null;

            if (d.ExpresionAUsar != null && d.Hablante.Expresiones.ContainsKey(d.ExpresionAUsar))
            {
                Image imagenExpresion = d.Hablante.Expresiones[d.ExpresionAUsar];

                if (objetoCercano is NPC_Nerd || objetoCercano is NPC_Jester || objetoCercano is NPC_Turtle)
                {
                    if (_pbNPCActual != null) _pbNPCActual.Image = imagenExpresion;
                    if (objetoCercano is NPC_Nerd)
                        pbRetratoPanel.Image = d.Hablante.Expresiones["Standing Still"];
                    else if (objetoCercano is NPC_Jester)
                        pbRetratoPanel.Image = d.Hablante.Expresiones["Still"];
                    else if (objetoCercano is NPC_Turtle)
                        pbRetratoPanel.Image = d.Hablante.Expresiones["Still"];
                }
                else
                {
                    pbRetratoPanel.Image = imagenExpresion;
                }
            }
            else
            {
                if (d.Hablante.Expresiones.Count > 0)
                {
                    var listaExp = new List<Image>(d.Hablante.Expresiones.Values);
                    pbRetratoPanel.Image = listaExp[0];
                }
            }

            ReproducirSonido(d.Hablante.RutaVoz);
            timerAnimacionTexto.Start();

            d.EfectoEspecial?.Invoke((IEscenaGrafica)this);
            indiceActual++;
            ActualizarSeleccion();
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

                if (btnSi.Visible || btnNo.Visible)
                    btnContinuar.Visible = false;
            }
        }

        public void CerrarDialogo()
        {
            pnlDialogoUnico.Visible = false;
            _pbNPCActual = null;
            playerVoz?.Stop();
            timerAnimacionTexto.Stop();
            _form?.Select();
        }

        public void ConfigurarBotonesDecision(string textoSi, Action accionSi, string textoNo, Action accionNo)
        {
            btnContinuar.Visible = false;
            btnSi.Visible = btnNo.Visible = true;
            btnSi.Text = textoSi;
            btnNo.Text = textoNo;

            if (_handlerSi != null) btnSi.Click -= _handlerSi;
            if (_handlerNo != null) btnNo.Click -= _handlerNo;

            _handlerSi = (s, e) => accionSi?.Invoke();
            _handlerNo = (s, e) => accionNo?.Invoke();

            btnSi.Click += _handlerSi;
            btnNo.Click += _handlerNo;
            _indice = 0;
            ActualizarSeleccion();
        }
        private void ConfigurarAnimaciones()
        {
            framesAnimacionAbajo = new Image[] { Properties.Resources.SkeletonWalk3, Properties.Resources.SkeletonWalk1, Properties.Resources.SkeletonWalk4, Properties.Resources.SkeletonWalk2 };
            framesAnimacionArriba = new Image[] { Properties.Resources.SkeletonUpWalk, Properties.Resources.SkeletonUpWalk2, Properties.Resources.SkeletonUpWalk3, Properties.Resources.SkeletonUpWalk1 };
            framesAnimacionDerecha = new Image[] { Properties.Resources.SkeletonRightWalk, Properties.Resources.SkeletonRightWalk2, Properties.Resources.SkeletonRightWalk3, Properties.Resources.SkeletonRightWalk1 };
            framesAnimacionIzquierda = new Image[] { Properties.Resources.SkeletonLeftWalk1, Properties.Resources.SkeletonLeftWalk2, Properties.Resources.SkeletonLeftWalk4, Properties.Resources.SkeletonLeftWalk3 };
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
                if (tecla == Keys.Space || tecla == Keys.Enter)
                {
                    if (pnlDialogoUnico.Visible)
                    {
                        if (timerAnimacionTexto.Enabled)
                        {
                            timerAnimacionTexto.Stop();
                            lblTextoUnico.Text = textoCompleto;
                            letraActual = textoCompleto.Length;
                            playerVoz?.Stop();
                            var dActual = listaDialogos[indiceActual - 1];
                            if (dActual.EfectoEspecial == null && !btnSi.Visible) btnContinuar.Visible = true;
                        }
                        else if (btnContinuar.Visible) SiguienteDialogo();
                    }
                    else if (objetoCercano != null) IniciarCharlaSegunNPC();
                    return;
                }

                if (tecla == Keys.W) { timerMoverArriba.Start(); CambiarFramesAnimacion(framesAnimacionArriba); }
                else if (tecla == Keys.A) { timerMoverIzquierda.Start(); CambiarFramesAnimacion(framesAnimacionIzquierda); }
                else if (tecla == Keys.S) { timerMoverAbajo.Start(); CambiarFramesAnimacion(framesAnimacionAbajo); }
                else if (tecla == Keys.D) { timerMoverDerecha.Start(); CambiarFramesAnimacion(framesAnimacionDerecha); }
            }
            else DetenerMovimiento();
        }
        private void VerificarProximidad()
        {
            objetoCercano = null;
            pbSpamtonCloud.Visible = pbGhostCloud.Visible = pbJesterCloud.Visible =
            pbRoulxCloud.Visible = pbTurtleCloud.Visible = false;

            foreach (var obj in objetos)
            {
                if (obj.EstaCerca(pbJugador))
                {
                    objetoCercano = obj;
                    if (obj is NPC_Nerd) pbSpamtonCloud.Visible = true;
                    else if (obj is NPC_Ghost) pbGhostCloud.Visible = true;
                    else if (obj is NPC_Jester) pbJesterCloud.Visible = true;
                    else if (obj is NPC_ShortSkeleton) pbRoulxCloud.Visible = true;
                    else if (obj is NPC_Turtle) pbTurtleCloud.Visible = true;
                    break;
                }
            }
        }

        private void IniciarCharlaSegunNPC()
        {
            DetenerMovimiento();

            if (objetoCercano is NPC_Nerd) { _pbNPCActual = pbSpamton; AbrirDialogo(gestorEscenas.Spamton(this)); }
            else if (objetoCercano is NPC_Jester) { _pbNPCActual = pbJester; AbrirDialogo(gestorEscenas.Jevil(this)); }
            else if (objetoCercano is NPC_Ghost) { _pbNPCActual = pbGhost; AbrirDialogo(gestorEscenas.Napstablook(this)); }
            else if (objetoCercano is NPC_ShortSkeleton) { _pbNPCActual = pbRoulx; AbrirDialogo(gestorEscenas.RoulxKaard(this)); }
            else if (objetoCercano is NPC_Turtle)
            {
                _pbNPCActual = pbTenna;

                AbrirDialogo(gestorEscenas.Tenna(this));

                EstadoDeJuego.HabloConTenna = true;
                lblMision.Visible = false;
            }
        }

        private void VerificarEstadoMision()
        {
            if (EstadoDeJuego.HabloConTenna) lblMision.Visible = false;
        }
        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            frameActual++;
            if (frameActual >= framesActuales.Length) frameActual = 0;
            pbJugador.Image = framesActuales[frameActual];
        }

        private void timerMoverDerecha_Tick(object sender, EventArgs e) { if (pbJugador.Right < Width) pbJugador.Left += 5; VerificarProximidad(); }
        private void timerMoverArriba_Tick(object sender, EventArgs e) { if (pbJugador.Top > 0) pbJugador.Top -= 5; VerificarProximidad(); }
        private void timerMoverIzquierda_Tick(object sender, EventArgs e) { if (pbJugador.Left > 0) pbJugador.Left -= 5; VerificarProximidad(); }
        private void timerMoverAbajo_Tick(object sender, EventArgs e) { if (pbJugador.Bottom < Height) pbJugador.Top += 5; VerificarProximidad(); }

        private void timerAgrandar_Tick(object sender, EventArgs e)
        {
            if (pbJugador.Width < _agrandarLimite)
            {
                pbJugador.Width += _agrandarPixeles;
                pbJugador.Height += _agrandarPixeles;
            }
            else timerAgrandar.Stop();
        }

        private void timerCambioFondo_Tick(object sender, EventArgs e) { BackgroundImage = _fondoPendiente; timerCambioFondo.Stop(); }
        private void RegistrarHoverBotones(params Button[] botones)
        {
            foreach (var btn in botones)
            {
                btn.MouseEnter += (s, e) => btn.ForeColor = Color.Yellow;
                btn.MouseLeave += (s, e) => btn.ForeColor = Color.White;
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (timerAnimacionTexto.Enabled)
            {
                // Saltar animación, mostrar texto completo
                timerAnimacionTexto.Stop();
                lblTextoUnico.Text = textoCompleto;
                letraActual = textoCompleto.Length;
                playerVoz?.Stop();

                // Si el diálogo tiene efecto especial con botones Si/No, ocultamos continuar
                var dActual = listaDialogos[indiceActual - 1];
                if (dActual.EfectoEspecial != null)
                    btnContinuar.Visible = false;
            }
            else
            {
                SiguienteDialogo();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) => _form.MostrarUserControl(new MenuUserControl());

        public void IrANivel(UserControl nivel)
        {
            CerrarDialogo();
            _form.MostrarUserControl(nivel);
        }

        private void btnSi_Click(object sender, EventArgs e)
        {

        }

        private void JugarUserControl_Load(object sender, EventArgs e)
        {

        }

        private void lblMision_Click(object sender, EventArgs e)
        {

        }
    }
}