using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public class AcertijoAleatorio : Acertijo
    {
        private string _respuestaCorrecta;

        public AcertijoAleatorio(Func<int, (string pregunta, string respuesta)> generador, int min, int max)
        {
            var rng = new Random();
            int valor = rng.Next(min, max + 1);
            var (pregunta, respuesta) = generador(valor);
            Pregunta = pregunta;
            _respuestaCorrecta = respuesta.ToLower().Trim();
        }

        public override bool ValidarRespuesta(string respuesta)
        {
            return respuesta.ToLower().Trim() == _respuestaCorrecta;
        }
    }
}
