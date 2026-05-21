using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Escape_Room_Digital.UserControls;

namespace Escape_Room_Digital
{
    public class SegundaEscena
    {
        public List<Dialogo> Spamton(JugarUserControl uc)
        {
            PersonajeNuevo Spamton = new PersonajeNuevo("Spamton", "SpamtonVoice.wav", true);
            Spamton.Expresiones.Add("Laughing", Properties.Resources.SpamtonTalking);
            Spamton.Expresiones.Add("Dancing", Properties.Resources.SpamtonDance);
            Spamton.Expresiones.Add("Standing Still", Properties.Resources.SpamtonStill);
            Spamton.Expresiones.Add("Quiet", Properties.Resources.SpamtonQuiet);

            if (EstadoDeJuego.NivelNerdCompletado)
            {
                return new List<Dialogo>
                {
                    new Dialogo { Hablante = Spamton, Texto = "Ya resolviste mi acertijo, ¿qué más quieres?", ExpresionAUsar = "Standing Still" },
                    new Dialogo { Hablante = Spamton, Texto = "Ve a molestar a otro, yo ya cumplí con mi parte.", ExpresionAUsar = "Quiet" }
                };
            }

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Spamton, Texto = "OH por DiO$", ExpresionAUsar = "Laughing" },
                new Dialogo { Hablante = Spamton, Texto = "TU ERES la persona de la que estaba hablando la tele con cabeza", ExpresionAUsar = "Dancing" },
                new Dialogo { Hablante = Spamton, Texto = "Bueno, no que me sorprenda, solo estaba interesado en un cliente nuevo", ExpresionAUsar = "Standing Still" },
                new Dialogo { Hablante = Spamton, Texto = "En fin, nuestra Tele con patas nos exigió que te dieramos algunos acertijos antes del show inicial, así que, ¿estás listo?", ExpresionAUsar = "Dancing" },
                new Dialogo { Hablante = Spamton, Texto = "...", ExpresionAUsar = "Quiet",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                        "¡Sí!", () => { uc.IrANivel(new NerdUserControl()); },
                        "No...", () => { uc.CerrarDialogo(); }
                    )
                }
            };
        }

        public List<Dialogo> Jevil(JugarUserControl uc)
        {
            PersonajeNuevo Jevil = new PersonajeNuevo("Jevil", "JevilVoice.wav", true);
            Jevil.Expresiones.Add("Still", Properties.Resources.Jevil);
            Jevil.Expresiones.Add("Sad", Properties.Resources.JevilSad);
            Jevil.Expresiones.Add("Tounge Out", Properties.Resources.JevilToungeOut);

            if (EstadoDeJuego.NivelJesterCompletado)
            {
                return new List<Dialogo>
                {
                    new Dialogo { Hablante = Jevil, Texto = "Ya jugamos, ¿no te acuerdas?", ExpresionAUsar = "Still" },
                    new Dialogo { Hablante = Jevil, Texto = "Anda, ve a jugar con alguien más...", ExpresionAUsar = "Sad" }
                };
            }

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Jevil, Texto = "HOLA HOLA HOLA, ¿QUIERES JUGAR UN JUEGO? ¡SÍ, SÍ!", ExpresionAUsar = "Tounge Out" },
                new Dialogo { Hablante = Jevil, Texto = "POR FAVOR DIME QUE SÍ, HE ESTADO ESPERANDO ESTO POR AÑOS", ExpresionAUsar = "Still" },
                new Dialogo { Hablante = Jevil, Texto = "he estado aquí por décadas, no sé ni siquiera mi nombre", ExpresionAUsar = "Sad" },
                new Dialogo { Hablante = Jevil, Texto = "...", ExpresionAUsar = "Sad",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                        "¡Vamos!", () => { uc.IrANivel(new JesterUserControl()); },
                        "No quiero", () => { uc.CerrarDialogo(); }
                    )
                }
            };
        }

        public List<Dialogo> Napstablook(JugarUserControl uc)
        {
            PersonajeNuevo Napstablook = new PersonajeNuevo("Napstablook", "NapstablookVoice.wav", true);
            Napstablook.Expresiones.Add("Normal", Properties.Resources.GhostImage);

            if (EstadoDeJuego.NivelGhostCompletado)
            {
                return new List<Dialogo>
                {
                    new Dialogo { Hablante = Napstablook, Texto = "Oh, ya encontraste lo que buscaba...", ExpresionAUsar = "Normal" },
                    new Dialogo { Hablante = Napstablook, Texto = "Gracias, supongo. No sé qué más decir.", ExpresionAUsar = "Normal" }
                };
            }

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Napstablook, Texto = "Oh, hola, soy un fantasma, ni siquiera sé por qué estoy aquí" },
                new Dialogo { Hablante = Napstablook, Texto = "..." },
                new Dialogo { Hablante = Napstablook, Texto = "¿Hm? ¿Tenna dijo que te pusiera un juego?" },
                new Dialogo { Hablante = Napstablook, Texto = "Oh no, no tengo un juego para ti, oh no..." },
                new Dialogo { Hablante = Napstablook, Texto = "Bueno, he estado tratando de buscar algo en mi cuarto, ¿no me puedes ayudar?" },
                new Dialogo { Hablante = Napstablook, Texto = "...",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                        "Te ayudo", () => { uc.IrANivel(new GhostUserControl()); },
                        "No gracias", () => { uc.CerrarDialogo(); }
                    )
                }
            };
        }

        public List<Dialogo> RoulxKaard(JugarUserControl uc)
        {
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
                    new Dialogo { Hablante = RoulxKaard, Texto = "¡Ya ganaste! ¡Eso estuvo increíble!", ExpresionAUsar = "Talking" },
                    new Dialogo { Hablante = RoulxKaard, Texto = "No tengo más juegos para ti, ve con los demás.", ExpresionAUsar = "Blink" }
                };
            }

            return new List<Dialogo>
            {
                new Dialogo { Hablante = RoulxKaard, Texto = "¡HOLA CÓMO ESTÁS ME ALEGRO MUCHO!", ExpresionAUsar = "Talking" },
                new Dialogo { Hablante = RoulxKaard, Texto = "Ahhh, perdón, llevo tanto tiempo esperando a alguien que me puse nervioso", ExpresionAUsar = "Scared Talking" },
                new Dialogo { Hablante = RoulxKaard, Texto = "...", ExpresionAUsar = "Scared Away" },
                new Dialogo { Hablante = RoulxKaard, Texto = "Bueno, igual, mi nombre es Roulx Kaard, tiene más sentido en inglés", ExpresionAUsar = "Talking" },
                new Dialogo { Hablante = RoulxKaard, Texto = "Nuestro creador tampoco quiso hacerlo en inglés, bueno, qué más podemos pedir", ExpresionAUsar = "Talking" },
                new Dialogo { Hablante = RoulxKaard, Texto = "Igual, mi compañero de allá nos dijo que te entretuviéramos un poco, así que, ¿estás listo?", ExpresionAUsar = "Blink" },
                new Dialogo { Hablante = RoulxKaard, Texto = "...", ExpresionAUsar = "Talking",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                        "¡Listo!", () => { uc.IrANivel(new ShortSkeletonUserControl()); },
                        "Mejor no", () => { uc.CerrarDialogo(); }
                    )
                }
            };
        }

        public List<Dialogo> Tenna(JugarUserControl uc)
        {
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
                    new Dialogo { Hablante = Tenna, Texto = "¡OH POR DIOS, COMPLETASTE TODOS LOS NIVELES!", ExpresionAUsar = "Crashing Out" },
                    new Dialogo { Hablante = Tenna, Texto = "Pero ni siquiera pude tener mi descanso de 5 minutos", ExpresionAUsar = "Whispering" },
                    new Dialogo { Hablante = Tenna, Texto = "...", ExpresionAUsar = "Bow", EfectoEspecial =(e) =>
                    {
                        e.ReproducirSonido("Claps.wav");
                    }
                    },
                    new Dialogo { Hablante = Tenna, Texto = "Bueno, al parecer ya eres todo un experto en esto de acertijos, ¿no?", ExpresionAUsar = "Happy" },
                    new Dialogo { Hablante = Tenna, Texto = "No te preocupes, ya te falta poco para completar este juego, solo falta la prueba final", ExpresionAUsar = "Pointing" },
                    new Dialogo { Hablante = Tenna, Texto = "Entonces, ¿estás listo para la prueba final?", ExpresionAUsar = "Pointing" },

                    new Dialogo {
                    Hablante = Tenna,
                    Texto = "...",
                    ExpresionAUsar = "Happy",
                    EfectoEspecial = (_) => uc.ConfigurarBotonesDecision(
                    "¡Sí, vamos!", () => { uc.IrANivel(new JefeFinalTenna()); },
                     "Necesito más tiempo", () => { uc.CerrarDialogo(); }
                    )
                    }
                };
            }

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Tenna, Texto = "Oh, hola, nos volvemos a encontrar", ExpresionAUsar = "Surprised" },
                new Dialogo { Hablante = Tenna, Texto = "Mira, el juego que tengo es muy interesante, y además te va a encantar", ExpresionAUsar = "Dancing Gangam Style" },
                new Dialogo { Hablante = Tenna, Texto = "Sin embargo, todavía estamos teniendo algunos problemas técnicos con el juego, así que...", ExpresionAUsar = "Whispering" },
                new Dialogo { Hablante = Tenna, Texto = "¿Qué te parece visitar a mis otros amigos? Parece que tienen otros juegos para entretenerte", ExpresionAUsar = "In Suit" },
                new Dialogo { Hablante = Tenna, Texto = "De mientras yo trato de averiguar qué está pasando por el otro lado, ¿está bien?", ExpresionAUsar = "Doing Circles" }
            };
        }
    }
}