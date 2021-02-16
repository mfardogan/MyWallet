using System;
using System.IO;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace Turquoise.Administration.Infrastructure.Cache
{
    public static class ConnectionFactory
    {
        static ConnectionFactory()
        {
            connectionMultiplexer = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(GetConnectionString("dictionary_server")),
                  isThreadSafe: true);
        }

        /// <summary>
        /// Get connection string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetConnectionString(string name) =>
            new ConfigurationBuilder().SetBasePath(
                   Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build()
                        .GetConnectionString(name);

        private readonly static Lazy<ConnectionMultiplexer> connectionMultiplexer;

        /// <summary>
        /// Get Redis connection
        /// </summary>
        /// <returns></returns>
        public static ConnectionMultiplexer Connection => connectionMultiplexer.Value;
    }
}
