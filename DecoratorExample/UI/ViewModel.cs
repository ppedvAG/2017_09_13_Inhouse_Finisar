using DecoratorExample.Core;
using System.Collections.Generic;

namespace DecoratorExample.UI
{
    public class ViewModel
    {
        private readonly IRepository _repository;

        public List<string> Customers { get; set; }

        public ViewModel(IRepository repository)
        {
            _repository = repository;
        }

        public void Initialize()
        {
            Customers = _repository.GetAllCustomers();
        }
    }
}
