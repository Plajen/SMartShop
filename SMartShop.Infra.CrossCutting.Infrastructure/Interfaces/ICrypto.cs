namespace SMartShop.Infra.CrossCutting.Infrastructure.Interfaces
{
    public interface ICrypto
    {
        public string Encrypt(string text, string salt);
        public string Decrypt(string cipherText, string salt);
    }
}
