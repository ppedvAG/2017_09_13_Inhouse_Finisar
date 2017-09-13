using System;

namespace CompositeExample
{
    internal abstract class Aufgabe : IDisposable
    {
        public Aufgabe(string beschreibung)
        {
            Beschreibung = beschreibung;
        }

        public string Beschreibung { get; }
        public abstract bool IstErledigt { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public abstract void WirdErledigt();
    }
}
