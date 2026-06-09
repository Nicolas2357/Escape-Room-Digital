using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public interface IEscenaGrafica
    {
        PictureBox Retrato{ get; }
        Panel Dialogo { get; }
        Control ControlGrafico { get; }

        void CambiarFondoConRetraso(Image nuevoFondo, int milisegundos);
        void CambiarImagen(Image nuevaImagen);
        void AnimarAgrandarImagen(int pixelesPorPaso, int limite);
        void ReproducirMusica(string rutaArchivo);
        void CambiarTextoDialogo(string texto);
        void ReproducirSonido(string ruta);

    }
}
