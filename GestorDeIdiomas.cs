using Escape_Room_Digital.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Escape_Room_Digital.Idiomas
{
    public class GestorDeIdiomas
    {
        // Singleton
        private static GestorDeIdiomas? _instancia;
        public static GestorDeIdiomas Instancia => _instancia ??= new GestorDeIdiomas();
        private GestorDeIdiomas() { }

        // Estado
        private Dictionary<string, string> _textos = new();
        public string IdiomaActual { get; private set; } = "es";

        // Idiomas disponibles para el ComboBox
        public static readonly List<(string Codigo, string Nombre)> IdiomasDisponibles = new()
        {
            ("es", "Español"),
            ("en", "English"),
            ("pt", "Português"),
    ("it", "Italiano"),
    ("fr", "Français")
        };

        // Evento global — todos los UserControls se suscriben aquí
        public event Action? IdiomaModificado;

        // Cargar idioma desde JSON
        public void EstablecerIdioma(string codigo)
        {
            if (IdiomaActual == codigo) return;

            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Idiomas", "Archivos", $"{codigo}.json");

            if (!File.Exists(ruta)) return;

            string json = File.ReadAllText(ruta);
            _textos = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                      ?? new Dictionary<string, string>();

            IdiomaActual = codigo;
            Properties.Settings.Default.Idioma = codigo;
            Properties.Settings.Default.Save();

            IdiomaModificado?.Invoke();
        }

        // Llamar esto una sola vez al arrancar la app
        public void Inicializar()
        {
            string guardado = Properties.Settings.Default.Idioma;
            string codigo = string.IsNullOrEmpty(guardado) ? "es" : guardado;
            IdiomaActual = ""; // forzar carga aunque coincida
            EstablecerIdioma("es");
        }

        // Obtener un texto por clave
        public string Obtener(string clave) =>
            _textos.TryGetValue(clave, out string? valor) ? valor : $"[{clave}]";
    }
}


