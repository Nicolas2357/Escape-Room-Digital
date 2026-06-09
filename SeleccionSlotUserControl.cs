using Escape_Room_Digital.Idiomas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Escape_Room_Digital.UserControls
{
    public partial class SeleccionSlotUserControl : UserControl, ITraducible
    {
        private Form1 _form;
        private List<SlotPartida> _slots;
        private Button[] _botonesSlot;
        private Button[] _botonesBorrar;
        private int _indice = 0;

        public SeleccionSlotUserControl()
        {
            InitializeComponent();
        }

        public void SetForm(Form1 form)
        {
            GestorDeIdiomas.Instancia.IdiomaModificado += AplicarTraduccion;
            _form = form;
            _botonesSlot = new[] { btnSlot1, btnSlot2, btnSlot3, btnSlot4, btnSlot5 };
            _botonesBorrar = new[] { btnBorrar1, btnBorrar2, btnBorrar3, btnBorrar4, btnBorrar5 };

            for (int i = 0; i < 5; i++)
            {
                int numero = i + 1;
                _botonesSlot[i].Click += (s, e) => SeleccionarSlot(numero);
                _botonesBorrar[i].Click += (s, e) => BorrarSlot(numero);
            }

            // Hover: amarillo solo mientras el mouse está encima
            foreach (var btn in _botonesSlot.Concat(_botonesBorrar).Append(btnRegresar))
            {
                var b = btn;
                b.MouseEnter += (s, e) => b.ForeColor = Color.Yellow;
                b.MouseLeave += (s, e) => b.ForeColor = Color.White;
            }

            // Cancelar
            btnRegresar.Click += (s, e) => _form.MostrarUserControl(new MenuUserControl());

            CargarSlots();
        }
        public void AplicarTraduccion()
        {
            var G = GestorDeIdiomas.Instancia;
            lblTitulo.Text = G.Obtener("slots.titulo");
            btnRegresar.Text = G.Obtener("slots.regresar");

            for (int i = 0; i < 5; i++)
            {
                var slot = _slots?.FirstOrDefault(s => s.Slot == i + 1);
                if (slot == null || slot.Vacio)
                    _botonesSlot[i].Text = string.Format(G.Obtener("slots.vacio"), i + 1);
                else
                    _botonesSlot[i].Text = string.Format(G.Obtener("slots.ocupado"), i + 1, slot.Nombre, slot.FechaGuardado);

                _botonesBorrar[i].Text = string.Format(G.Obtener("slots.borrar"), i + 1);
            }
        }

        private void CargarSlots()
        {
            _slots = GestorDePartidas.Instancia.CargarSlots();

            for (int i = 0; i < 5; i++)
            {
                var slot = _slots.FirstOrDefault(s => s.Slot == i + 1);
                if (slot == null || slot.Vacio)
                {
                    _botonesSlot[i].ForeColor = Color.White;
                    _botonesBorrar[i].Visible = false;
                }
                else
                {
                    _botonesSlot[i].ForeColor = Color.White;
                    _botonesBorrar[i].Visible = true;
                    _botonesBorrar[i].ForeColor = Color.White;
                }
            }

            AplicarTraduccion(); 
            _indiceFila = 0;
            _enColumnaBorrar = false;
            ActualizarSeleccion();
        }


        private void ActualizarSeleccion()
        {
            // Resetear todos
            foreach (var btn in _botonesSlot.Concat(_botonesBorrar).Append(btnRegresar))
                btn.ForeColor = Color.White;

            if (_indiceFila == 5) // regresar
            {
                btnRegresar.ForeColor = Color.Yellow;
            }
            else if (_enColumnaBorrar && _botonesBorrar[_indiceFila].Visible)
            {
                _botonesBorrar[_indiceFila].ForeColor = Color.Yellow;
            }
            else
            {
                _enColumnaBorrar = false;
                _botonesSlot[_indiceFila].ForeColor = Color.Yellow;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (_indiceFila == 5) return true; // regresar, no bajar más
                _indiceFila++;
                // Si subimos a fila 5 vamos a regresar, salir de columna borrar
                if (_indiceFila == 5) _enColumnaBorrar = false;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Up)
            {
                if (_indiceFila == 0) return true; // slot1 o borrar1, no subir más
                _indiceFila--;
                ActualizarSeleccion();
                return true;
            }
            if (keyData == Keys.Right)
            {
                // Solo ir a borrar si estamos en un slot (no en regresar) y el botón es visible
                if (_indiceFila < 5 && !_enColumnaBorrar && _botonesBorrar[_indiceFila].Visible)
                {
                    _enColumnaBorrar = true;
                    ActualizarSeleccion();
                }
                return true;
            }
            if (keyData == Keys.Left)
            {
                if (_enColumnaBorrar)
                {
                    _enColumnaBorrar = false;
                    ActualizarSeleccion();
                }
                return true;
            }
            if (keyData == Keys.Enter || keyData == Keys.Space)
            {
                if (_indiceFila == 5)
                    btnRegresar.PerformClick();
                else if (_enColumnaBorrar)
                    _botonesBorrar[_indiceFila].PerformClick();
                else
                    _botonesSlot[_indiceFila].PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // ── Lógica ─────────────────────────────────────────────────────
        private void SeleccionarSlot(int numero)
        {
            var slot = _slots.FirstOrDefault(s => s.Slot == numero);

            if (slot == null || slot.Vacio)
            {
                EstadoDeJuego.SlotActual = numero;
                EstadoDeJuego.NombreJugador = "Desconocido";
                EstadoDeJuego.NivelNerdCompletado = false;
                EstadoDeJuego.NivelJesterCompletado = false;
                EstadoDeJuego.NivelGhostCompletado = false;
                EstadoDeJuego.NivelShortSkeletonCompletado = false;
                EstadoDeJuego.cantidadNivelesCompletados = 0;
                EstadoDeJuego.HabloConTenna = false;
                _form.MostrarUserControl(new InicioDelJuegoUserControl());
            }
            else
            {
                EstadoDeJuego.SlotActual = numero;
                GestorDePartidas.Instancia.CargarEstado(slot);
                switch (slot.Escena)
                {
                    case "JugarUserControl":
                        _form.MostrarUserControl(new JugarUserControl());
                        break;
                    case "InicioDelJuegoUserControl":
                        _form.MostrarUserControl(new InicioDelJuegoUserControl());
                        break;
                    default:
                        _form.MostrarUserControl(new JugarUserControl());
                        break;
                }
            }
        }

        private void BorrarSlot(int numero)
        {
            var resultado = MessageBox.Show(
                "¿Estás seguro de que quieres borrar esta partida?",
                "Borrar partida",
                MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                GestorDePartidas.Instancia.BorrarSlot(numero);
                CargarSlots();
            }
        }

        private void SeleccionSlotUserControl_Load(object sender, EventArgs e) { }
        private void btnSlot4_Click(object sender, EventArgs e) { }
        private bool _enColumnaBorrar = false;
        private int _indiceFila = 0; // 0-4 para los slots, 0-4 para borrar, 0 para regresar
    }
}