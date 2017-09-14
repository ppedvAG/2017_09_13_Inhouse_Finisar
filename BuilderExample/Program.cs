using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Schrank.Builder(anzahlTüren: 4)
                .MitOberfläche(Oberfläche.Gewachst)
                .InFarbe(Farbe.KeineFarbe)
                .MitKleiderstange();
            
            // Bezahlen
            var schrank = builder.Konstruiere();


            builder.MitEinlegeböden(7);
        }
    }
}
