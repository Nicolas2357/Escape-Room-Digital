using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public class AcertijoTexto : Acertijo
    {
        private string _respuestaCorrecta { get; set; }
        
        public AcertijoTexto(string pregunta, string respuestaCorrecta, int tiempoLimite, int intentos = 1)
        {
            Pregunta = pregunta;
            _respuestaCorrecta = respuestaCorrecta.ToLower();
            TiempoLimite = tiempoLimite;
            Intentos = intentos;
        }
        public override bool ValidarRespuesta(string respuesta)
        {
            return respuesta.ToLower().Trim() == _respuestaCorrecta;
        }

    }
}
