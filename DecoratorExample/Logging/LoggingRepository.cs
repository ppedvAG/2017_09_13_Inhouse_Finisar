using System.Collections.Generic;
using DecoratorExample.Core;
using System;

namespace DecoratorExample.Logging
{
    public class LoggingRepository : IRepository
    {
        private readonly IRepository _baseRepository;
        private readonly ILogger _logger;

        public LoggingRepository(IRepository baseRepository, ILogger logger)
        {
            _baseRepository = baseRepository;
            _logger = logger;
        }

        public List<string> GetAllCustomers()
        {
            _logger.Log($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}: Start Load Customers.");

            var result = _baseRepository.GetAllCustomers();

            _logger.Log($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}: Loading completed.");

            return result;
        }
    }
}
