using Escape_Room_Digital.Idiomas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Escape_Room_Digital
{
    public class EscenaInicial
    {
        public static string NombreUsuario = "Desconocido";
        public List<Dialogo> CargarEscena()
        {
            var G = GestorDeIdiomas.Instancia;

            PersonajeNuevo Tenna = new PersonajeNuevo("Tenna", "TennaVoice.wav", true);
            Tenna.Expresiones.Add("Bow", Properties.Resources.TennaBow);
            Tenna.Expresiones.Add("Crashing Out", Properties.Resources.TennaCrashingOut);
            Tenna.Expresiones.Add("Dancing Gangam Style", Properties.Resources.TennaDancingGangamStyle);
            Tenna.Expresiones.Add("Doing Circles", Properties.Resources.TennaDoingCircles);
            Tenna.Expresiones.Add("Happy", Properties.Resources.TennaHappy);
            Tenna.Expresiones.Add("In Suit", Properties.Resources.TennaInSuit);
            Tenna.Expresiones.Add("Kicking", Properties.Resources.TennaKicking);
            Tenna.Expresiones.Add("Laughing", Properties.Resources.TennaLaughing);
            Tenna.Expresiones.Add("Running", Properties.Resources.TennaRunning);
            Tenna.Expresiones.Add("Talking", Properties.Resources.TennaTalkingImage);
            Tenna.Expresiones.Add("Pointing", Properties.Resources.TennaPointing);
            Tenna.Expresiones.Add("Whispering", Properties.Resources.TennaWhispering);
            Tenna.Expresiones.Add("Surprised", Properties.Resources.TennaSurprised);

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.01"), ExpresionAUsar = "Talking" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.02"), ExpresionAUsar = "Talking" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.03"), ExpresionAUsar = "Talking",
                    EfectoEspecial = (e) =>
                    {
                        var objeto = e.ControlGrafico.Controls.Find("pbTennaCloud", true).FirstOrDefault();
                        if (objeto != null) objeto.Visible = true;
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.04"), ExpresionAUsar = "Pointing",
                    EfectoEspecial = (e) =>
                    {
                        var objeto = e.ControlGrafico.Controls.Find("pbTennaCloud", true).FirstOrDefault();
                        objeto.Visible = false;
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.05"), ExpresionAUsar = "Running",
                    EfectoEspecial = (e) => { e.AnimarAgrandarImagen(5, 400); }
                },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.06"), ExpresionAUsar = "Dancing Gangam Style" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.07"), ExpresionAUsar = "Happy" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.08"), ExpresionAUsar = "Laughing" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.09"), ExpresionAUsar = "Bow" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.10"), ExpresionAUsar = "Doing Circles",
                    EfectoEspecial = (e) =>
                    {
                        var txt = e.ControlGrafico.Controls.Find("txtNombre", true).FirstOrDefault();
                        if (txt != null) txt.Visible = true;
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.11"), ExpresionAUsar = "In Suit",
                    EfectoEspecial = (e) =>
                    {
                        var txt = e.ControlGrafico.Controls.Find("txtNombre", true).FirstOrDefault() as TextBox;
                        if (txt != null)
                        {
                            EscenaInicial.NombreUsuario = txt.Text;
                            EstadoDeJuego.NombreJugador = txt.Text;
                            txt.Visible = false;
                        }
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = "placeholder", ExpresionAUsar = "Doing Circles",
                    EfectoEspecial = (e) =>
                    {
                        // {0} se reemplaza con el nombre del jugador
                        string plantilla = G.Obtener("inicio.dialogo.12");
                        e.CambiarTextoDialogo(string.Format(plantilla, EstadoDeJuego.NombreJugador));
                    }
                },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.13"), ExpresionAUsar = "Crashing Out" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.14"), ExpresionAUsar = "Whispering" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.15"), ExpresionAUsar = "Bow",
                    EfectoEspecial = (e) => { e.ReproducirSonido("Audio/Claps.wav"); }
                },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.16"), ExpresionAUsar = "Surprised" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.17"), ExpresionAUsar = "Kicking",
                    EfectoEspecial = (e) =>
                    {
                        e.CambiarFondoConRetraso(Properties.Resources.TennaBackground1, 500);
                        e.ReproducirSonido("Audio/Kick.wav");
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.18"), ExpresionAUsar = "Doing Circles",
                    EfectoEspecial = (e) => { e.ReproducirMusica("Audio/HipShop.wav"); }
                },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.19"), ExpresionAUsar = "Pointing" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.20"), ExpresionAUsar = "Pointing" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.21"), ExpresionAUsar = "Happy",
                    EfectoEspecial = (e) =>
                    {
                        var objeto3 = e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                        if (objeto3 != null) objeto3.Visible = false;
                        var objeto  = e.ControlGrafico.Controls.Find("btnSiTenna",        true).FirstOrDefault() as Button;
                        if (objeto  != null) objeto.Visible  = true;
                        var objeto2 = e.ControlGrafico.Controls.Find("btnNoTenna",        true).FirstOrDefault() as Button;
                        if (objeto2 != null) objeto2.Visible = true;
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.22"), ExpresionAUsar = "Whispering",
                    EfectoEspecial = (e) =>
                    {
                        var objeto3 = e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                        if (objeto3 != null) objeto3.Visible = true;
                        var objeto2 = e.ControlGrafico.Controls.Find("btnNoTenna",        true).FirstOrDefault() as Button;
                        if (objeto2 != null) objeto2.Visible = false;
                        var objeto  = e.ControlGrafico.Controls.Find("btnSiTenna",        true).FirstOrDefault() as Button;
                        if (objeto  != null) objeto.Visible  = false;
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.23"), ExpresionAUsar = "Bow",
                    EfectoEspecial = (e) => { e.ReproducirSonido("Audio/Claps.wav"); }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = G.Obtener("inicio.dialogo.24"), ExpresionAUsar = "Pointing",
                    EfectoEspecial = (e) =>
                    {
                        var objeto  = e.ControlGrafico.Controls.Find("btnEmpezarTenna",   true).FirstOrDefault() as Button;
                        if (objeto  != null) objeto.Visible  = true;
                        var objeto3 = e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                        if (objeto3 != null) objeto3.Visible = false;
                    }
                }
            };
        }
    }
}