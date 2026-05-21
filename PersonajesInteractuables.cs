using Escape_Room_Digital.UserControls;

namespace Escape_Room_Digital
{
    public class NPC_Nerd : ObjetoInteractuable
    {
        public NPC_Nerd(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Mi problema es solo para las \npersonas inteligentes, crees que \npuedas hacerlo?";
    }

    public class NPC_Jester : ObjetoInteractuable
    {
        public NPC_Jester(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "¿Estás listo para el reto?";
    }

    public class NPC_Ghost : ObjetoInteractuable
    {
        public NPC_Ghost(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Te diría una pista, pero realmente \nno se que hacer aqui, me ayudas?";
    }

    public class NPC_ShortSkeleton : ObjetoInteractuable
    {
        public NPC_ShortSkeleton(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Espero que estes listo.";
    }

    public class NPC_Turtle : ObjetoInteractuable
    {
        public NPC_Turtle(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Uy! has caído muy profundo, no? \nDeberias salir de aqui, es muy peligroso.\nno te preocupes, yo se como.";
    }

    public class ObjetoInteractuable_Piano : ObjetoInteractuable
    {
        public ObjetoInteractuable_Piano(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Este es un piano,\ncrees que es la respuesta a \nel acertijo?";
    }

    public class ObjetoInteractuable_Jeringa : ObjetoInteractuable
    {
        public ObjetoInteractuable_Jeringa(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Esta es una jeringa,\ncrees que es la respuesta a\nel acertijo?";
    }

    public class ObjetoInteractuable_Reloj : ObjetoInteractuable
    {
        public ObjetoInteractuable_Reloj(PictureBox pb, UserControl control)
     : base(pb, control) { }
        public override string TextoDialogo => "Este es un reloj,\ncrees que es la respuesta a\nel acertijo?";
    }
    public class ObjetoInteractuable_Mapa : ObjetoInteractuable
    {
        public ObjetoInteractuable_Mapa(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Este es un mapa,\ncrees que es la respuesta a\nel acertijo?";
    }
    public class ObjetoInteractuable_Libro : ObjetoInteractuable
    {
        public ObjetoInteractuable_Libro(PictureBox pb, UserControl control)
            : base(pb, control) { }
        public override string TextoDialogo => "Este es un libro,\ncrees que es la respuesta a\nel acertijo?";
    }
}