using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public abstract class Acertijo : IResoluble
    {
        public string Pregunta { get; set; }
        public int Intentos { get; set; } = 1;
        public int TiempoLimite { get; set; }
        public int Puntaje { get; set; }

        public abstract bool ValidarRespuesta(string respuesta);
        public bool ResolverRespuesta(string respuesta)
        {
            Intentos--;
            return ValidarRespuesta(respuesta);
        }
    }
}
