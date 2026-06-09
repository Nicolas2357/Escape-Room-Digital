using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Escape_Room_Digital.Idiomas
{
    public class GestorDePartidas
    {
        private static GestorDePartidas? _instancia;
        public static GestorDePartidas Instancia => _instancia ??= new GestorDePartidas();
        private GestorDePartidas() { }

        private static readonly string Ruta = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Idiomas", "Archivos", "partidas.json");

        public List<SlotPartida> CargarSlots()
        {
            if (!File.Exists(Ruta))
                return SlotsPorDefecto();

            try
            {
                string json = File.ReadAllText(Ruta);
                var slots = JsonSerializer.Deserialize<List<SlotPartida>>(json);
                return slots ?? SlotsPorDefecto();
            }
            catch { return SlotsPorDefecto(); }
        }

        public void GuardarSlot(SlotPartida slot)
        {
            var slots = CargarSlots();
            var existente = slots.FirstOrDefault(s => s.Slot == slot.Slot);
            if (existente != null) slots.Remove(existente);
            slot.Vacio = false;
            slot.FechaGuardado = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            slots.Add(slot);
            slots = slots.OrderBy(s => s.Slot).ToList();
            File.WriteAllText(Ruta, JsonSerializer.Serialize(slots, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void BorrarSlot(int numeroSlot)
        {
            var slots = CargarSlots();
            var slot = slots.FirstOrDefault(s => s.Slot == numeroSlot);
            if (slot != null)
            {
                slot.Vacio = true;
                slot.Nombre = "";
                slot.Escena = "";
                slot.FechaGuardado = "";
                slot.NivelNerdCompletado = false;
                slot.NivelJesterCompletado = false;
                slot.NivelGhostCompletado = false;
                slot.NivelSkeletonCompletado = false;
                slot.NivelesCompletados = 0;
                slot.HabloConTenna = false;
            }
            File.WriteAllText(Ruta, JsonSerializer.Serialize(slots, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void GuardarEstadoActual(int numeroSlot, string escena)
        {
            var slot = new SlotPartida
            {
                Slot = numeroSlot,
                Nombre = EstadoDeJuego.NombreJugador,
                Idioma = GestorDeIdiomas.Instancia.IdiomaActual,
                Escena = escena,
                NivelNerdCompletado = EstadoDeJuego.NivelNerdCompletado,
                NivelJesterCompletado = EstadoDeJuego.NivelJesterCompletado,
                NivelGhostCompletado = EstadoDeJuego.NivelGhostCompletado,
                NivelSkeletonCompletado = EstadoDeJuego.NivelShortSkeletonCompletado,
                NivelesCompletados = EstadoDeJuego.cantidadNivelesCompletados,
                HabloConTenna = EstadoDeJuego.HabloConTenna
            };
            GuardarSlot(slot);
        }

        public void CargarEstado(SlotPartida slot)
        {
            EstadoDeJuego.NombreJugador = slot.Nombre;
            EstadoDeJuego.NivelNerdCompletado = slot.NivelNerdCompletado;
            EstadoDeJuego.NivelJesterCompletado = slot.NivelJesterCompletado;
            EstadoDeJuego.NivelGhostCompletado = slot.NivelGhostCompletado;
            EstadoDeJuego.NivelShortSkeletonCompletado = slot.NivelSkeletonCompletado;
            EstadoDeJuego.cantidadNivelesCompletados = slot.NivelesCompletados;
            EstadoDeJuego.HabloConTenna = slot.HabloConTenna;
            GestorDeIdiomas.Instancia.EstablecerIdioma(slot.Idioma);
        }

        private List<SlotPartida> SlotsPorDefecto()
        {
            var slots = new List<SlotPartida>();
            for (int i = 1; i <= 5; i++)
                slots.Add(new SlotPartida { Slot = i, Vacio = true });
            return slots;
        }
    }
}