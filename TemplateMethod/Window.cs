using System;

namespace TemplateMethod
{
    public class Window : UiElement
    {
        // Muss überschrieben werden!
        protected override void ZeichneInhalt()
        {
            Console.WriteLine("Zeichne Window Inhalt.");
        }

        // Kann überschrieben werden.
        protected override void ZeichneRahmen()
        {
            Console.WriteLine("Zeichne Window Rahmen.");
        }
    }
}
