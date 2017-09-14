using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TemplateMethod
{
    public abstract class UiElement
    {
        // Die Template Method, deutsch: Schablonenmethode
        // auf keinen Fall virtual oder abstract
        public void Zeichnen()
        {
            // Diese Methode definiert den Algorithmus.

            ZeichneRahmen();
            ZeichneSchatten();
            ZeichneInhalt();
            ZeichneUnterelemente();
        }

        // 1. kann überschrieben werden
        protected virtual void ZeichneRahmen()
        {
            Console.WriteLine("Zeichne default Rahmen.");
        }

        // 2. muss überschrieben werden
        protected abstract void ZeichneInhalt();

        public ICollection<UiElement> Children { get; } = new Collection<UiElement>();
        // 3. darf nicht überschrieben werden
        private void ZeichneUnterelemente()
        {
            foreach (var c in Children)
                c.Zeichnen();
        }

        // 4. Hook
        protected virtual void ZeichneSchatten()
        { /* Absichtlich leer!! */ }
    }
}
