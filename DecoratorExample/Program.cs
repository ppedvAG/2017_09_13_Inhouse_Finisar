using DecoratorExample.Caching;
using DecoratorExample.Core;
using DecoratorExample.Data;
using DecoratorExample.Logging;
using DecoratorExample.UI;
using StructureMap;
using System;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(c =>
            {
                c.For<IRepository>().Use<Repository>();
                c.For<IRepository>().DecorateAllWith<LoggingRepository>();
                c.For<IRepository>().DecorateAllWith<CachingRepository>();

                c.For<ILogger>().Use<ConsoleLogger>();
            });

            //var repository = new Repository();
            //var logger = new ConsoleLogger();
            //var loggingRepository = new LoggingRepository(repository, logger);
            //var cachingRepository = new CachingRepository(loggingRepository);
            //var vm = new ViewModel(cachingRepository);

            var vm = container.GetInstance<ViewModel>();

            while (true)
            {
                vm.Initialize();
                foreach (var c in vm.Customers)
                    Console.WriteLine(c);
                Console.WriteLine();

                var eingabe = Console.ReadKey();
                if (eingabe.Key == ConsoleKey.Q)
                    break;
            }
        }
    }
}
