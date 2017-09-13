namespace SingeltonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = Configuration.Instance;
            c.Load();
        }
    }
}
