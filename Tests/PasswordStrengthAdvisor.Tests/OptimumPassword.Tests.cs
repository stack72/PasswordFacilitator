using NUnit.Framework;

namespace PasswordStrengthAdvisor.Tests
{
    [TestFixture]
    public class OptimumPassword
    {
        private PasswordAdvisor _advisor;
        [SetUp]
        public void SetUp()
        {
            _advisor = new PasswordAdvisor();
        }

        [TestCase("!SSSaa888es!!")]
        public void Check_That_Alpha_Mixed_Case_Pass_With_Special_Char_Greater_Than_12_Chars_Is_VeryString(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.VeryStrong, string.Format("Expected VeryStrong got {0}", strength));
        }

        [TestCase("!SSSaa888ss_es!!")]
        public void Check_That_Alpha_Mixed_Case_Pass_With_Special_Char_Greater_Than_15_Chars_Is_Excellent(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Excellent, string.Format("Expected Excellent got {0}", strength));
        }
    }
}