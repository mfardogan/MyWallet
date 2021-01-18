using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MyWallet.Administration.Application.Service
{
    using MyWallet.Administration.Domain.Abstraction;

    public class Rfc2898 : IPasswordHasher
    {
        public bool Check(string password, byte[] correct, byte[] salt)
        {
            return Compute(password, salt).SequenceEqual(correct);
        }

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
