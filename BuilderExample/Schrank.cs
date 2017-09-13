using System;

namespace BuilderExample
{
    internal class Schrank
    {
        private Schrank(int anzahlTüren)
        {
            AnzahlTüren = anzahlTüren;
        }

        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public Farbe Farbe { get; private set; }
        public int AnzahlBöden { get; private set; }
        public bool Kleiderstange { get; private set; }
        public bool Metallschienen { get; private set; }

        internal class Builder
        {
            public const int Min_Türen = 2;
            public const int Max_Türen = 6;
            public const int Min_Böden = 0;
            public const int Max_Böden = 7;

            private readonly Schrank _schrank;

            public Builder(int anzahlTüren)
            {
                if (anzahlTüren < Min_Türen || anzahlTüren > Max_Türen)
                    throw new ArgumentException($"Die Anzahl der Türen muss zwischen {Min_Türen} und {Max_Türen} liegen.");

                _schrank = new Schrank(anzahlTüren)
                {
                    AnzahlBöden = 2,
                    Oberfläche = Oberfläche.Lackiert,
                    Farbe = Farbe.Weiß,
                    Kleiderstange = false,
                    Metallschienen = false
                };
            }

            public Builder MitOberfläche(Oberfläche oberfläche)
            {
                if (oberfläche != Oberfläche.Lackiert && _schrank.Farbe != Farbe.KeineFarbe)
                    throw new ArgumentException("Eine Farbe kann nur bei Oberfläche Lackiert gesetzt werden.");

                _schrank.Oberfläche = oberfläche;

                return this;
            }
            public Builder InFarbe(Farbe farbe)
            {
                if (_schrank.Oberfläche != Oberfläche.Lackiert && farbe != Farbe.KeineFarbe)
                    throw new ArgumentException("Eine Farbe kann nur bei Oberfläche Lackiert gesetzt werden.");

                _schrank.Farbe = farbe;

                return this;
            }
            public Builder MitEinlegeböden(int anzahlBöden)
            {
                if (anzahlBöden < Min_Böden || anzahlBöden > Max_Böden)
                    throw new ArgumentException($"Die Anzahl der Einlegeböden muss zwischen {Min_Böden} und {Max_Böden} liegen.");

                _schrank.AnzahlBöden = anzahlBöden;
                return this;
            }
            public Builder MitKleiderstange()
            {
                _schrank.Kleiderstange = true;
                return this;
            }
            public Builder MitMetallschienen()
            {
                _schrank.Metallschienen = true;
                return this;
            }

            public Schrank Konstruiere()
            {
                // Achtung: MemberwiseClone() -> Flache Kopie
                return (Schrank)_schrank.MemberwiseClone();
            }
        }
    }
}
