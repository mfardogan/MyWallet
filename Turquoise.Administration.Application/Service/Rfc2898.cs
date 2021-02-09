using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Turquoise.Administration.Application.Service
{
    using Turquoise.Administration.Domain.Abstraction;
    public sealed class Rfc2898 : IPasswordHasher
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="password"></param>
        /// <param name="correct"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public bool Check(string password, byte[] salt, byte[] correct) =>
            Compute(password, salt)
            .SequenceEqual(correct);

        /// <summary>
        /// Generate has
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public byte[] Compute(string password, byte[] salt)
        {
            const int LENGTH = 24;
            const int ITERATIONS = 10000;

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            using Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(bytes, salt, ITERATIONS);
            return deriveBytes.GetBytes(LENGTH);
        }
    }
}
