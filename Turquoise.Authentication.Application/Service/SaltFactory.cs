using System.Security.Cryptography;
using Turquoise.Authentication.Domain.Abstraction;

namespace Turquoise.Authentication.Application.Service
{
    public sealed class SaltFactory : ISaltFactory
    {
        /// <summary>
        /// Generate random salt
        /// </summary>
        /// <returns></returns>
        public byte[] Generate()
        {
            const int LENGTH = 24;
            var buffer = new byte[LENGTH];

            using var rNGCrypto = new RNGCryptoServiceProvider();
            rNGCrypto.GetBytes(buffer);
            return buffer;
        }
    }
}
