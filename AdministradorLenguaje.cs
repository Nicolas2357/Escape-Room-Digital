using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Escape_Room_Digital
{
    public static class AdministradorLenguaje
    {
        private static Dictionary<string, string> _traducciones;
        public static void CargarTraducciones(string rutaArchivo)
        {
            string json = File.ReadAllText(rutaArchivo);
            _traducciones = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
        }
        public static string Traducir(string clave)
        {
            if (_traducciones != null && _traducciones.ContainsKey(clave))
            {
                return _traducciones[clave];
            }
            return clave; // Si no se encuentra la traducción, devuelve la clave original
        }
    }
}
