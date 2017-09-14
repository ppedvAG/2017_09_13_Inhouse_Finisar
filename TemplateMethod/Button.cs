using System;

namespace TemplateMethod
{
    public class Button : UiElement
    {
        protected override void ZeichneInhalt()
        {
            Console.WriteLine("Zeichne Button Inhalt.");
        }
    }
}
