using Escape_Room_Digital.Idiomas;
using Escape_Room_Digital.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Escape_Room_Digital
{
    public class SegundaEscena
    {
        public List<Dialogo> Spamton(JugarUserControl uc)
        {
            var G = GestorDeIdiomas.Instancia;
            PersonajeNuevo Spamton = new PersonajeNuevo("Spamton", "SpamtonVoice.wav", true);
            Spamton.Expresiones.Add("Laughing", Properties.Resources.SpamtonTalking);
            Spamton.Expresiones.Add("Dancing", Properties.Resources.SpamtonDance);
            Spamton.Expresiones.Add("Standing Still", Properties.Resources.SpamtonStill);
            Spamton.Expresiones.Add("Quiet", Properties.Resources.SpamtonQuiet);

            if (EstadoDeJuego.NivelNerdCompletado)
            {
                return new List<Dialogo>
            {
                new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.completado.01"), ExpresionAUsar = "Standing Still" },
                new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.completado.02"), ExpresionAUsar = "Quiet" }
            };
            }

            return new List<Dialogo>
        {
            new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.01"), ExpresionAUsar = "Laughing" },
            new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.02"), ExpresionAUsar = "Dancing" },
            new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.03"), ExpresionAUsar = "Standing Still" },
            new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.04"), ExpresionAUsar = "Dancing" },
            new Dialogo { Hablante = Spamton, Texto = G.Obtener("spamton.05"), ExpresionAUsar = "Quiet",
                EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                    G.Obtener("spamton.btn.si"), () => { uc.IrANivel(new NerdUserControl()); },
                    G.Obtener("spamton.btn.no"), () => { uc.CerrarDialogo(); }
                )
            }
        };
        }

        public List<Dialogo> Jevil(JugarUserControl uc)
        {
            var G = GestorDeIdiomas.Instancia;
            PersonajeNuevo Jevil = new PersonajeNuevo("Jevil", "JevilVoice.wav", true);
            Jevil.Expresiones.Add("Still", Properties.Resources.Jevil);
            Jevil.Expresiones.Add("Sad", Properties.Resources.JevilSad);
            Jevil.Expresiones.Add("Tounge Out", Properties.Resources.JevilToungeOut);

            if (EstadoDeJuego.NivelJesterCompletado)
            {
                return new List<Dialogo>
            {
                new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.completado.01"), ExpresionAUsar = "Still" },
                new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.completado.02"), ExpresionAUsar = "Sad" }
            };
            }

            return new List<Dialogo>
        {
            new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.01"), ExpresionAUsar = "Tounge Out" },
            new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.02"), ExpresionAUsar = "Still" },
            new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.03"), ExpresionAUsar = "Sad" },
            new Dialogo { Hablante = Jevil, Texto = G.Obtener("jevil.04"), ExpresionAUsar = "Sad",
                EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                    G.Obtener("jevil.btn.si"), () => { uc.IrANivel(new JesterUserControl()); },
                    G.Obtener("jevil.btn.no"), () => { uc.CerrarDialogo(); }
                )
            }
        };
        }

        public List<Dialogo> Napstablook(JugarUserControl uc)
        {
            var G = GestorDeIdiomas.Instancia;
            PersonajeNuevo Napstablook = new PersonajeNuevo("Napstablook", "NapstablookVoice.wav", true);
            Napstablook.Expresiones.Add("Normal", Properties.Resources.GhostImage);

            if (EstadoDeJuego.NivelGhostCompletado)
            {
                return new List<Dialogo>
            {
                new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.completado.01"), ExpresionAUsar = "Normal" },
                new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.completado.02"), ExpresionAUsar = "Normal" }
            };
            }

            return new List<Dialogo>
        {
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.01") },
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.02") },
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.03") },
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.04") },
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.05") },
            new Dialogo { Hablante = Napstablook, Texto = G.Obtener("napsta.06"),
                EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                    G.Obtener("napsta.btn.si"), () => { uc.IrANivel(new GhostUserControl()); },
                    G.Obtener("napsta.btn.no"), () => { uc.CerrarDialogo(); }
                )
            }
        };
        }

        public List<Dialogo> RoulxKaard(JugarUserControl uc)
        {
            var G = GestorDeIdiomas.Instancia;
            PersonajeNuevo RoulxKaard = new PersonajeNuevo("Roulx", "RoulxVoice.wav", true);
            RoulxKaard.Expresiones.Add("Blink", Properties.Resources.RoulxBlink);
            RoulxKaard.Expresiones.Add("Scared", Properties.Resources.RoulxScared);
            RoulxKaard.Expresiones.Add("Scared Away", Properties.Resources.RoulxScared1);
            RoulxKaard.Expresiones.Add("Scared Talking", Properties.Resources.RoulxScaredTalking);
            RoulxKaard.Expresiones.Add("Talking", Properties.Resources.RoulxTalking);

            if (EstadoDeJuego.NivelShortSkeletonCompletado)
            {
                return new List<Dialogo>
            {
                new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.completado.01"), ExpresionAUsar = "Talking" },
                new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.completado.02"), ExpresionAUsar = "Blink" }
            };
            }

            return new List<Dialogo>
        {
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.01"), ExpresionAUsar = "Talking" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.02"), ExpresionAUsar = "Scared Talking" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.03"), ExpresionAUsar = "Scared Away" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.04"), ExpresionAUsar = "Talking" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.05"), ExpresionAUsar = "Talking" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.06"), ExpresionAUsar = "Blink" },
            new Dialogo { Hablante = RoulxKaard, Texto = G.Obtener("roulx.07"), ExpresionAUsar = "Talking",
                EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                    G.Obtener("roulx.btn.si"), () => { uc.IrANivel(new ShortSkeletonUserControl()); },
                    G.Obtener("roulx.btn.no"), () => { uc.CerrarDialogo(); }
                )
            }
        };
        }

        public List<Dialogo> Tenna(JugarUserControl uc)
        {
            var G = GestorDeIdiomas.Instancia;
            PersonajeNuevo Tenna = new PersonajeNuevo("Tenna", "TennaVoice.wav", true);
            Tenna.Expresiones.Add("Idle", Properties.Resources.TennaIdle);
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
            Tenna.Expresiones.Add("Still", Properties.Resources.TennaFace);

            if (EstadoDeJuego.cantidadNivelesCompletados >= 4)
            {
                return new List<Dialogo>
            {
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.01"), ExpresionAUsar = "Crashing Out" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.02"), ExpresionAUsar = "Whispering" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.03"), ExpresionAUsar = "Bow",
                    EfectoEspecial = (e) => { e.ReproducirSonido("Claps.wav"); }
                },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.04"), ExpresionAUsar = "Happy" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.05"), ExpresionAUsar = "Pointing" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.06"), ExpresionAUsar = "Pointing" },
                new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.completado.07"), ExpresionAUsar = "Happy",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                        G.Obtener("tenna2.btn.si"), () => { uc.IrANivel(new JefeFinalTenna()); },
                        G.Obtener("tenna2.btn.no"), () => { uc.CerrarDialogo(); }
                    )
                }
            };
            }

            return new List<Dialogo>
        {
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.01"), ExpresionAUsar = "Surprised" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.02"), ExpresionAUsar = "Dancing Gangam Style" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.03"), ExpresionAUsar = "Whispering" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.04"), ExpresionAUsar = "In Suit" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tenna2.05"), ExpresionAUsar = "Doing Circles" }
        };
        }
    }
}