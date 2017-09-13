using System;

namespace CompositeExample
{
    internal class Einzelaufgabe : Aufgabe
    {
        public Einzelaufgabe(string beschreibung) 
            : base(beschreibung)
        { }

        private bool _istErledigt;
        public override bool IstErledigt => _istErledigt;

        public override void WirdErledigt()
        {
            if (!_istErledigt)
            {
                _istErledigt = true;
                Console.WriteLine($"\t{Beschreibung} wird erledigt.");
            }
        }
    }
}
