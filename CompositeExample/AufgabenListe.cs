using System;
using System.Collections.Generic;

namespace CompositeExample
{
    internal class AufgabenListe : Aufgabe
    {
        private List<Aufgabe> _aufgaben = new List<Aufgabe>();

        public AufgabenListe(string beschreibung)
            : base(beschreibung)
        { }

        public override bool IstErledigt => _aufgaben.TrueForAll(a => a.IstErledigt);
        //{
        //    get
        //    {
        //        foreach (var a in _aufgaben)
        //            if (!a.IstErledigt)
        //                return false;

        //        return true;
        //    }
        //}   

        public override void WirdErledigt()
        {
            if(!IstErledigt)
            {
                Console.WriteLine($"{Beschreibung} wird erledigt.");

                _aufgaben.ForEach(a => a.WirdErledigt());

                //foreach (var a in _aufgaben)
                //    a.WirdErledigt();
            }
        }

        public void Add(Aufgabe aufgabe) => _aufgaben.Add(aufgabe);
    }
}
