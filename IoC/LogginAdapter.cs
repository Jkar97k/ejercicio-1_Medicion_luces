using Api.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class LogginAdapter<T> : IapiLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LogginAdapter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<T>();
        }

        public void loadError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void loadInformation(string message, params object[] args)
        {
           _logger.LogInformation(message, args);
        }

        public void loadWarning(string message, params object[] args)
        {
            _logger?.LogWarning(message, args);
        }
    }
}
