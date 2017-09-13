using System;

namespace CompositeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var meineListe = new AufgabenListe("Was so zu tun ist.");
            meineListe.Add(new Einzelaufgabe("C#7 Features lernen. :D"));
            meineListe.Add(new Einzelaufgabe("Kaffee trinken."));

            var packen = new AufgabenListe("Koffer packen.");
            packen.Add(new Einzelaufgabe("Badehose"));
            packen.Add(new Einzelaufgabe("Strandtuch"));
            packen.Add(new Einzelaufgabe("Zahnbürste"));

            meineListe.Add(packen);

            meineListe.WirdErledigt();

            Console.ReadKey();
        }
    }
}
