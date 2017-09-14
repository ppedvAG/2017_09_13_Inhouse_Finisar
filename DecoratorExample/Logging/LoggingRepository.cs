using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Logging
{
    public class LoggingRepository : RepositoryDecorator
    {
        private readonly ILogger _logger;

        public LoggingRepository(IRepository baseRepository, ILogger logger)
            : base(baseRepository)
        {
            _logger = logger;
        }

        public override List<string> GetAllCustomers()
        {
            _logger.Log($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}: Start Load Customers.");

            var result = base.GetAllCustomers();

            _logger.Log($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}: Loading completed.");
            foreach (var item in result)
            {
                _logger.Log($"\t{item}");
            }

            return result;
        }
    }
}
