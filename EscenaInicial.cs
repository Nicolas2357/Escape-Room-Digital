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
                new Dialogo{Hablante = Tenna, Texto = "...", ExpresionAUsar= "Talking" },
                new Dialogo{Hablante = Tenna, Texto = "No, ya te dije, si no conseguimos a alguien para el show, vamos a caer.", ExpresionAUsar="Talking" },
                new Dialogo
                {
                    Hablante = Tenna, Texto = "...", ExpresionAUsar= "Talking", EfectoEspecial= (e)=>
                    {
                        var objeto = e.ControlGrafico.Controls.Find("pbTennaCloud", true).FirstOrDefault();
                        if (objeto != null)
                        {
                        objeto.Visible= true;
                        }
                    }
                },
                new Dialogo
                {
                    Hablante = Tenna, Texto = "Pero a quién tenemos en este hermoso lugar.", ExpresionAUsar="Pointing", EfectoEspecial = (e) =>
                    {
                        var objeto = e.ControlGrafico.Controls.Find("pbTennaCloud", true).FirstOrDefault();
                        objeto.Visible = false;
                    }
                },
                new Dialogo{Hablante = Tenna, Texto="...", ExpresionAUsar= "Running", EfectoEspecial = (e)=>
                {
                    e.AnimarAgrandarImagen(5,400);
                }
                },
                new Dialogo{Hablante = Tenna, Texto= "Oh por Dios, es real, eres una persona real", ExpresionAUsar = "Dancing Gangam Style"
                },
                new Dialogo{Hablante = Tenna, Texto= "Este puede ser el comienzo de algo muy increible.", ExpresionAUsar = "Happy"},
                new Dialogo{Hablante = Tenna, Texto= "Ahh, perdoname, querido espécimen, ni siquiera me he introducido correctamente, una disculpa.", ExpresionAUsar = "Laughing" },
                new Dialogo{Hablante = Tenna, Texto= "Mi nombre es Tenna, Ant Tenna, y soy un presentador de Shows!, encantado de conocerte, ehhh.., ehhhh....", ExpresionAUsar = "Bow"},
                new Dialogo{Hablante = Tenna, Texto= "Ahhh, claro, todavia no me dices tu nombre, entonces, cual es tu nombre, querido hijo mío?", ExpresionAUsar = "Doing Circles", EfectoEspecial= (e)=>
                {
                    var txt = e.ControlGrafico.Controls.Find("txtNombre", true).FirstOrDefault();
                    if (txt != null)
                    {
                        txt.Visible = true;
                    }
                }
                },
                new Dialogo{Hablante = Tenna, Texto= "...", ExpresionAUsar = "In Suit", EfectoEspecial = (e) =>
                {
                    var txt= e.ControlGrafico.Controls.Find("txtNombre", true).FirstOrDefault() as TextBox;

                    if (txt != null)
                    {
                        EscenaInicial.NombreUsuario = txt.Text;
                        EstadoDeJuego.NombreJugador = txt.Text;
                        txt.Visible = false;
                    }
                }
                },
                new Dialogo { Hablante = Tenna, Texto = "placeholder", ExpresionAUsar = "Doing Circles", EfectoEspecial = (e) =>
                {
                      e.CambiarTextoDialogo($"Asi que tu nombre es {EstadoDeJuego.NombreJugador}, no? Que buen nombre!");
                }
                },
                new Dialogo{Hablante = Tenna, Texto= "No te preocupes, nadie te va a comer, este lugar solo existe cuando una persona entra, es decir, llevo vivo alrededor de 4 minutos.", ExpresionAUsar = "Crashing Out"},
                new Dialogo{Hablante = Tenna, Texto= "Si el show sale mal, no me culpen. Técnicamente, en términos de desarrollo cognitivo, soy una fruta recién cortada.", ExpresionAUsar = "Whispering"}, 
                new Dialogo{Hablante = Tenna, Texto= "...", ExpresionAUsar = "Bow", EfectoEspecial= (e) =>
                {
                    e.ReproducirSonido("Audio/Claps.wav");
                }
                },
                new Dialogo{Hablante = Tenna, Texto= "OH POR DIOS! Ni siquiera sabes con quien estoy hablando, verdad? Permiteme un poco.", ExpresionAUsar= "Surprised"},
                new Dialogo{Hablante = Tenna, Texto = "kuchau", ExpresionAUsar = "Kicking", EfectoEspecial= (e) =>
                {
                    e.CambiarFondoConRetraso(Properties.Resources.TennaBackground1, 500);
                    e.ReproducirSonido("Audio/Kick.wav");
                }
                },
                new Dialogo{Hablante = Tenna, Texto = "Ahora si que pusimos el ambiente, solo queda una cosa más que hacer.", ExpresionAUsar = "Doing Circles", EfectoEspecial = (e) => 
                {
                    e.ReproducirMusica("Audio/HipShop.wav");
                }
                },
                new Dialogo{Hablante = Tenna, Texto = "Necesito a Alguien especial y dispuesto para participar en mi show, y TU mi amigo eres el indicado.", ExpresionAUsar = "Pointing"},
                new Dialogo{Hablante = Tenna, Texto = "Entonces, que te parece? Te animas a participar en este maravilloso evento el cual no sabes nada al respecto?", ExpresionAUsar = "Pointing" },
                new Dialogo{Hablante = Tenna, Texto = "...", ExpresionAUsar = "Happy", EfectoEspecial = (e) =>
                {
                    var objeto3= e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                    if(objeto3 != null)
                    {
                        objeto3.Visible= false;
                    }

                    var objeto = e.ControlGrafico.Controls.Find("btnSiTenna", true).FirstOrDefault() as Button;
                    if (objeto != null)
                    {
                        objeto.Visible = true;
                    }
                    var objeto2 = e.ControlGrafico.Controls.Find("btnNoTenna", true).FirstOrDefault() as Button;
                    if(objeto2 != null)
                    {
                        objeto2.Visible = true;
                    }
                }
                },
                new Dialogo{Hablante = Tenna, Texto = "Bueno, a cualquier botón que le piques, es lo mismo,nuestro creador no quiso complicarse, no?", ExpresionAUsar = "Whispering", EfectoEspecial = (e) =>
                {
                    var objeto3= e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                    if(objeto3 != null)
                    {
                        objeto3.Visible= true;
                    }
                    var objeto2 = e.ControlGrafico.Controls.Find("btnNoTenna", true).FirstOrDefault() as Button;
                    if(objeto2 != null)
                    {
                        objeto2.Visible = false;
                    }
                    var objeto = e.ControlGrafico.Controls.Find("btnSiTenna", true).FirstOrDefault() as Button;
                    if (objeto != null)
                    {
                        objeto.Visible = false;
                    }
                } 
                },
                new Dialogo{Hablante = Tenna, Texto = "...", ExpresionAUsar = "Bow", EfectoEspecial = (e) =>
                {
                    e.ReproducirSonido("Audio/Claps.wav");
                }
                },
                new Dialogo{ Hablante = Tenna, Texto = "Entonces, sin mas que decir, vamos a comenzar, Bienvenido, al Escape Room Digital!", ExpresionAUsar = "Pointing", EfectoEspecial = (e)=>
                {
                 var objeto = e.ControlGrafico.Controls.Find("btnEmpezarTenna", true).FirstOrDefault() as Button;
                    if (objeto != null)
                    {
                        objeto.Visible = true;
                    }
                 var objeto3= e.ControlGrafico.Controls.Find("btnContinuarTenna", true).FirstOrDefault() as Button;
                    if(objeto3 != null)
                    {
                        objeto3.Visible= false;
                    }
                }
                }
            };
        }
    } 
}
