using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MyWallet.Administration.Domain.Abstraction;

namespace MyWallet.Administration.Application.Service
{
    public sealed class Rfc2898 : IPasswordHasher
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="password"></param>
        /// <param name="correct"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public bool Check(string password, byte[] correct, byte[] salt)
        {
            return Compute(password, salt).SequenceEqual(correct);
        }

        /// <summary>
        /// Generate has
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public byte[] Compute(string password, byte[] salt)
        {
            const int SIZEOFRESULT = 24;
            const int ITERATIONS = 10000;

            var bytes = Encoding.UTF8.GetBytes(password);
            var rfc2898 = new Rfc2898DeriveBytes(bytes, salt, ITERATIONS);
            return rfc2898.GetBytes(SIZEOFRESULT);
        }
    }
}
