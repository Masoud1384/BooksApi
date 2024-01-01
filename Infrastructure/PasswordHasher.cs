using Application.Services.IServices;
using System.Security.Cryptography;

namespace Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int _saltSize = 128 / 8;
        private const int _keySize = 256 / 8;
        private const int _loopSize = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private static char _delimiter = ';';

        public string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password,salt,_loopSize,_hashAlgorithmName,_keySize);
            return string.Join(_delimiter,Convert.ToBase64String(salt),Convert.ToBase64String(hash));
        }

        public bool VerifyPassword(string password, string enteredPassword)
        {
            var passwordElements = password.Split(_delimiter);
            var salt = Convert.FromBase64String(passwordElements[0]);
            var hash = Convert.FromBase64String(passwordElements[1]);
            var hashinput = Rfc2898DeriveBytes.Pbkdf2(enteredPassword,salt,_loopSize,_hashAlgorithmName,_keySize);
            return CryptographicOperations.FixedTimeEquals(hash,hashinput);
        }
    }
}
