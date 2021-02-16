using System;
using System.IO;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.Cache
{
    internal static class Connection
    {
        static Connection()
        {
            static string _getConnectionString() =>
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build()
                        .GetConnectionString("dictionary_server");

            multiplexer = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(_getConnectionString()),
                         isThreadSafe: true);
        }

        private readonly static Lazy<ConnectionMultiplexer> multiplexer;

        /// <summary>
        /// Get Redis connection
        /// </summary>
        /// <returns></returns>
        public static ConnectionMultiplexer Multiplexer => multiplexer.Value;
    }
}
