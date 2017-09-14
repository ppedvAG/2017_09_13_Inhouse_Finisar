using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    internal delegate bool MyDelegate(Employee employee);
    // Action       -> void
    // Predicate<T> -> bool
    // Func

    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedinung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedinung);
            //var del = new Func<Employee, bool>(Bedinung);
            //Func<Employee, bool> del = Bedinung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (Employee e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Name.StartsWith("A");
            //});

            //var query = Abfrage(employees, (e) => e.Experience > 8);
            var query = MyExtentions.MyWhere(employees, e => e.Experience > 8);
            var query2 = employees.MyWhere(e => e.Experience > 8);
            var queryLinq = employees.Where(e => e.Experience > 8);

            foreach (var e in query)
                Console.WriteLine($"Id: {e.Id,2} | {e.Name,-10} | {e.Experience,2}");

            Console.ReadKey();
        }

        private static bool Bedingung(Employee e)
        {
            return e.Name.StartsWith("A");
        }

        private static IEnumerable<Employee> GetData()
        {
            return new HashSet<Employee>
            {
                new Employee { Id = 1, Name = "Hannes", Experience = 6 },
                new Employee { Id = 2, Name = "Lisa", Experience = 7 },
                new Employee { Id = 3, Name = "Maria", Experience = 10 },
                new Employee { Id = 4, Name = "Thomas", Experience = 2 },
                new Employee { Id = 5, Name = "Franz", Experience = 3 },
                new Employee { Id = 6, Name = "Luise", Experience = 8 },
                new Employee { Id = 7, Name = "Andrea", Experience = 1 },
                new Employee { Id = 8, Name = "Max", Experience = 11 },
                new Employee { Id = 9, Name = "Thomas", Experience = 6 }
            };
        }
    }

    public static class MyExtentions
    {
        internal static IEnumerable<T> MyWhere<T>(
            this IEnumerable<T> employees,
            Func<T, bool> predicate)
        {
            foreach (var e in employees)
                if (predicate.Invoke(e))
                    yield return e;
        }
    }
}
