using System.Collections.Generic;

namespace DecoratorExample.Core
{
    public abstract class RepositoryDecorator : IRepository
    {
        protected IRepository BaseRepository { get; }

        public RepositoryDecorator(IRepository baseRepository)
        {
            BaseRepository = baseRepository;
        }

        public virtual List<string> GetAllCustomers()
        {
            return BaseRepository.GetAllCustomers();
        }

        public virtual string GetById(int id)
        {
            return BaseRepository.GetById(id);
        }
    }
}
