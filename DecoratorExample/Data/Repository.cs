using DecoratorExample.Core;
using System.Collections.Generic;

namespace DecoratorExample.Data
{
    public class Repository : IRepository
    {
        public List<string> GetAllCustomers()
        {
            // select * from Customers ...
            // holt die Daten aus der Datenbank
            return new List<string>
            {
                "Hermann",
                "Magdalena",
                "Stanislaus"
            };
        }

        public string GetById(int id)
        {
            return "Hermann";
        }
    }
}
