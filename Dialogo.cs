using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public class Dialogo
    {
        public PersonajeNuevo Hablante { get; set; }
        public string Texto { get; set; }
        public string ExpresionAUsar {  get; set; }
        public Action<IEscenaGrafica> EfectoEspecial { get; set; }

    }
}
