using DecoratorExample.Data;
using DecoratorExample.Logging;
using DecoratorExample.UI;
using System;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();
            var logger = new ConsoleLogger();
            var loggingRepository = new LoggingRepository(repository, logger);
            var vm = new ViewModel(loggingRepository);
            vm.Initialize();

            foreach (var c in vm.Customers)
                Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}
