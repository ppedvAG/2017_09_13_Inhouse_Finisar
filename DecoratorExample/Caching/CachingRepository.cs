using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Caching
{
    public class CachingRepository : IRepository
    {
        private readonly IRepository _baseRepository;

        private DateTime lastLoadedTime;
        private List<string> _cachedCustomers;

        public CachingRepository(IRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public List<string> GetAllCustomers()
        {
            var shouldReloadData = (DateTime.Now - lastLoadedTime).TotalSeconds >= 60;

            if(_cachedCustomers == null || shouldReloadData)
            {
                _cachedCustomers = _baseRepository.GetAllCustomers();
                lastLoadedTime = DateTime.Now;
            }

            return _cachedCustomers;
        }
    }
}
