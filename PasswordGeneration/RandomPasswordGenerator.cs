using System;
using System.Security;
using PasswordGeneration.Entities;
using PasswordGeneration.Exceptions;

namespace PasswordGeneration
{
    public class RandomPasswordGenerator
    {
        private static readonly PasswordOption AlphaLC = new PasswordOption { Characters = "abcdefghijklmnopqrstuvwxyz", Count = 0 };
        private static readonly PasswordOption AlphaUC = new PasswordOption { Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", Count = 0 };
        private static readonly PasswordOption Digits = new PasswordOption { Characters = "0123456789", Count = 0 };
        private static readonly PasswordOption Specials = new PasswordOption { Characters = "!@#$%^&*()~<>?", Count = 0 };

        public SecureString Generate(int passwordLength, CharacterTypes option)
        {
            return GeneratePassword(passwordLength, option);
        }

        private static SecureString GeneratePassword(int passwordLength, CharacterTypes option)
        {
            if (passwordLength < 5)
                throw new InvalidPasswordLengthException();

            var passwordOptions = GetCharactersToIncludeInPassword(option);
            var securePassword = SelectPassword(passwordLength, passwordOptions);

            return securePassword;
        }

        private static SecureString SelectPassword(int passwordLength, PasswordOptions passwordOptions)
        {
            var random = RandomSeedGenerator.GetRandom();
            string passwordChars = GetPasswordChars(passwordOptions);

            var secureString = new SecureString();
            for (int i = 0; i < passwordLength; i++)
            {
                int index;
                char passwordChar;
                if (!passwordOptions.AllOptionsAreUsed)
                {
                    PasswordOption po = passwordOptions.GetUnusedOption();
                    index = random.Next(po.Characters.Length);
                    passwordChar = po.Characters[index];
                }
                else
                {
                    index = random.Next(passwordChars.Length);
                    passwordChar = passwordChars[index];
                }

                secureString.AppendChar(passwordChar);
            }

            return secureString;
        }

        private static string GetPasswordChars(PasswordOptions passwordOptions)
        {
            var passwordChars = String.Empty;

            foreach (var pOption in passwordOptions)
            {
                passwordChars += pOption.Characters;
            }

            if (string.IsNullOrEmpty(passwordChars))
                return null;

            return passwordChars;
        }

        private static PasswordOptions GetCharactersToIncludeInPassword(CharacterTypes option)
        {
            var list = new PasswordOptions();
            switch (option)
            {
                case CharacterTypes.Alpha_Lower:
                    list.Add(AlphaLC);
                    break;
                case CharacterTypes.Alpha_Upper:
                    list.Add(AlphaUC);
                    break;
                case CharacterTypes.Digit:
                    list.Add(Digits);
                    break;
                case CharacterTypes.AlphaLowerNumeric:
                    list.Add(AlphaLC);
                    list.Add(Digits);
                    break;
                case CharacterTypes.AlphaUpperNumeric:
                    list.Add(AlphaUC);
                    list.Add(Digits);
                    break;
                case CharacterTypes.AlphaNumeric:
                    list.Add(AlphaLC);
                    list.Add(AlphaUC);
                    list.Add(Digits);
                    break;
                case CharacterTypes.Special:
                    list.Add(Specials);
                    break;
                case CharacterTypes.AlphaNumericSpecial:
                    list.Add(AlphaLC);
                    list.Add(AlphaUC);
                    list.Add(Digits);
                    list.Add(Specials);
                    break;
                default:
                    list.Add(AlphaLC);
                    list.Add(AlphaUC);
                    break;
            }
            return list;
        }
    }
}
