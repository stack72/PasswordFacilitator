using System;
using System.Security.Cryptography;

namespace PasswordGeneration
{
    public static class RandomSeedGenerator
    {
        public static Random GetRandom()
        {
            byte[] randomBytes = new byte[4];

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            var seed = (randomBytes[0] & 0x7f) << 24 |
                       randomBytes[1] << 16 |
                       randomBytes[2] << 8 |
                       randomBytes[3];

            return new Random(seed);
        }
    }
}