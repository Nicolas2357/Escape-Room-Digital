using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital.Fonts
{
    public static class GestorFuentes
    {
        private static PrivateFontCollection fuentes = new PrivateFontCollection();

        static GestorFuentes()
        {
            fuentes.AddFontFile("Fonts/determinationmonoweb-webfont.ttf");
        }

        public static Font Obtener(float tamaño, FontStyle estilo = FontStyle.Regular)
        {
            return new Font(fuentes.Families[0], tamaño, estilo);
        }
    }
}