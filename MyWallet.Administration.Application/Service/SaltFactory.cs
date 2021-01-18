using System.Security.Cryptography;

namespace MyWallet.Administration.Application.Service
{
    using MyWallet.Administration.Domain.Abstraction;
    public sealed class SaltFactory : ISaltFactory
    {
        public byte[] Generate()
        {
            const int LENGTH = 24;
            using RNGCryptoServiceProvider cyrypto = new RNGCryptoServiceProvider();
            byte[] buffer =  new byte[LENGTH];
            cyrypto.GetBytes(buffer);
            return buffer;
        }
    }
}
