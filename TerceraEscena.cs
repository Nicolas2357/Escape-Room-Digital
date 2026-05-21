using System;
using System.Collections.Generic;

namespace Escape_Room_Digital
{
    public class TerceraEscena
    {
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
            Tenna.Expresiones.Add("Idle", Properties.Resources.TennaIdle);

            return new List<Dialogo>
            {
                new Dialogo { Hablante = Tenna, Texto = "...", ExpresionAUsar = "Idle" },
                new Dialogo { Hablante = Tenna, Texto = "Así que, lograste resolver todos los acertijos de mis compañeros, debo decir que estoy muy impresionado.", ExpresionAUsar = "Surprised" },
                new Dialogo { Hablante = Tenna, Texto = "Solamente ha habido una persona que ha podido lograr resolver esos acertijos, y soy YO.", ExpresionAUsar = "Dancing Gangam Style" },
                new Dialogo { Hablante = Tenna, Texto = "Así que, ¿estás listo? Te voy a poner varias preguntas, y las vas a responder todas y cada una.", ExpresionAUsar = "Pointing" },
                new Dialogo { Hablante = Tenna, Texto = "Todas van a ser de respuesta abierta, y sin límite de intentos.", ExpresionAUsar = "Idle" },
                new Dialogo { Hablante = Tenna, Texto = "Entonces, sin más que decir, ¡empecemos!", ExpresionAUsar = "In Suit" },
            };
        }

        public List<(AcertijoTexto acertijo, Image expresion)> CargarPreguntas()
        {
            return new List<(AcertijoTexto, Image)>
            {
                (new AcertijoTexto(
                    "Caminando al final de la tarde, una señora contó 20 casas en una calle a su derecha. En el regreso, contó 20 casas a su izquierda. ¿Cuántas casas vio en total?",
                    "20", 0),
                Properties.Resources.TennaIdle),

                (new AcertijoTexto(
                    "¿Cuántos meses del año tienen 28 días?",
                    "12", 0),
                Properties.Resources.TennaPointing),

                (new AcertijoTexto(
                    "Si un ladrillo pesa un kilo más medio ladrillo, ¿cuánto pesa un ladrillo?",
                    "2", 0),
                Properties.Resources.TennaDancingGangamStyle),

                (new AcertijoTexto("Un guardia dice 8,el invitado responde 4. El guardia dice 14 y el invitado dice 7. Si el guardia dice 18, ¿qué debe responder el invitado?", "9", 0), Properties.Resources.TennaCrashingOut),
                (new AcertijoTexto("¿Cuál es el número que, si le quitas la mitad, se queda en cero?", "8", 0),Properties.Resources.TennaDoingCircles),
                (new AcertijoTexto("Un hombre tiene 17 vacas. Todas mueren menos nueve. ¿Cuántas vacas le quedan?", "9", 0), Properties.Resources.TennaInSuit),
                (new AcertijoTexto("¿Cuántos trozos de pastel puedes cortar, como máximo, con solo 3 cortes rectos?", "8", 0), Properties.Resources.TennaRunning),
                (new AcertijoTexto("Un padre y un hijo tienen 36 años entre los dos. El padre tiene 30 años más que el hijo. ¿Cuántos años tiene el hijo?", "3", 0 ), Properties.Resources.TennaPointing),
                (new AcertijoTexto("Si 3 moscas atrapan 3 arañas en 3 minutos, ¿cuántos minutos tardará una mosca en atrapar una araña?", "3", 0), Properties.Resources.TennaWhispering),
                (new AcertijoTexto("Si un pato cuesta $9, una araña cuesta $36 y una abeja cuesta $27. Siguiendo esa misma lógica, ¿cuánto cuesta un perro?", "18", 0), Properties.Resources.TennaDoingCircles),
                (new AcertijoTexto("Estás en el escalón medio de una escalera. Subes 3 escalones, bajas 5 y luego subes 10. Si en ese momento estás en el último escalón, ¿cuántos escalones tiene la escalera en total?","17", 0), Properties.Resources.TennaBow),
                (new AcertijoTexto("En una familia hay 2 padres y 2 hijos, pero solo hay 3 personas. ¿Cómo es posible? (Dime el número de abuelos que hay).", "1", 0), Properties.Resources.TennaBow)
            };
        }
    }
}