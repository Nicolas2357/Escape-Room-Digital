using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    abstract class Personaje
    {
        public string Nombre { get; set; }
        public Image Imagen { get; set; }
        public string Dialogo { get; set; }

        public abstract void Interactuar();



    }
}
