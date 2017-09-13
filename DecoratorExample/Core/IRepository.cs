using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public interface IRepository
    {
        List<string> GetAllCustomers();
    }
}
