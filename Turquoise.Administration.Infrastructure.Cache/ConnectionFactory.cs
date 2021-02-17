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
            var root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build()
                .GetSection("Redis");
            Configuration = (root.GetSection("Host").Value, root.GetSection("Port").Value);
        }

        private static readonly Lazy<ConnectionMultiplexer> muxer = 
            new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(Configuration.host),
                         isThreadSafe: true);
        /// <summary>
        /// Get Redis connection
        /// </summary>
        /// <returns></returns>
        public static ConnectionMultiplexer ConnectionMultiplexer => muxer.Value;

        /// <summary>
        /// Redis host
        /// </summary>
        public static (string host, string port) Configuration { get; }
    }
}
