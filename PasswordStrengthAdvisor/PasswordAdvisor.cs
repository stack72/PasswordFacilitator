using System;
using System.Text.RegularExpressions;

namespace PasswordStrengthAdvisor
{
    public class PasswordAdvisor
    {
        public PasswordScore CheckStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password", @"Password Should Exist to use this facility");
            
            var score = 0;

            if (password.Length < 8)
                score++;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (password.Length >= 15)
                score++;
            if (Regex.Match(password, @"[A-Z]+", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"(a-Z)?\d", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"(a-Z)?(\d)?[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }
    }
}
