using System;
using System.IO;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.Cache
{
    internal static class ConnectionFactory
    {
        static ConnectionFactory()
        {
            static (string host, string port) _getConfiguration()
            {
                var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build()
                    .GetSection("Redis");

                var host = root.GetSection("Host");
                var port = root.GetSection("Port");
                return (host.Value, port.Value);
            }

            multiplexer = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(_getConfiguration().host),
                         isThreadSafe: true);
        }

        private static readonly Lazy<ConnectionMultiplexer> multiplexer;

        /// <summary>
        /// Get Redis connection
        /// </summary>
        /// <returns></returns>
        public static ConnectionMultiplexer Multiplexer => multiplexer.Value;
    }
}
