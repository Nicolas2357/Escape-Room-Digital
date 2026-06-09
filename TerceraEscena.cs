using Escape_Room_Digital.Idiomas;
using System;
using System.Collections.Generic;

namespace Escape_Room_Digital
{
    public class TerceraEscena
    {
        public List<Dialogo> CargarEscena()
        {
            PersonajeNuevo Tenna = new PersonajeNuevo("Tenna", "TennaVoice.wav", true);
            var G = GestorDeIdiomas.Instancia;
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
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.01"), ExpresionAUsar = "Idle" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.02"), ExpresionAUsar = "Surprised" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.03"), ExpresionAUsar = "Dancing Gangam Style" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.04"), ExpresionAUsar = "Pointing" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.05"), ExpresionAUsar = "Idle" },
            new Dialogo { Hablante = Tenna, Texto = G.Obtener("tercera.dialogo.06"), ExpresionAUsar = "In Suit" },
        };
        }

        public List<(Acertijo acertijo, Image expresion)> CargarPreguntas()
        {
            var G = GestorDeIdiomas.Instancia;
            return new List<(Acertijo, Image)>
            
            {
        // p01: Dragon, x cortes, respuesta = 3 + x*2
        (new AcertijoAleatorio((x) =>
        {
            int cabezas = 3 + x * 2;
            return (string.Format(G.Obtener("tercera.p01"), x), cabezas.ToString());}, 2, 7), Properties.Resources.TennaIdle),

        // p02: x personas en fila, respuesta = x (trampa, la respuesta es el mismo número)
        (new AcertijoAleatorio((x) =>
        {
            int resultado = x - 1;
            return (string.Format(G.Obtener("tercera.p02"), x), resultado.ToString());
        }, 4, 16), Properties.Resources.TennaPointing),

        // p03: x cajas con y naranjas, regalas z, respuesta = x*y - z
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int y = rng.Next(2, 6);
            int z = rng.Next(1, x * y);
            int resultado = x * y - z;
            return (string.Format(G.Obtener("tercera.p03"), x, y, z), resultado.ToString());
        }, 2, 6), Properties.Resources.TennaDancingGangamStyle),

        // p04: guardia dice x, invitado responde mitad, respuesta = x/2 (x siempre par)
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int a = rng.Next(2, 10) * 2;
            int b = rng.Next(2, 10) * 2;
            int c = x * 2;
            return (string.Format(G.Obtener("tercera.p04"), a, b, c), x.ToString());
        }, 4, 12), Properties.Resources.TennaCrashingOut),

        // p05: vela de x cm, consume y cm/hora, tras z horas, respuesta = x - y*z
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int y = rng.Next(1, 4);
            int z = rng.Next(1, x / y);
            int resultado = x - y * z;
            return (string.Format(G.Obtener("tercera.p05"), x, y, z), resultado.ToString());
        }, 10, 20), Properties.Resources.TennaDoingCircles),

        // p06: x vacas, mueren todas menos y, respuesta = y
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int y = rng.Next(1, x);
            return (string.Format(G.Obtener("tercera.p06"), x, y), y.ToString());
        }, 10, 25), Properties.Resources.TennaInSuit),

        // p07: x amigos se dan la mano, respuesta = x*(x-1)/2
        (new AcertijoAleatorio((x) =>
        {
            int resultado = x * (x - 1) / 2;
            return (string.Format(G.Obtener("tercera.p07"), x), resultado.ToString());
        }, 4, 8), Properties.Resources.TennaRunning),

        // p08: padre e hijo suman x, padre tiene y más, respuesta = (x-y)/2
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int y = rng.Next(10, x - 2);
            if (y % 2 != x % 2) y--;
            int hijo = (x - y) / 2;
            return (string.Format(G.Obtener("tercera.p08"), x, y), hijo.ToString());
        }, 30, 60), Properties.Resources.TennaPointing),

        // p09: x moscas, x arañas, x minutos, respuesta siempre = x (1 mosca = 1 araña en x min)
        (new AcertijoAleatorio((x) =>
        {
            return (string.Format(G.Obtener("tercera.p09"), x), x.ToString());
        }, 3, 9), Properties.Resources.TennaWhispering),

        // p10: perro tiene 5 letras, precio = x por letra, respuesta = 5*x
        (new AcertijoAleatorio((x) =>
        {
            int pato   = 4 * x; // pato = 4 letras
            int arana  = 5 * x; // araña = 5 letras  
            int perro  = 5 * x; // perro = 5 letras
            return (string.Format(G.Obtener("tercera.p10"), pato, arana), perro.ToString());
        }, 3, 9), Properties.Resources.TennaDoingCircles),

        // p11: escalon x, sube a, baja b, sube c, respuesta = x + a - b + c
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int a = rng.Next(2, 6);
            int b = rng.Next(1, a + x);
            int c = rng.Next(3, 8);
            int ultimo = x + a - b + c;
            return (string.Format(G.Obtener("tercera.p11"), x, a, b, c), ultimo.ToString());
        }, 3, 8), Properties.Resources.TennaBow),

        // p12: x gallinas, y huevos/dia, z dias, respuesta = x*y*z
        (new AcertijoAleatorio((x) =>
        {
            var rng = new Random();
            int y = rng.Next(2, 5);
            int z = rng.Next(2, 6);
            int resultado = x * y * z;
            return (string.Format(G.Obtener("tercera.p12"), x, y, z), resultado.ToString());
        }, 3, 8), Properties.Resources.TennaBow),
    };
        }



    }
}