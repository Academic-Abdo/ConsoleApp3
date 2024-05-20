using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string password = Console.ReadLine()!;
            passwordHeper obj = new passwordHeper();
            string HasedPass = obj.HashPasword(password, out var salt);
            Console.WriteLine(password);
            Console.WriteLine(salt);
        }

    }
    class passwordHeper
    {

        const int keySize = 64;
        const int iterations = 600;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }
    }
}
