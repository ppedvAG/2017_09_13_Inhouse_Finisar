using System;

namespace HalloDelegates
{
    public delegate string MyDelegate(int zahl, double wert);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(new Program().MeineMethode);

            var result = del.Invoke(4, 9.8);

            Console.WriteLine(result);
        }

        private string MeineMethode(int i, double d)
        {
            return (i + d).ToString();
        }
    }
}
