using NUnit.Framework;

namespace PasswordStrengthAdvisor.Tests
{
    [TestFixture]
    public class MixedCase
    {
        private PasswordAdvisor _advisor;

        [SetUp]
        public void SetUp()
        {
            _advisor = new PasswordAdvisor();    
        }

        [TestCase("aAfG")]
        public void Check_That_Alpha_Mixed_Case_Pass_Shorter_Than_8_Chars_Is_Weak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Weak, string.Format("Expected Weak but got {0}", strength));
        }

        [TestCase("fGasEEtWW")]
        public void Check_That_Alpha_Mixed_Case_Pass_Between_8_And_11_Chars_Is_Weak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Weak, string.Format("Expected Weak but got {0}", strength));
        }

        [TestCase("1aB22")]
        [TestCase("1aSSdn44")]
        [TestCase("a11Dd")]
        public void Check_That_AlphaNumeric_Mixed_Case_Pass_Shorter_Than_8_Chars_Is_Medium(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Medium, string.Format("Expected Medium but got {0}", strength));
        }

        [TestCase("fbwnwnSdgNSva")]
        public void Check_That_Alpha_Mixed_Case_Pass_Greater_Than_12_Chars_Is_Medium(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Medium, string.Format("Expected Medium but got {0}", strength));
        }

        [TestCase("fbwnwnSdgNSvasdfhwjt")]
        public void Check_That_Alpha_Mixed_Case_Pass_Greater_Than_15_Chars_Is_Strong(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Strong, string.Format("Expected Strong but got {0}", strength));
        }

        [TestCase("nSD11!!va")]
        public void Check_That_AlphaNumeric_Mixed_Case_With_Special_Pass_Between_8_And_11_Chars_Chars_Is_Strong(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Strong, string.Format("Expected Strong but got {0}", strength));
        }
    
    }
}