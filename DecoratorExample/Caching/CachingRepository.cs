using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Caching
{
    public class CachingRepository : RepositoryDecorator
    {
        private DateTime lastLoadedTime;
        private List<string> _cachedCustomers;

        public CachingRepository(IRepository baseRepository)
            : base(baseRepository)
        { }

        public override List<string> GetAllCustomers()
        {
            var shouldReloadData = (DateTime.Now - lastLoadedTime).TotalSeconds >= 60;

            if (_cachedCustomers == null || shouldReloadData)
            {
                _cachedCustomers = base.GetAllCustomers();
                lastLoadedTime = DateTime.Now;
            }

            return _cachedCustomers;
        }
    }
}
