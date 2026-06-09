using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital.Idiomas
{
    public class SlotPartida
    {
        public int Slot { get; set; }
        public bool Vacio { get; set; } = true;
        public string Nombre { get; set; } = "";
        public string Idioma { get; set; } = "es";
        public string Escena { get; set; } = "";
        public bool NivelNerdCompletado { get; set; }
        public bool NivelJesterCompletado { get; set; }
        public bool NivelGhostCompletado { get; set; }
        public bool NivelSkeletonCompletado { get; set; }
        public int NivelesCompletados { get; set; }
        public bool HabloConTenna { get; set; }
        public string FechaGuardado { get; set; } = "";
    }
}