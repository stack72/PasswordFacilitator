using System;
using NUnit.Framework;

namespace PasswordStrengthAdvisor.Tests
{
    [TestFixture]
    public class LowerCase
    {
        private PasswordAdvisor _advisor;
        [SetUp]
        public void SetUp()
        {
            _advisor = new PasswordAdvisor();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Check_That_Empty_Pass_Throws_Exception()
        {
            var password = string.Empty;

            _advisor.CheckStrength(password);
        }

        [TestCase("azfb")]
        [TestCase("abdnsn")]
        [TestCase("abc")]
        public void Check_That_Alpha_Lowercase_Pass_Shorter_Than_8_Chars_Is_VeryWeak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.VeryWeak, string.Format("Expected VeryWeak but got {0}", strength));
        }

        [TestCase("fbwnwnsdgn")]
        public void Check_That_Alpha_Lowercase_Pass_Between_8_And_11_Chars_Is_VeryWeak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.VeryWeak, string.Format("Expected VeryWeak but got {0}", strength));
        }

        [TestCase("1ab22")]
        [TestCase("1asdn44")]
        [TestCase("a11dd")]
        public void Check_That_AlphaNumeric_Lower_Pass_Shorter_Than_8_Chars_Is_Weak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Weak, string.Format("Expected Weak but got {0}", strength));
        }

        [TestCase("fbwnwnsdgnsdv")]
        public void Check_That_Alpha_Lowercase_Pass_Greater_Than_12_Chars_Is_Weak(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Weak, string.Format("Expected Weak but got {0}", strength));
        }

        [TestCase("fbwnwnsdgnsdvjgsjej")]
        public void Check_That_Alpha_Lowercase_Pass_Greater_Than_15_Chars_Is_Medium(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Medium, string.Format("Expected Medium but got {0}", strength));
        }

        [TestCase("nsd11!!va")]
        public void Check_That_AlphaNumeric_Lower_With_Special_Pass_Between_8_And_11_Chars_Chars_Is_Medium(string password)
        {
            var strength = _advisor.CheckStrength(password);

            Assert.That(strength == PasswordScore.Medium, string.Format("Expected Medium but got {0}", strength));
        }
    }
}
