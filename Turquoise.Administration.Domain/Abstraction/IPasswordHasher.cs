namespace MyWallet.Administration.Domain.Abstraction
{
    public interface IPasswordHasher
    {
        public byte[] Compute(string password, byte[] salt);
        public bool Check(string password, byte[] correct, byte[] salt);
    }
}
