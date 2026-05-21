using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Escape_Room_Digital
{
    public class PersonajeNuevo
    {
        public string Nombre { get; set; }
        public string RutaVoz { get; set; }
        public bool EsAudioLargo { get; set; }
        public Dictionary<string, Image> Expresiones { get; set; }
        public PersonajeNuevo(string nombre, string rutaVoz, bool esLargo = false)
        {
            Nombre = nombre;
            RutaVoz = rutaVoz;
            EsAudioLargo = esLargo;
            Expresiones = new Dictionary<string, Image>();
        }
    }
}
