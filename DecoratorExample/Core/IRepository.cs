using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public interface IRepository
    {
        string GetById(int id);
        List<string> GetAllCustomers();
    }
}
